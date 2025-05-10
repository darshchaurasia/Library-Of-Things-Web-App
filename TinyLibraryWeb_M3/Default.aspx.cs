using System;
using System.Data;

namespace TinyLibraryWeb_M3
{
    public partial class Default : System.Web.UI.Page
    {
        // Initializing the page before it loads
        protected void Page_PreInit(object sender, EventArgs e)
        {
        }
        // Handling the page load event
        protected void Page_Load(object sender, EventArgs e)
        {
            // Checking if this is the first page load (not a postback)
            if (!IsPostBack)
            {
                // Setting the introductory content for the landing page
                litIntro.Text = @"
<h1>Welcome to the Library Of Things</h1>
<p>Borrow household items—manage your cart, checkout, and returns.</p>

<div style='padding:15px; background:#999; border:1px solid #555; margin-bottom:20px;'>
  <h2>About Library of Things</h2>
  <p>
    Library of Things lets community members borrow everyday items—
    from phone chargers to power drills—rather than purchase them.
    <strong>Members</strong> self-register on the Register page (with CAPTCHA),
    log in, browse or search inventory, add items to their cart, select return dates,
    and click <em>Checkout</em>. Borrowed items appear under “My Borrowed Items,”
    where they can be returned.
    <strong>Staff</strong> (admin role) can log in, manage users (promote/demote/delete),
    add/delete inventory items, and mark borrowed items as returned.
  </p>

  <p>
    <strong>Getting Started:</strong> If this is your first time using the application,
    you must create an account first.
    All newly created accounts begin with the **Member** role. Only users with
    the **Staff** role can manage user roles, including promoting a Member to Staff.
    An initial **Staff** account is available with the username and password
    provided for testing staff functionality. You can access staff functions via the Staff page.
  </p>

  <h3>How to Test</h3>
  <ol>
    <li><strong>Register a new member:</strong>
      To create a new member account, click the Create a new account button, enter Username, Password, Confirm, solve CAPTCHA,
      then log in using your new account credentials.</li>
    <li><strong>Member functions:</strong>
      On the **Member page** (after logging in as a Member), search for sample items (“Phone Charger,” “HDMI Cable,” “Electric Drill”),
      click <em>Add to Cart</em> on several, pick return dates, and click <em>Checkout</em>.</li>
    <li><strong>Staff functions:</strong>
      Click the **Staff Page** link or go directly to the **Staff page**, log in as the initial staff account
      (<em>TA / Cse445!</em>), then test user management, item management,
      and mark borrowed items as returned.</li>
  </ol>
</div>
";

                // Creating a DataTable to store service directory
                var dt = new DataTable();
                dt.Columns.Add("Provider");
                dt.Columns.Add("Type");
                dt.Columns.Add("Operation");
                dt.Columns.Add("Params");
                dt.Columns.Add("Return");
                dt.Columns.Add("TryItUrl");

                // Presentation
                dt.Rows.Add(
                    "Team (Darsh, Aditya & Dhyey)",
                    "ASPX – Default.aspx",
                    "Landing page + Service Directory + Theme toggle",
                    "none",
                    "void",
                    "Default.aspx"
                );
                dt.Rows.Add(
                    "Team (Darsh, Aditya & Dhyey)",
                    "MasterPage – Site.master",
                    "Common layout + role‐based menu",
                    "none",
                    "void",
                    ""
                );

                // Global.asax
                dt.Rows.Add(
                    "Aditya Singh",
                    "Global.asax",
                    "Application_BeginRequest, Application_Error, Session_Start",
                    "none",
                    "void",
                    ""
                );

                // Session‐state
                dt.Rows.Add(
                    "Aditya Singh",
                    "Session State – Theme",
                    "Store/retrieve user theme (light/dark)",
                    "string theme",
                    "void",
                    ""
                );
                dt.Rows.Add(
                    "Darsh Chaurasia",
                    "Session State – Cart",
                    "Store/retrieve List<Item> cart",
                    "List<Item>",
                    "void",
                    "Cart.aspx"
                );

                // Cookies
                dt.Rows.Add(
                    "Dhyey Sanghvi",
                    "Cookie – RememberMe",
                    "Persist username for 7 days",
                    "string username",
                    "void",
                    "TryIt_Login.aspx"
                );

                // Captcha handler
                dt.Rows.Add(
                    "Darsh Chaurasia",
                    "HTTP Handler – Captcha.ashx",
                    "Generate 5‐char CAPTCHA image; store code in Session",
                    "none",
                    "image/png",
                    ""
                );

                // DLL library
                dt.Rows.Add(
                    "Darsh Chaurasia",
                    "DLL – FeeCalcLibrary",
                    "ComputeLateFee (daysLate → decimal fee)",
                    "int daysLate",
                    "decimal",
                    "TryIt_Loan.aspx"
                );
                dt.Rows.Add(
                    "Darsh Chaurasia",
                    "DLL – FeeCalcLibrary",
                    "HashPassword (SHA‐256 hash)",
                    "string password",
                    "string",
                    "TryIt_Loan.aspx"
                );

                // Auth helper + XML store
                dt.Rows.Add(
                    "Dhyey Sanghvi",
                    "Helper – AuthHelper.cs",
                    "Register / Validate / Promote / Demote / Delete users in Accounts.xml",
                    "string username[, string password]",
                    "bool / void",
                    ""
                );
                dt.Rows.Add(
                    "Darsh Chaurasia",
                    "XML – Accounts.xml",
                    "Stores <User name pwdHash role lastLogin/>",
                    "none",
                    "file",
                    ""
                );

                // User controls & pages
                dt.Rows.Add(
                    "Dhyey Sanghvi",
                    "UserControl – LoginPanel.ascx",
                    "Login form + Captcha + Remember Me",
                    "username, password, captcha",
                    "void",
                    "TryIt_Login.aspx"
                );
                dt.Rows.Add(
                    "Aditya Singh",
                    "ASPX – Register.aspx",
                    "Self‐registration with Captcha",
                    "username, password, captcha",
                    "bool (success)",
                    "Register.aspx"
                );

                // WCF services
                dt.Rows.Add(
                    "Aditya Singh",
                    "WCF – ScheduleService.svc",
                    "NextReturnDate (now + 3 days Demo)",
                    "string itemID",
                    "DateTime",
                    "TryIt_Schedule.aspx"
                );
                dt.Rows.Add(
                    "Darsh Chaurasia",
                    "WCF – LoanService.svc",
                    "FeeCalc (late fee calculation)",
                    "int daysLate",
                    "decimal",
                    "TryIt_Loan.aspx"
                );
                dt.Rows.Add(
                    "Dhyey Sanghvi",
                    "WCF – SearchService.svc",
                    "ItemSearch (keyword → Item[])",
                    "string keyword",
                    "Item[]",
                    "TryIt_Search.aspx"
                );

                // Data repository + XML store
                dt.Rows.Add(
                    "Dhyey SanghvI",
                    "Model – ItemRepository.cs",
                    "CRUD on Items.xml",
                    "Item model / id / name",
                    "List<Item> / void",
                    ""
                );
                dt.Rows.Add(
                    "Aditya Singh",
                    "XML – Items.xml",
                    "Stores <Item><Id/><Name/><IsBorrowed/><BorrowedBy/><DueDate/></Item>",
                    "none",
                    "file",
                    ""
                );

                // Member features
                dt.Rows.Add(
                    "Team (Darsh, Aditya & Dhyey)",
                    "ASPX – Member.aspx",
                    "Search, Add to Cart, View/Return Borrowed Items",
                    "string keyword",
                    "void",
                    "Member.aspx"
                );

                // Cart/Checkout
                dt.Rows.Add(
                    "Team (Darsh, Aditya & Dhyey)",
                    "ASPX – Cart.aspx",
                    "Review cart + set due dates + Checkout",
                    "none",
                    "void",
                    "Cart.aspx"
                );

                // Staff features
                dt.Rows.Add(
                    "Team (Darsh, Aditya & Dhyey)",
                    "ASPX – Staff.aspx",
                    "Manage users, items, borrowed items",
                    "various",
                    "void",
                    "Staff.aspx"
                );
                // Binding the DataTable to the GridView for display
                gvServices.DataSource = dt;
                gvServices.DataBind();
            }
        }

        // Redirecting to the login page on button click
        protected void btnLogin_Click(object s, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}