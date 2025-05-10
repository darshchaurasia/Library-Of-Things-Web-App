<%@ Page Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true"
    CodeBehind="Login.aspx.cs"
    Inherits="TinyLibraryWeb_M3.Login" %>
<%@ Register Src="~/Controls/LoginPanel.ascx" TagPrefix="uc" TagName="LoginPanel" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="title" runat="server">
    Login
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc:LoginPanel ID="LoginPanel1" runat="server"
        OnLoginSuccess="LoginSuccess" />
    <hr />
    <asp:HyperLink ID="hlRegister" runat="server" NavigateUrl="Register.aspx">
      Need an account? Register here
    </asp:HyperLink>
    <br>
    <br>
    <asp:HyperLink ID="hlBack" runat="server" NavigateUrl="Default.aspx">
  ← Back to Home
</asp:HyperLink>
</asp:Content>
