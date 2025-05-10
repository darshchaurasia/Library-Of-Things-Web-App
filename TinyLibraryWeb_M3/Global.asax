<%@ Application Language="C#" %>
<script runat="server">
    // Custom header
    void Application_BeginRequest(object sender, EventArgs e)
    {
        Response.AddHeader("X-App-Name", "LibraryOfThings");
    }
    // Handling application errors and logging them to an XML file
    void Application_Error(object sender, EventArgs e)
    {
        // Retrieving the last error that occurred
        Exception ex = Server.GetLastError();
        string logPath = Server.MapPath("~/App_Data/ErrorLog.xml");

        // Loading the existing error log or creating a new one if it doesn't exist
        var xdoc = System.IO.File.Exists(logPath)
            ? System.Xml.Linq.XDocument.Load(logPath)
            : new System.Xml.Linq.XDocument(new System.Xml.Linq.XElement("Errors"));

        // Adding a new error entry with timestamp, message, and stack trace
        xdoc.Root.Add(new System.Xml.Linq.XElement("Error",
            new System.Xml.Linq.XElement("Time", DateTime.Now.ToString()),
            new System.Xml.Linq.XElement("Message", ex.Message),
            new System.Xml.Linq.XElement("StackTrace", ex.StackTrace)
        ));
        // Saving the updated error log to the file
        xdoc.Save(logPath);
    }

    // Initializing a new session with a default theme
    void Session_Start(object sender, EventArgs e)
    {
        Session["Theme"] = "light";
    }
</script>
