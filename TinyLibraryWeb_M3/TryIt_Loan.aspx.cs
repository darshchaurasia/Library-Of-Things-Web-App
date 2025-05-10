using System;
using TinyLibraryWeb_M3.LoanRef;

namespace TinyLibraryWeb_M3
{
    public partial class TryIt_Loan : System.Web.UI.Page
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
        // Calculating late fee when the calculate button is clicked
        protected void btnCalcFee_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";

            if (int.TryParse(txtDaysLate.Text, out int daysLate))
            {
                try
                {
                    LoanServiceClient client = new LoanServiceClient();
                    decimal result = client.FeeCalcLibrary(daysLate);
                    lblResult.Text = $"Late Fee for {daysLate} day(s): <strong>${result}</strong>";
                    client.Close();
                }
                catch (Exception ex)
                {
                    lblResult.Text = $"Error: {ex.Message}";
                }
            }
            else
            {
                lblResult.Text = "Please enter a valid number.";
            }
        }

        // Hashing the password when the hash button is clicked
        protected void btnHash_Click(object sender, EventArgs e)
        {
            string pwd = txtPassword.Text;

            if (!string.IsNullOrWhiteSpace(pwd))
            {
                string hashed = FeeCalcLibrary.FeeCalc.HashPassword(pwd);
                lblHashResult.Text = $"Hashed password:<br /><code>{hashed}</code>";
            }
            else
            {
                lblHashResult.Text = "Please enter a password.";
            }
        }

    }
}
