using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TinyLibraryWeb_M3.Helpers;


namespace TinyLibraryWeb_M3.Controls
{
    public partial class LoginPanel : UserControl
    {
        public event EventHandler LoginSuccess;
        public string Username => txtUsername.Text;
        public string Password => txtPassword.Text;
        public bool RememberMe => chkRemember.Checked;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.Cookies["RememberMe"] != null)
            {
                txtUsername.Text = Request.Cookies["RememberMe"].Value;
                chkRemember.Checked = true;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            string user = txtUsername.Text;
            string pwd = txtPassword.Text;
            string captchaInput = txtCaptcha.Text;
            string captchaExpected = Session["Captcha"] as string;

            if (captchaExpected != captchaInput)
            {
                lblMessage.Text = "Captcha incorrect.";
                return;
            }

            string role;

            if (TinyLibraryWeb_M3.Helpers.AuthHelper.Validate(user, pwd, out role))
            {
                Session["Role"] = role;
                if (chkRemember.Checked)
                {
                    var cookie = new HttpCookie("RememberMe", user)
                    {
                        Expires = DateTime.Now.AddDays(7)
                    };
                    Response.Cookies.Add(cookie);
                }
                else
                {
                    Response.Cookies["RememberMe"].Expires = DateTime.Now.AddDays(-1);
                }

                LoginSuccess?.Invoke(this, EventArgs.Empty); // fire event
            }
            else
            {
                lblMessage.Text = "Invalid credentials.";
            }
        }
    }
}
