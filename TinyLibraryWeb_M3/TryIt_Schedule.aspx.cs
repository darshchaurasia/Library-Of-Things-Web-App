using System;
using TinyLibraryWeb_M3.ScheduleRef;
using System.ServiceModel;

namespace TinyLibraryWeb_M3
{
    public partial class TryIt : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            // if (Session["Theme"] != null)
            //     Page.Theme = Session["Theme"].ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
            }
        }

        // Fetching due date when the button is clicked
        protected void btnTest_Click(object sender, EventArgs e)
        {
            // Checking for valid item ID input
            if (string.IsNullOrWhiteSpace(txtItemId.Text))
            {
                lblResult.Text = "You left the Item ID empty!";
                return;
            }

            try
            {
                // Creating a client to access the schedule service
                var client = new TinyLibraryWeb_M3.ScheduleRef.ScheduleServiceClient();
                try
                {
                    // Retrieving the due date for the specified item ID
                    DateTime due = client.GetDueDate(txtItemId.Text.Trim());
                    if (due == DateTime.MinValue)
                        lblResult.Text = $"No due date found for ID '{txtItemId.Text}'.";
                    else
                        lblResult.Text = $"Due date for '{txtItemId.Text}': {due:MM/dd/yyyy}";
                }
                finally
                {
                    // Ensuring the client connection is closed properly
                    if (client.State == System.ServiceModel.CommunicationState.Opened)
                        client.Close();
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = "Error: " + ex.Message;
            }
        }
    }
}