<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginPanel.ascx.cs" Inherits="TinyLibraryWeb_M3.Controls.LoginPanel" %>
<div>
    <h3>Login</h3>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />

    <br />Username:
    <asp:TextBox ID="txtUsername" runat="server" />

    <br />Password:
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />

    <br />Captcha:
    <img src="Handlers/Captcha.ashx" alt="Captcha" />
    <asp:TextBox ID="txtCaptcha" runat="server" />

    <br />
    <asp:CheckBox ID="chkRemember" runat="server" Text="Remember Me" />

    <br />
    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
</div>
