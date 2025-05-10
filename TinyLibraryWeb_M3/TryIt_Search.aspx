<%@ Page Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true"
    CodeBehind="TryIt_Search.aspx.cs"
    Inherits="TinyLibraryWeb_M3.TryIt_Search" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="title" runat="server">
    TryIt – SearchService
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>Try looking up sample items: "Phone Charger", "HDMI Cable" & "Electric Drill"</p>
    <h2>Search Items</h2>
    <asp:TextBox ID="txtKeyword" runat="server" Width="200px" />
    <asp:Button ID="btnSearch" runat="server"
        Text="Search"
        OnClick="btnSearch_Click" />
    <br /><br />
    <asp:Label ID="lblSearchMessage" runat="server" ForeColor="Red" />
    <br /><br />
    <asp:GridView ID="gvResults" runat="server"
        AutoGenerateColumns="false">
      <Columns>
        <asp:BoundField DataField="Id"         HeaderText="ID" />
        <asp:BoundField DataField="Name"       HeaderText="Name" />
        <asp:BoundField DataField="IsBorrowed" HeaderText="Borrowed?" />
      </Columns>
    </asp:GridView>
    <p>
      <asp:HyperLink ID="hlBack" runat="server"
          NavigateUrl="Default.aspx">
        ← Back to Home
      </asp:HyperLink>
    </p>
</asp:Content>
