using System;

namespace TinyLibraryWeb_M3
{
    public partial class TryIt_Login : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }
        // Displaying success message on successful login
        protected void LoginPanel1_LoginSuccess(object sender, EventArgs e)
        {
            lblStatus.Text = "Login successful!";
        }
    }
}
