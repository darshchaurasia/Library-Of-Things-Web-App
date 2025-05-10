<%@ Page Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true"
    CodeBehind="TryIt_Login.aspx.cs"
    Inherits="TinyLibraryWeb_M3.TryIt_Login" %>
<%@ Register Src="~/Controls/LoginPanel.ascx" TagPrefix="uc" TagName="LoginPanel" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="title" runat="server">
    TryIt – LoginPanel
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <p style="color:gray; font-size:14px;">
        <em>
            Note: This login test is for Assignment 5. Authentication is mocked with a demo user only.<br />
            Use <strong>username:</strong> TA and <strong>password:</strong> Cse445! Any other input will show an error.
        </em>
    </p>

    <uc:LoginPanel ID="LoginPanel1" runat="server"
        OnLoginSuccess="LoginPanel1_LoginSuccess" />
    <br />
    <asp:Label ID="lblStatus" runat="server" ForeColor="Green" />

    <asp:HyperLink ID="hlBack" runat="server"
        NavigateUrl="Default.aspx">
      ← Back to Home
    </asp:HyperLink>
</asp:Content>
