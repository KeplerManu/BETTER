<%@ Page Title="" Language="C#" MasterPageFile="~/UserLayerPages/MasterPages/BetterMenu.Master" AutoEventWireup="true" CodeBehind="HallOfFame.aspx.cs" Inherits="BETTER.Pages.HallOfFame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Hall of Fame</title>
    <style>
        /*Special border for hall of fame elementals*/
        .hof{
            height:200px;
            width:200px;
            border: solid;
            border-width: 5px;
            border-top-color:darkseagreen;
            border-bottom-color:deepskyblue;
            border-left-color:red;
            border-right-color:mediumslateblue
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="pageName" runat="server">
    <%-- top of page title --%>
    Hall of Fame
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="rightcolumn">
        <ul>
            <li class="content">
                <%-- red bordered content --%>
                <%-- centered content --%>
                <div style="text-align: center; width: 40%; margin: auto">
                    <%-- List of hall of fame entries. included information:
                        UserName (optional), ElementalName, BattleFought, Wins, Losses, DateCreated --%>
                    <ul style="list-style-type: none">
                        <%--Hall of fame entry 1--%>
                        <li>
                            <table>
                                <tr>
                                    <td><b>User Name:&nbsp;
                        <asp:Label ID="lblUserName1" runat="server">Anonymous</asp:Label>
                                    </b></td>
                                </tr>
                                <tr>
                                    <td>
                                        <%-- hall of fame images have special border and increased size --%>
                                        <asp:Image runat="server" ImageUrl="~/Images/earth.png" ID="imgHallOfFame1" AlternateText="HoFChamp1" CssClass="hof" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Elemental Name:&nbsp;
                        <em><asp:Label ID="lblElementalName1" runat="server">Hall of Fame Champ1</asp:Label></em>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Battles Fought:&nbsp;
                        <asp:Label ID="lblBattles1" runat="server">1000</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Wins:&nbsp;
                        <asp:Label ID="lblWins1" runat="server">800</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Losses:&nbsp;
                        <asp:Label ID="lblLosses1" runat="server">200</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Created:&nbsp;
                        <asp:Label ID="lblDateCreated1" runat="server">07/07/2016</asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </li>

                        <li>&nbsp;</li> <%-- list break --%>

                        <%--Hall of fame entry 2 --%>
                        <li>
                            <table>
                                <tr>
                                    <td><b>User Name:&nbsp;
                        <asp:Label ID="lblUserName2" runat="server">Kepler</asp:Label>
                                    </b></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Image runat="server" ImageUrl="~/Images/fire.png" ID="imgHallOfFame2" AlternateText="HoFChamp2" CssClass="hof" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Elemental Name:&nbsp;
                        <em><asp:Label ID="lblElementalName2" runat="server">Hall of Fame Champ2</asp:Label>
                                    </em></td>
                                </tr>
                                <tr>
                                    <td>Battles Fought:&nbsp;
                        <asp:Label ID="lblBattles2" runat="server">1300</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Wins:&nbsp;
                        <asp:Label ID="lblWins2" runat="server">900</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Losses:&nbsp;
                        <asp:Label ID="lblLosses3" runat="server">400</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Created:&nbsp;
                        <asp:Label ID="lblDateCreated2" runat="server">07/07/2016</asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </li>
                    </ul>
                </div>

            </li>
        </ul>

    </main>
</asp:Content>
