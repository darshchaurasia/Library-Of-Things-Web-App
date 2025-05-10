using System;
using System.Web;
using System.Web.Security;

namespace TinyLibraryWeb_M3
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string theme = Session["Theme"] as string ?? "light";
            themeCss.Href = $"App_Themes/{theme}/style.css";

            // Checking if user is authenticated
            bool auth = Page.User.Identity.IsAuthenticated; // Checking if user is authenticated
            litUser.Text = auth ? $"Hello, {Page.User.Identity.Name}" : ""; // Displaying user name
            // Toggling visibility of login/logout links
            lnkLogin.Visible = !auth;
            lnkLogout.Visible = auth;
            hlMember.Visible = auth; // Showing member link
            // Showing staff link only for staff role
            hlStaff.Visible = auth && (Session["Role"] as string) == "staff";

            if (!IsPostBack)
                ddlTheme.SelectedValue = theme;
        }
        // Handling logout
        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
        // Updating theme
        protected void ddlTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Theme"] = ddlTheme.SelectedValue;
            Response.Redirect(Request.RawUrl);
        }
    }
}
