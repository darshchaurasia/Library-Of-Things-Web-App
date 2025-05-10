using System;
using System.Collections.Generic;
using TinyLibraryWeb_M3.Models;

namespace TinyLibraryWeb_M3
{
    public partial class TryIt_Cart : System.Web.UI.Page
    {
        // Handling the pre-initialization event
        protected void Page_PreInit(object sender, EventArgs e)
        {
        }
        // Handling the page load event
        protected void Page_Load(object sender, EventArgs e)
        {
            
        if (!IsPostBack)
            BindCart();
        }
        // Adding a new item to the cart
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var cart = Session["Cart"] as List<Item> ?? new List<Item>();

            cart.Add(new Item
            {
                Id = txtId.Text,
                Name = txtName.Text,
                IsBorrowed = false
            });

            Session["Cart"] = cart;
            BindCart();
        }
        // Binding cart data to the GridView
        private void BindCart()
        {
            gvCart.DataSource = Session["Cart"] as List<Item>;
            gvCart.DataBind();
        }
    }
}
