<%@ Page Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true"
    CodeBehind="Register.aspx.cs"
    Inherits="TinyLibraryWeb_M3.Register" %>
<%@ Register Src="~/Controls/LoginPanel.ascx" TagPrefix="uc" TagName="CaptchaBox" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="title" runat="server">
    Register
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Create Account</h2>
    Username:<asp:TextBox ID="txtUser" runat="server" /><br />
    Password:<asp:TextBox ID="txtPwd" runat="server" TextMode="Password" /><br />
    Confirm :<asp:TextBox ID="txtPwd2" runat="server" TextMode="Password" /><br />
    Captcha:<img src="Handlers/Captcha.ashx" alt="Captcha" />
            <asp:TextBox ID="txtCap" runat="server" /><br />
    <asp:Button ID="btnReg" runat="server" Text="Register" OnClick="btnReg_Click" /><br /><br />
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" /><br />
    <asp:HyperLink ID="hlBack" runat="server" NavigateUrl="Login.aspx">
      ← Back to Login
    </asp:HyperLink>
</asp:Content>
