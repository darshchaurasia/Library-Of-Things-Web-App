<%@ Page Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true"
    CodeBehind="TryIt_Cart.aspx.cs"
    Inherits="TinyLibraryWeb_M3.TryIt_Cart" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="title" runat="server">
    TryIt – Session Cart
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Add Item to Cart (Session)</h2>
    ID: <asp:TextBox ID="txtId" runat="server" />
    Name: <asp:TextBox ID="txtName" runat="server" />
    <asp:Button ID="btnAdd" runat="server"
        Text="Add to Cart"
        OnClick="btnAdd_Click" />

    <hr />
    <h3>Cart Contents:</h3>
    <asp:GridView ID="gvCart" runat="server"
        AutoGenerateColumns="true" />

    <p>
      <asp:HyperLink ID="hlBack" runat="server"
          NavigateUrl="Default.aspx">
        ← Back to Home
      </asp:HyperLink>
    </p>
</asp:Content>
