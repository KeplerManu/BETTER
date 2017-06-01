<%@ Page Title="Test" Language="C#" MasterPageFile="~/UserLayerPages/MasterPages/BetterMenu.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="BETTER.Pages.MainMenu" %>
<asp:Content ID="pageName" ContentPlaceHolderID="pageName" runat="server">
    B.E.T.T.E.R Main Menu
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>BETTER Main Menu</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="rightcolumn">
        <div>
            <br />
            <h2>Battle Elemental Titans Through Exercising Routines</h2>

            <p style="align-content: center; font-weight:bold">
                Welcome&nbsp;
                <asp:Label ID="lblUserID" runat="server" />
            </p>

            <ul>
                <%--Table with link buttons to each page stemming from Main Menu--%>
                <li class="content">
                    <h3 style="text-align: center">Main Menu</h3>
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <asp:Button ID="btnChallenge" runat="server" Text="Challenge!!" CssClass="button" OnClick="btnChallenge_Click"  />
                            </td>
                            <td>
                                <asp:Button ID="btnCharacterSelect" runat="server" OnClick="btnCharacterSelect_Click" Text="Character Selection" CssClass="button" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnFightSummary" runat="server" Text="Fight Summary" CssClass="button" OnClick="btnFightSummary_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnCharacterManage" runat="server" Text="Character Management" CssClass="button" OnClick="btnCharacterManage_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnUploadExercise" runat="server" Text="Upload Exercise" CssClass="button" OnClick="btnUploadExercise_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnHOF" runat="server" Text="Hall of Fame" CssClass="button" OnClick="btnHOF_Click" />
                            </td>
                        </tr>
                    </table>
                </li>

                <%--Table of Active Elements. Included information: ChampImage, ChampName--%>
                <li class="content">
                    <h3 style="text-align: center">Active Elementals</h3>
                    <table class="center-justified">
                        <tr>
                            <asp:ListView runat="server" ID="lvActiveTitans" DataSourceID="GetActiveTitanListByUserName">
                                <LayoutTemplate>
                                    <asp:PlaceHolder ID="groupPlaceHolder" runat="server"></asp:PlaceHolder>
                                </LayoutTemplate>
                                <GroupTemplate>
                                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                                </GroupTemplate>
                                <ItemTemplate>
                                    <td style="text-align: center">
                                        <asp:Image ID="imgTitan" runat="server" AlternateText="Titan" ImageUrl='<%#Eval("imagePath") %>' CssClass="elements" Style="vertical-align: middle" />
                                    </td>
                                    <td>&nbsp;&nbsp;&nbsp;
                                    </td>

                                    <td style="text-align: center">
                                        <asp:Label ID="lblTitanName" runat="server" Text='<%#Eval("titanName") %>' /></td>
                                    <td>&nbsp;&nbsp;&nbsp;
                                    </td>
                                </ItemTemplate>
                            </asp:ListView>
                            <asp:ObjectDataSource ID="GetActiveTitanListByUserName" runat="server" SelectMethod="GetActiveTitansByUserName" TypeName="BETTER.BusinessLayer.Classes.TitanManager">
                                <SelectParameters>
                                    <asp:SessionParameter Name="userName" SessionField="UserName" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </tr> 
                    </table>
                </li>
            </ul>
            <p style="text-align: center"><a href="#top">Return to Top</a></p>
        </div>
    </main>
</asp:Content>
