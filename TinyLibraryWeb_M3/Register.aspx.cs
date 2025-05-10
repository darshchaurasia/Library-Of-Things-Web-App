using System;
using System.Drawing;
using TinyLibraryWeb_M3.Helpers;

namespace TinyLibraryWeb_M3
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Processing the registration when the register button clicked
        protected void btnReg_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            lblMsg.ForeColor = Color.Red;

            // Checking if the passwords match
            if (txtPwd.Text != txtPwd2.Text)
            {
                lblMsg.Text = "Passwords do not match.";
                return;
            }
            // Verifying the CAPTCHA input
            if ((Session["Captcha"] as string) != txtCap.Text)
            {
                lblMsg.Text = "Wrong Captcha.";
                return;
            }

            bool ok = AuthHelper.Register(txtUser.Text, txtPwd.Text);

            // Displaying the result of the registration attempt
            if (ok)
            {
                lblMsg.Text = "Account created! Go log in.";
                lblMsg.ForeColor = Color.Green;
            }
            else
            {
                lblMsg.Text = "Username already exists.";
            }
        }
    }
}
