<%@ Page Language="C#" 
    MasterPageFile="~/Site.master" 
    AutoEventWireup="true" 
    CodeBehind="TryIt_Schedule.aspx.cs" 
    Inherits="TinyLibraryWeb_M3.TryIt" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="title" runat="server">
    TryIt – ScheduleService
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Test ScheduleService.GetDueDate</h2>
    <p>
      <asp:Label ID="lblInstruction" runat="server" Text="Enter Item ID:" />
      <asp:TextBox ID="txtItemId" runat="server" />
      <asp:Button ID="btnTest" runat="server"
                  Text="Get Due Date"
                  OnClick="btnTest_Click" />
    </p>
    <p>
      <asp:Label ID="lblResult" runat="server" />
    </p>
    <p>
      <asp:HyperLink ID="hlBack" runat="server" NavigateUrl="Default.aspx">
        ← Back to Home
      </asp:HyperLink>
    </p>
</asp:Content>
