<%@ Page Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true"
    CodeBehind="TryIt_Loan.aspx.cs"
    Inherits="TinyLibraryWeb_M3.TryIt_Loan" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="title" runat="server">
    TryIt – LoanService
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Test Late Fee Calculation (via LoanService)</h2>
    <label>Days Late:</label>
    <asp:TextBox ID="txtDaysLate" runat="server" />
    <asp:Button ID="btnCalcFee" runat="server"
        Text="Compute Fee"
        OnClick="btnCalcFee_Click" />
    <br /><br />
    <asp:Label ID="lblResult" runat="server"
        ForeColor="Blue" Font-Bold="true" />
    <hr />

    <h2>Test Password Hash (using FeeCalcLibrary directly)</h2>
    <label>Password:</label>
    <asp:TextBox ID="txtPassword" runat="server"
        TextMode="Password" />
    <asp:Button ID="btnHash" runat="server"
        Text="Hash Password"
        OnClick="btnHash_Click" />
    <br /><br />
    <asp:Label ID="lblHashResult" runat="server"
        ForeColor="Green" />
    <hr />

    <asp:HyperLink ID="hlBack" runat="server"
        NavigateUrl="Default.aspx">
      ← Back to Home
    </asp:HyperLink>
</asp:Content>
