<%@ Page Title="" Language="C#" MasterPageFile="~/UserLayerPages/MasterPages/BetterMenu.Master" AutoEventWireup="true" CodeBehind="FightSummary.aspx.cs" Inherits="BETTER.Pages.FightSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Fight Summary</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="pageName" runat="server">
    B.E.T.T.E.R Fight Summaries
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="rightcolumn">
        <div style="float:left; margin-left:5%">
        <h2>Your Elementals</h2>
        <p>Click an Elemental to view its Match History</p>
            <%-- list of all created elementals. Displayed information includes ChampImage and ChampName --%>
            <asp:ListView runat="server" ID="lvAvailableTitanList" DataSourceID="GetTitanListByUserName" OnItemCommand="lvAvailableTitanList_ItemCommand">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="groupPlaceHolder" runat="server"></asp:PlaceHolder>
                    </LayoutTemplate>
                    <GroupTemplate>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </GroupTemplate>
                    <ItemTemplate>
                        <ul style="list-style-type: none">
                            <li>
                                <asp:ImageButton ID="imgBtnElement" runat="server" AlternateText="ElementPicture" ImageUrl='<%#Eval("imagePath") %>' CssClass="elements" Style="float: left; vertical-align: middle" CommandName="Selected" />
                                <table style="text-align: left">
                                    <tr>
                                        <td>
                                            Name: <asp:Label ID="lblTitanName" runat="server" Text='<%#Eval("titanName") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                        Level: <asp:Label ID="lblTitanLevel" runat="server" Text='<%#Eval("lvl") %>' /></td>
                                    </tr>
                                </table>
                                <br /><br /><br />
                            </li>
                        </ul>
                    </ItemTemplate>
                </asp:ListView>
                <asp:ObjectDataSource ID="GetTitanListByUserName" runat="server" SelectMethod="GetTitansByUserName" TypeName="BETTER.BusinessLayer.Classes.TitanManager">
                    <SelectParameters>
                        <asp:SessionParameter Name="userName" SessionField="UserName" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
        </div>

        <div style="float: right; margin-right: 5%;">
            <h2 style="text-align: center">Match History</h2>
            <%-- invible match history. appears once an elemental has been selected. 
                currently only name and image of user's champion changes in match history--%>
            <asp:Label runat="server" ID="lblChampName" Visible="false" Style="font-weight: bold" />
            <div runat="server" id="enemyElemental" visible="false">
                <asp:ListView runat="server" ID="lvMatchHistoryTitanList" DataSourceID="GetMatchHistoryList"  OnItemDataBound=" lvMatchHistoryTitanList_DataBound">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="groupPlaceHolder" runat="server"></asp:PlaceHolder>
                    </LayoutTemplate>
                    <GroupTemplate>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </GroupTemplate>
                    <ItemTemplate>
                    <ul style="list-style-type: none">
                        <li>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Image ImageUrl="~/Images/air.png" runat="server" ID="imgSelectedChamp" CssClass="elements"/>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblOutcome1" Visible="false">WIN</asp:Label>
                                        <asp:Label runat="server" ID="lblOutcome2" Visible="false">LOSE</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Image runat="server" ID="imgEnemy" ImageUrl='<%#Eval("imagePath") %>' AlternateText="enemy1" CssClass="elements" />
                                    </td>
                                    <td>User Name:&nbsp;
                                <asp:Label runat="server" ID="lblEnemyUserName" Text='<%#Eval("userName") %>' />
                                        <br />
                                        Elemental Name:&nbsp;
                                <asp:Label runat="server" ID="lblEnemyChampName" Text='<%#Eval("titanName") %>' />
                                        <br />
                                        Element:&nbsp;
                                <asp:Label runat="server" ID="lblEnemyChampElement" Text='<%#Eval("elementName") %>' />
                                        
                                        <%--hidden sneaky id label lmao because don't know how to call these variable in behind page if not on front page lmao--%>
                                        <asp:Label runat="server" ID="lblBattler1ID" Text='<%#Eval("battler1") %>' Visible="false" />
                                        <asp:Label runat="server" ID="lblBattler2ID" Text='<%#Eval("battler2") %>' Visible="false" />
                                        <asp:Label runat="server" ID="lblBattleWinner" Text='<%#Eval("battleWinner") %>' Visible="false" />
                                    </td>
                                </tr>
                            </table>
                        </li>
                        </ul>
                    </ItemTemplate>
                </asp:ListView>
                <asp:ObjectDataSource runat="server" ID="GetMatchHistoryList" SelectMethod="MatchHistoryTitanList" TypeName="BETTER.DataAccessLayer.Classes.TitanDAL">
                    <SelectParameters>
                        <asp:SessionParameter SessionField="UserName" Name="userName" Type="String"></asp:SessionParameter>
                        <asp:SessionParameter SessionField="MatchHistorySelect" Name="titanName" Type="String"></asp:SessionParameter>
                        <asp:SessionParameter SessionField="MatchHistorySelectID" Name="titanID" Type="String"></asp:SessionParameter>
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
        

    </main>
</asp:Content>
