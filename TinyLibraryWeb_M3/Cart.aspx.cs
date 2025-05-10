using System;
using System.Collections.Generic;
using System.Linq;
using TinyLibraryWeb_M3.Models;
using System.Web.UI.WebControls;

namespace TinyLibraryWeb_M3
{
    public partial class Cart : System.Web.UI.Page
    {
        // Declaring a private list to hold cart items
        private List<Item> _cart;
        // Handling the page load event
        protected void Page_Load(object sender, EventArgs e)
        {
            // Checking if the user is authenticated, redirecting to login if not
            if (!User.Identity.IsAuthenticated)
                Response.Redirect("Login.aspx");
            // Initializing the cart from session or creating a new empty list
            _cart = Session["Cart"] as List<Item> ?? new List<Item>();
            // Binding the cart data to the grid view on first load
            if (!IsPostBack)
                Bind();
        }
        // Binding the cart items to the GridView for display
        private void Bind()
        {
            gvCart.DataSource = _cart;
            gvCart.DataBind();
        }
        // Processing the checkout action when the checkout button is clicked
        protected void btnCheckout_Click(object s, EventArgs e)
        {
            // Looping through each row in the cart GridView
            foreach (GridViewRow row in gvCart.Rows)
            {
                string id = gvCart.DataKeys[row.RowIndex].Value.ToString(); // Getting the item ID from the current row
                var txtDue = (TextBox)row.FindControl("txtDue"); // Finding the due date textbox in the row
                string dueDate = txtDue?.Text ?? DateTime.Today.ToString("yyyy-MM-dd"); // Setting the due date, today's is not given

                var item = ItemRepository.Get(id);
                if (item == null) continue;
                // Marking the item as borrowed and setting borrower details
                item.IsBorrowed = true;
                item.BorrowedBy = User.Identity.Name;
                item.DueDate = dueDate;
                // Updating the item in the repository
                ItemRepository.Update(item);
            }
            // Clearing the cart session after checkout
            Session["Cart"] = null;
            Response.Redirect("Member.aspx", true);
        }
        // Handling the cancel action to return to the Member page
        protected void btnCancel_Click(object s, EventArgs e)
        {
            Response.Redirect("Member.aspx", true);
        }
    }
}
