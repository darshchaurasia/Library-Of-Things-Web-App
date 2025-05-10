using System;
using System.Web.Security;
using TinyLibraryWeb_M3.Helpers;
using TinyLibraryWeb_M3.Models;

namespace TinyLibraryWeb_M3
{
    public partial class Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Redirecting to login if user is not authenticated
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx", true);
                return;
            }

            // Ensuring only staff can access this page
            string role = Session["Role"] as string;
            if (!string.Equals(role, "staff", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("Default.aspx", true);
                return;
            }

            litUser.Text = User.Identity.Name;

            // Binding data to grids on initial load
            if (!IsPostBack)
            {
                mv.ActiveViewIndex = 0;
                BindUsers();
                BindItems();
                BindBorrowed();
            }
        }
        // Switching to the users view
        protected void ShowUsers(object s, EventArgs e) { mv.ActiveViewIndex = 0; }
        // Switching to the items view
        protected void ShowItems(object s, EventArgs e) { mv.ActiveViewIndex = 1; }
        // Switching to the borrowed items view
        protected void ShowBorrowed(object s, EventArgs e) { mv.ActiveViewIndex = 2; }

        // Binding user data to the users GridView
        private void BindUsers()
        {
            gvUsers.DataSource = AuthHelper.GetAll();
            gvUsers.DataBind();
        }

        protected void gvUsers_RowCommand(object s, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            string user = gvUsers.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            // Promoting, demoting, or deleting users based on command
            if (e.CommandName == "pro") AuthHelper.Promote(user);
            if (e.CommandName == "dem") AuthHelper.Demote(user);
            if (e.CommandName == "del") AuthHelper.Delete(user);
            // Refreshing the users GridView
            BindUsers();
            // Preventing demotion or deletion of the TA account
            if (user.Equals("TA", StringComparison.OrdinalIgnoreCase) &&
               (e.CommandName == "dem" || e.CommandName == "del"))
            {
                return;
            }
        }
        // Binding item data to the items GridView
        private void BindItems()
        {
            gvItems.DataSource = ItemRepository.GetAll();
            gvItems.DataBind();
        }
        // Adding a new item when the add button is clicked
        protected void btnAddItem_Click(object s, EventArgs e)
        {
            // Adding the new item if the input is valid
            if (!string.IsNullOrWhiteSpace(txtNewItem.Text))
                ItemRepository.Add(txtNewItem.Text.Trim());

            txtNewItem.Text = "";
            BindItems();
        }

        protected void gvItems_RowCommand(object s, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName != "del") return;
            // Deleting the selected item
            string id = gvItems.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            ItemRepository.Delete(id);
            // Refreshing both items and borrowed GridViews
            BindItems();
            BindBorrowed();
        }
        // Binding borrowed items data to the borrowed GridView
        private void BindBorrowed()
        {
            var list = ItemRepository.GetBorrowed();
            // Converting items to a view with late fee calculations
            gvBorrowed.DataSource = list.ConvertAll(i => new
            {
                i.Id,
                i.Name,
                i.BorrowedBy,
                i.DueDate,
                LateFee = FeeCalcLibrary.FeeCalc.ComputeLateFee(
                    Math.Max(0, (DateTime.Today - DateTime.Parse(i.DueDate)).Days))
            });
            gvBorrowed.DataBind();
        }

        // Handling return commands in the borrowed GridView
        protected void gvBorrowed_RowCommand(object s, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName != "ret") return;
            // Marking the item as returned
            string id = gvBorrowed.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            var it = ItemRepository.Get(id);
            it.IsBorrowed = false;
            it.BorrowedBy = "";
            it.DueDate = "";
            ItemRepository.Update(it);

            // Refreshing both borrowed and items GridViews
            BindBorrowed();
            BindItems();
        }

        // Logging out the user when the logout button is clicked
        protected void btnLogout_Click(object s, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx", true);
        }
    }
}
