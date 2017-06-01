<%@ Page Title="" Language="C#" MasterPageFile="~/UserLayerPages/MasterPages/BetterMenu.Master" AutoEventWireup="true" CodeBehind="Challenge.aspx.cs" Inherits="BETTER.Pages.Challenge" %>

<asp:Content ID="pageName" ContentPlaceHolderID="pageName" runat="server">  
    <%-- Top of Page Title --%>
    B.E.T.T.E.R Elemental Battle Arena
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Challenge!!</title>

    <%-- span has red font shadow (VS)--%>
    <style>
        span.shadow {
             font-size:60px; 
             justify-content:center;
             color:red; 
             text-shadow: 2px 2px #000000;
        }
       
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="rightcolumn">

        <%-- Champion Slection Process --%>
        <div runat="server" id="ChampSelection">
        <h2>Choose your Elemental!</h2>

        <%--List of active champs that you can select: Image, Name, Element and Level are displayed --%>
            <asp:ListView runat="server" ID="lvActiveTitans" DataSourceID="GetActiveTitanListByUserName" OnItemCommand="lvActiveTitanList_ItemCommand">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="groupPlaceHolder" runat="server"></asp:PlaceHolder>
                    </LayoutTemplate>
                    <GroupTemplate>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </GroupTemplate>
                    <ItemTemplate>
                        <ul style="list-style-type: none">
                            <li>
                                <asp:ImageButton ID="imgBtnTitan" runat="server" AlternateText="Elemental" ImageUrl='<%#Eval("imagePath") %>' CssClass="elements" Style="vertical-align: middle" CommandName="Selected"/>
                                <asp:Label ID="lblActiveTitanName" runat="server" Text='<%#Eval("titanName") %>' />
                            </li>
                            <li>&nbsp;</li>
                        </ul>
                    </ItemTemplate>
                </asp:ListView>
                <asp:ObjectDataSource ID="GetActiveTitanListByUserName" runat="server" SelectMethod="GetActiveTitansByUserName" TypeName="BETTER.BusinessLayer.Classes.TitanManager">
                    <SelectParameters>
                        <asp:SessionParameter Name="userName" SessionField="UserName" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
        </div>

        <%-- text that appears when enemy chosen--%>
            <h2 runat="server" id="h2Fight" visible="false">Are you ready?</h2>

        <%-- Enemy Selection Process. Not visible on page load. Appears after Champ Selection --%>
        <div runat="server" id="EnemySelection" visible="false">
            <h2 runat="server" id="h2Choose">Choose an enemy to fight!</h2>

            

            <%-- Chosen Elemental Information floats to the left: Displayed information includes UserName, ChampImage, ChampName, 
            ChampElement, ChampLevel, ChampStep, ChampXP, ChampWins, and ChampLosses --%>
            <div style="float: left; margin-left: 15%;">
                <h3>Selected Elemental</h3>
                <table>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblUserName" Text="UserID" Style="font-weight: bold;" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image runat="server" ID="imgSelectedChamp" ImageUrl="~/Images/air.png" AlternateText="SelectedChamp" CssClass="elements" /></td>
                    </tr>
                    <tr>
                        <td>Name: &nbsp;
                            <asp:Label runat="server" ID="lblChampName" />
                        </td>
                    </tr>
                    <tr>
                        <td>Element: &nbsp;
                        <asp:Label runat="server" ID="lblChampElement" />
                        </td>
                    </tr>
                    <tr>
                        <td>Level: &nbsp;
                            <asp:Label runat="server" ID="lblChampLevel" />
                        </td>
                    </tr>
                    <tr>
                        <td>Step:&nbsp;
                            <asp:Label runat="server" ID="lblChampStep"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>XP:&nbsp;
                            <asp:Label runat="server" ID="lblChampXP"/>&nbsp;/&nbsp;
                            <asp:Label runat="server" ID="lblChampRemainingXP" />
                        </td>
                    </tr>
                    <tr>
                        <td>Wins:&nbsp;
                            <asp:Label runat="server" ID="lblChampWins" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Losses:&nbsp;
                            <asp:Label runat="server" ID="lblChampLosses" ></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>

            <%-- Versus symbol/text that appears between chosen champion and chosen enemy champion. Appears after selection process--%>
            <span runat="server" id="textVS" class="shadow" visible="false">VS</span>

            <%-- List of available enemy elementals to challenge. Information displayed includes:
                ChampImage, Enemy Username, Enemy ChampName, Enemy ChampElement, and Enemy ChampLevel --%>
            <div style="float: right; margin-right: 10%">
                <div runat="server" id="enemyElementalList">
                    <h3>Enemy Elementals</h3>
                    <ul style="list-style-type: none">
                        <asp:ListView runat="server" ID="lvEnemyTitans" DataSourceID="GetEnemyList" OnItemCommand="lvEnemyTitanList_ItemCommand">
                            <LayoutTemplate>
                                <asp:PlaceHolder ID="groupPlaceHolder" runat="server"></asp:PlaceHolder>
                            </LayoutTemplate>
                            <GroupTemplate>
                                <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                            </GroupTemplate>
                            <ItemTemplate>
                                <li>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:ImageButton runat="server" ID="imgBtnEnemy" ImageUrl='<%#Eval("imagePath") %>' AlternateText="enemy1" CssClass="elements" CommandName="Selected"/>
                                            </td>
                                            <td>User Name:&nbsp;
                                <asp:Label runat="server" ID="lblEnemyID" Text='<%#Eval("userName") %>' />
                                                <br />
                                                Elemental Name:&nbsp;
                                <asp:Label runat="server" ID="lblEnemyChampName" Text='<%#Eval("titanName") %>' />
                                                <br />
                                                Element:&nbsp;
                                <asp:Label runat="server" ID="lblEnemyChampElement" Text='<%#Eval("elementName") %>' />
                                                <br />
                                                Level:&nbsp;
                                <asp:Label runat="server" ID="lblEnemyChampLevel" Text='<%#Eval("lvl") %>' />
                                                Step:&nbsp;
                                <asp:Label runat="server" ID="lblEnemyChampStep" Text='<%#Eval("step") %>' />
                                            </td>
                                        </tr>
                                    </table>
                                </li>
                            </ItemTemplate>
                        </asp:ListView>
                        <asp:ObjectDataSource runat="server" ID="GetEnemyList" SelectMethod="GetEnemyTitans" TypeName="BETTER.BusinessLayer.Classes.TitanManager">
                            <SelectParameters>
                                <asp:SessionParameter SessionField="UserName" Name="userName" Type="String"></asp:SessionParameter>
                                <asp:SessionParameter SessionField="ChallengeSelectedTitan" Name="titanName" Type="String"></asp:SessionParameter>
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        </ul>
                    </div>
                </div>

                <%-- display enemy champ information once chosen. Displayed information is the same as chosen champ. --%>
                <div runat="server" id="enemyElemental" visible="false" style="float:right; margin-right: 10%">
                    <h3>Selected Enemy Elemental</h3>
                    <table>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblEnemyUserName" Style="font-weight: bold;" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Image runat="server" ID="imgSelectedEnemyChamp" AlternateText="SelectedEnemyChamp" CssClass="elements" /></td>
                        </tr>
                        <tr>
                            <td>Name: &nbsp;
                            <asp:Label runat="server" ID="lblEnemyChampName" />
                            </td>
                        </tr>
                        <tr>
                            <td>Element: &nbsp;
                        <asp:Label runat="server" ID="lblEnemyChampElement" />
                            </td>
                        </tr>
                        <tr>
                            <td>Level: &nbsp;
                            <asp:Label runat="server" ID="lblEnemyChampLevel" />
                            </td>
                        </tr>
                        <tr>
                            <td>Step:&nbsp;
                            <asp:Label runat="server" ID="lblEnemyChampStep"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>XP:&nbsp;
                            <asp:Label runat="server" ID="lblEnemyChampXP" />&nbsp;/&nbsp;
                            <asp:Label runat="server" ID="lblEnemyChampXPRemaining" />
                            </td>
                        </tr>
                        <tr>
                            <td>Wins:&nbsp;
                            <asp:Label runat="server" ID="lblEnemyChampWins" />
                            </td>
                        </tr>
                        <tr>
                            <td>Losses:&nbsp;
                            <asp:Label runat="server" ID="lblEnemyChampLosses" />
                            </td>
                        </tr>
                    </table>
                </div>
            <br />
            <br />

            <%-- 2 buttons. A fight button leading to the fight outcome page and a cancel fight button leading to the start of the challenge page. --%>
            <asp:Button runat="server" ID="btnFight" Text="FIGHT!!" CssClass="button" Style="vertical-align: bottom; align-content: center;" Visible="false" OnClick="btnFight_Click" />
            <asp:Button runat="server" ID="btnCancelFight" Text="Cancel Fight" CssClass="button" Style="vertical-align: bottom; align-content: center;" Visible="false" OnClick="btnCancelFight_Click" />
        
        </div>
    </main>
</asp:Content>
