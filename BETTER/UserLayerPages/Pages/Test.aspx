<%@ Page Title="" Language="C#" MasterPageFile="~/UserLayerPages/MasterPages/BetterMenu.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="BETTER.UserLayerPages.Pages.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageName" runat="server">
    <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource2">
    </asp:ListView>
    
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetTitansByUserID" TypeName="BETTER.BusinessLayer.Classes.TitanManager">
        <SelectParameters>
            <asp:SessionParameter Name="userID" SessionField="userID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

</asp:Content>
