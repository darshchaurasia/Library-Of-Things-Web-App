using System;
using System.Web.Security;
using TinyLibraryWeb_M3.Controls;

namespace TinyLibraryWeb_M3
{
    public partial class Login : System.Web.UI.Page
    {
        // Handling the page load event
        protected void Page_Load(object sender, EventArgs e) 
        {}

        // Processing successful login from the login panel
        protected void LoginSuccess(object s, EventArgs e)
        {
            // Getting the login panel control
            var pnl = (LoginPanel)s;

            // Setting the authentication cookie with the username and remember-me option
            FormsAuthentication.SetAuthCookie(pnl.Username, pnl.RememberMe);
            // Retrieving the user role from session, defaulting to "member" if not found
            string role = (Session["Role"] as string) ?? "member";
            // Redirecting based on user role
            if (role.Equals("staff", StringComparison.OrdinalIgnoreCase))
                Response.Redirect("~/Staff.aspx", true);
            else
                Response.Redirect("~/Member.aspx", true);
        }
    }
}
