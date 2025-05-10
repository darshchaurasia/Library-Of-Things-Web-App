<%@ Page Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true"
    CodeBehind="Member.aspx.cs"
    Inherits="TinyLibraryWeb_M3.Member" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="title" runat="server">
    Member Dashboard
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Welcome, <asp:Literal ID="litUser" runat="server" /></h2>

    <asp:Button ID="btnLogout" runat="server"
        Text="Logout"
        OnClick="btnLogout_Click" />

    <asp:Button ID="btnCart" runat="server"
        Text="Cart (0)"
        OnClick="btnCart_Click"
        Style="float:right;" />

    <hr />

    Search: <asp:TextBox ID="txtSearch" runat="server" />
    <asp:Button ID="btnSearch" runat="server"
        Text="Go"
        OnClick="btnSearch_Click" />
    <asp:Label ID="lblMsg" runat="server"
        ForeColor="Red" />

    <br /><br />

    <asp:GridView ID="gvItems" runat="server"
        DataKeyNames="Id" AutoGenerateColumns="False" OnRowCommand="gvItems_RowCommand">
      <Columns>
        <asp:BoundField DataField="Id"         HeaderText="ID" />
        <asp:BoundField DataField="Name"       HeaderText="Name" />
        <asp:BoundField DataField="StatusText" HeaderText="Status" />

        <asp:ButtonField Text="Add to Cart" CommandName="act" />
      </Columns>
    </asp:GridView>

    <hr />
    <h3>My Borrowed Items</h3>
    <asp:GridView ID="gvMy" runat="server"
        DataKeyNames="Id" AutoGenerateColumns="False"
        OnRowCommand="gvMy_RowCommand">
      <Columns>
        <asp:BoundField DataField="Id"       HeaderText="ID" />
        <asp:BoundField DataField="Name"     HeaderText="Name" />
        <asp:BoundField DataField="DueDate"  HeaderText="Due Date" />
        <asp:BoundField DataField="DaysLate" HeaderText="Days Late" />
        <asp:BoundField DataField="LateFee"  HeaderText="Late Fee" />
        <asp:ButtonField Text="Return" CommandName="ret" />
      </Columns>
    </asp:GridView>
</asp:Content>
