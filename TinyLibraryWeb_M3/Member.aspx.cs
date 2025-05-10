using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using TinyLibraryWeb_M3.Models;
using TinyLibraryWeb_M3.Services;
using FeeCalcLibrary;
using System.Collections.Generic;
using TinyLibraryWeb_M3.ScheduleRef;
using System.Web.UI.WebControls;

namespace TinyLibraryWeb_M3
{
    public partial class Member : System.Web.UI.Page
    {
        // Getting the list of items borrowed by the current user
        private List<Item> MyItems =>
            ItemRepository
                .GetAll()
                .Where(i => i.IsBorrowed && i.BorrowedBy == User.Identity.Name)
                .ToList();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Checking if the user is authenticated, redirecting to login if not
            if (!User.Identity.IsAuthenticated)
                Response.Redirect("Login.aspx");

            // Binding data to grids on initial page load
            if (!IsPostBack)
            {
                BindAllItems();
                BindMyItems();
            }

            // Updating the cart button text with the current cart item count
            var cart = Session["Cart"] as List<string> ?? new List<string>();
            btnCart.Text = $"Cart ({cart.Count})";
        }

        // Binding all available items to the GridView, optionally filtering by keyword
        void BindAllItems(string keyword = null)
        {
            List<Item> items;
            // Searching for items if a keyword is provided
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var svc = new TinyLibraryWeb_M3.SearchRef.SearchServiceClient();
                var proxyItems = svc.ItemSearch(keyword);
                svc.Close();
                // Converting search results to the Item model
                items = proxyItems
                    .Select(p => new Item
                    {
                        Id = p.Id,
                        Name = p.Name,
                        IsBorrowed = p.IsBorrowed,
                        BorrowedBy = p.BorrowedBy,
                        DueDate = p.DueDate
                    })
                    .ToList();
            }
            else
            {
                // Retrieving all items if no keyword is provided
                items = ItemRepository.GetAll();
            }
            // Preparing the view for display with item status
            var view = items.Select(i => new {
                i.Id,
                i.Name,
                StatusText = !i.IsBorrowed
                    ? "Available"
                    : i.BorrowedBy == User.Identity.Name
                        ? "Borrowed by you"
                        : "Borrowed by others"
            }).ToList();

            gvItems.DataSource = view;
            gvItems.DataBind();
        }


        void BindMyItems()
        {
            // Preparing the view for borrowed items with late fee calculations
            var view = MyItems.Select(i =>
            {
                DateTime due = DateTime.TryParse(i.DueDate, out var dt) ? dt : DateTime.MinValue;
                int daysLate = due == DateTime.MinValue ? 0 : (DateTime.Today - due).Days;
                decimal fee = daysLate > 0 ? FeeCalc.ComputeLateFee(daysLate) : 0m;

                return new
                {
                    i.Id,
                    i.Name,
                    DueDate = due == DateTime.MinValue ? "N/A" : due.ToString("yyyy-MM-dd"),
                    DaysLate = daysLate,
                    LateFee = fee.ToString("C")
                };
            }).ToList();

            gvMy.DataSource = view;
            gvMy.DataBind();
        }
        // Triggering a search when the search button is clicked
        protected void btnSearch_Click(object sender, EventArgs e)
            => BindAllItems(txtSearch.Text.Trim());

        // Adding selected items to the cart when the add button is clicked
        protected void btnAddSelected_Click(object sender, EventArgs e)
        {
            // Initializing or retrieving the cart from session
            var cart = Session["Cart"] as List<TinyLibraryWeb_M3.Models.Item>
                       ?? new List<TinyLibraryWeb_M3.Models.Item>();

            // Looping through GridView rows to find selected items
            foreach (GridViewRow row in gvItems.Rows)
            {
                var chk = (CheckBox)row.FindControl("chkSelect");
                if (chk != null && chk.Checked)
                {
                    string id = gvItems.DataKeys[row.RowIndex].Value.ToString();
                    var item = ItemRepository.Get(id);
                    if (item != null && !item.IsBorrowed)
                        cart.Add(item);
                }
            }

            // Saving the updated cart to session
            Session["Cart"] = cart;
            Response.Redirect("~/Cart.aspx", true);
        }

        // Handling row commands in the items GridView
        protected void gvItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "act") return;

            // Getting the row index and item ID
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            string id = gvItems.DataKeys[rowIndex].Value.ToString();

            // Initializing or retrieving the cart
            var cart = Session["Cart"] as List<Item> ?? new List<Item>();

            if (cart.Any(i => i.Id == id))
            {
                lblMsg.Text = "Item is already in your cart.";
                return;
            }
            // Adding the item to the cart if available
            var item = ItemRepository.Get(id);
            if (item != null && !item.IsBorrowed)
                cart.Add(item);

            Session["Cart"] = cart;
            btnCart.Text = $"Cart ({cart.Count})";
            lblMsg.Text = $"Added '{item?.Name}' to cart.";
        }

        // Handling row commands in the borrowed items GridView
        protected void gvMy_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName != "ret") return;

            // Getting the row index and item ID
            int row = Convert.ToInt32(e.CommandArgument);
            string id = gvMy.DataKeys[row].Value.ToString();
            var item = ItemRepository.Get(id);
            if (item == null) return;

            // Marking the item as returned
            item.IsBorrowed = false;
            item.BorrowedBy = "";
            item.DueDate = "";
            ItemRepository.Update(item);

            // Refreshing both GridViews
            BindAllItems();
            BindMyItems();
        }

        // Logging out the user when the logout button is clicked
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx", true);
        }

        // Redirecting to the cart page when the cart button is clicked
        protected void btnCart_Click(object sender, EventArgs e)
            => Response.Redirect("Cart.aspx");
    }
}
