<%@ Page Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="TinyLibraryWeb_M3.Default" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

  <asp:Literal ID="litIntro" runat="server" />

  <p>
    <asp:Button ID="btnLogin" runat="server"
        Text="Login Here!" OnClick="btnLogin_Click" />
  </p>

  <h3>Service Directory</h3>
  <asp:GridView ID="gvServices" runat="server"
      AutoGenerateColumns="False">
    <Columns>
      <asp:BoundField DataField="Provider" HeaderText="Provider" />
      <asp:BoundField DataField="Type"     HeaderText="Component Type" />
      <asp:BoundField DataField="Operation" HeaderText="Operation" />
      <asp:BoundField DataField="Params"   HeaderText="Parameters" />
      <asp:BoundField DataField="Return"   HeaderText="Return Type" />
      <asp:TemplateField HeaderText="TryIt">
        <ItemTemplate>
          <asp:HyperLink ID="hlTryIt" runat="server"
              NavigateUrl='<%# Eval("TryItUrl") %>'
              Text="TryIt"
              Visible='<%# !String.IsNullOrEmpty(Eval("TryItUrl") as string) %>' />
        </ItemTemplate>
      </asp:TemplateField>
    </Columns>
  </asp:GridView>
</asp:Content>
