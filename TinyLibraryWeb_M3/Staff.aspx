<%@ Page Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true"
    CodeBehind="Staff.aspx.cs"
    Inherits="TinyLibraryWeb_M3.Staff" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="title" runat="server">
    Staff Dashboard
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
      .tabs a { margin-right:15px; }
    </style>

    <h2>Staff Dashboard – <asp:Literal ID="litUser" runat="server" /></h2>
    <asp:Button ID="btnLogout" runat="server"
        Text="Logout"
        OnClick="btnLogout_Click" />
    <hr />

    <div class="tabs">
      <asp:LinkButton ID="lnkUsers" runat="server"
          Text="User Mgmt"
          OnClick="ShowUsers" />

      <asp:LinkButton ID="lnkItems" runat="server"
          Text="Item Mgmt"
          OnClick="ShowItems" />

      <asp:LinkButton ID="lnkBorrowed" runat="server"
          Text="Borrowed"
          OnClick="ShowBorrowed" />
    </div>
    <hr />

    <asp:MultiView ID="mv" runat="server">
      <asp:View ID="vwUsers" runat="server">
        <h3>Users</h3>
        <asp:GridView ID="gvUsers" runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="Name"
            OnRowCommand="gvUsers_RowCommand">
          <Columns>
            <asp:BoundField DataField="Name"      HeaderText="Username" />
            <asp:BoundField DataField="Role"      HeaderText="Role" />
            <asp:BoundField DataField="LastLogin" HeaderText="Last Login" />
            <asp:ButtonField Text="Promote" CommandName="pro" />
            <asp:ButtonField Text="Demote"  CommandName="dem" />
            <asp:ButtonField Text="Delete"  CommandName="del" />
          </Columns>
        </asp:GridView>
      </asp:View>

      <asp:View ID="vwItems" runat="server">
        <h3>Add New Item</h3>
        Name:<asp:TextBox ID="txtNewItem" runat="server" />
        <asp:Button ID="btnAddItem" runat="server"
            Text="Add"
            OnClick="btnAddItem_Click" />
        <br /><br />

        <h3>All Items</h3>
        <asp:GridView ID="gvItems" runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="Id"
            OnRowCommand="gvItems_RowCommand">
          <Columns>
            <asp:BoundField DataField="Id"          HeaderText="ID" />
            <asp:BoundField DataField="Name"        HeaderText="Name" />
            <asp:BoundField DataField="IsBorrowed"  HeaderText="Borrowed?" />
            <asp:ButtonField Text="Delete" CommandName="del" />
          </Columns>
        </asp:GridView>
      </asp:View>

      <asp:View ID="vwBorrowed" runat="server">
        <h3>Borrowed Items</h3>
        <asp:GridView ID="gvBorrowed" runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="Id"
            OnRowCommand="gvBorrowed_RowCommand">
          <Columns>
            <asp:BoundField DataField="Id"         HeaderText="ID" />
            <asp:BoundField DataField="Name"       HeaderText="Name" />
            <asp:BoundField DataField="BorrowedBy" HeaderText="User" />
            <asp:BoundField DataField="DueDate"    HeaderText="Due" />
            <asp:BoundField DataField="LateFee"    HeaderText="Late Fee" />
            <asp:ButtonField Text="Mark Returned" CommandName="ret" />
          </Columns>
        </asp:GridView>
      </asp:View>
    </asp:MultiView>

    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />
</asp:Content>
