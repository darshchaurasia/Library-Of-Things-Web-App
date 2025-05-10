using System;
using TinyLibraryWeb_M3.SearchRef; 

namespace TinyLibraryWeb_M3
{
    public partial class TryIt_Search : System.Web.UI.Page
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
                // apply the selected theme’s CSS
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Initializing the search service client
            var client = new SearchServiceClient();
            try
            {
                // Retrieving items based on the keyword
                var items = client.ItemSearch(txtKeyword.Text);
                client.Close();

                // Displaying results or a no-results message
                if (items == null || items.Length == 0)
                {
                    lblSearchMessage.Text = "No items found matching your keyword.";
                    gvResults.DataSource = null;
                    gvResults.DataBind();
                }
                else
                {
                    lblSearchMessage.Text = "";
                    gvResults.DataSource = items;
                    gvResults.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Aborting the client connection on error
                client.Abort();
                lblSearchMessage.Text = "Error: " + ex.Message;
            }
        }

    }
}
