<%@ Page Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true"
    CodeBehind="Cart.aspx.cs"
    Inherits="TinyLibraryWeb_M3.Cart" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="title" runat="server">
    Cart
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Your Cart</h2>
    <asp:GridView ID="gvCart" runat="server"
        DataKeyNames="Id"
        AutoGenerateColumns="False">
      <Columns>
        <asp:BoundField DataField="Id"   HeaderText="ID" />
        <asp:BoundField DataField="Name" HeaderText="Name" />
        <asp:TemplateField HeaderText="Return Date">
          <ItemTemplate>
            <asp:TextBox ID="txtDue" runat="server"
                Text='<%# DateTime.Today.AddDays(7).ToString("yyyy-MM-dd") %>'
                TextMode="Date" />
          </ItemTemplate>
        </asp:TemplateField>
      </Columns>
    </asp:GridView>

    <p><em>Late fee is $0.25 per day after selected date.</em></p>

    <asp:Button ID="btnCheckout" runat="server"
        Text="Checkout"
        OnClick="btnCheckout_Click" />

    <asp:Button ID="btnCancel" runat="server"
        Text="Back"
        OnClick="btnCancel_Click" />

    <br />
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />
</asp:Content>
