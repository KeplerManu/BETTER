<%@ Page Title="" Language="C#" MasterPageFile="~/UserLayerPages/MasterPages/BetterMenu.Master" AutoEventWireup="true" CodeBehind="FightOutcome.aspx.cs" Inherits="BETTER.Pages.FightOutcome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Fight Outcome</title>
    <style>
        /*text shadow for win/loss message*/
        .shadow {
             font-size:60px; 
             justify-content:center; 
             align-content: center;
             color:red; 
             text-shadow: 2px 2px #000000;
             margin-top: 50%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="pageName" runat="server">
    <%-- Top of page title --%>
    B.E.T.T.E.R Fight Results
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="rightcolumn">
        <div style="float: left; margin-left: 10%;">

            <%-- displays selected champ and all its information --%>
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="UserName" Text="UserID" Style="font-weight: bold;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Image runat="server" ID="imgSelectedChamp" AlternateText="SelectedChamp" CssClass="elements" /></td>
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
                            <asp:Label runat="server" ID="lblChampStep" />
                    </td>
                </tr>
                <tr>
                    <td>XP:&nbsp;
                            <asp:Label runat="server" ID="lblChampXP" />&nbsp;/&nbsp;
                            <asp:Label runat="server" ID="lblChampRemainingXP" />
                    </td>
                </tr>
                <tr>
                    <td>Wins:&nbsp;
                            <asp:Label runat="server" ID="lblChampWins" />
                    </td>
                </tr>
                <tr>
                    <td>Losses:&nbsp;
                            <asp:Label runat="server" ID="lblChampLosses" />
                    </td>
                </tr>
                
            </table>
        </div>

        <%-- Win label in middle of screen with text shadow for emphasis --%>
        <asp:Label runat="server" ID="lblWin" CssClass="shadow" Style="line-height: 300%" Visible="false">YOU WON</asp:Label>
        <asp:Label runat="server" ID="lblLose" CssClass="shadow" Style="line-height: 300%" Visible="false">YOU LOSE</asp:Label>
        <asp:Label runat="server" ID="lblDraw" CssClass="shadow" Style="line-height: 300%" Visible="false">YOU DRAW</asp:Label>


        <div style="float: right; margin-right: 10%">

            <%-- displays enemy champion versed and all its information --%>
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblEnemyUserName" Text="UserID" Style="font-weight: bold;" />
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
                            <asp:Label runat="server" ID="lblEnemyChampStep" />
                    </td>
                </tr>
                <tr>
                    <td>XP:&nbsp;
                            <asp:Label runat="server" ID="lblEnemyChampXP" />&nbsp;/&nbsp;
                            <asp:Label runat="server" ID="lblEnemyChampRemainingXP" />
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

        <%-- buttons leading to different page --%>
        <div style="vertical-align: bottom;">
            <%-- fightoutcome button--%>
            <asp:Button runat="server" ID="btnChallenge" Text="Challenge Again?" CssClass="button2" OnClick="btnChallenge_Click" />

            <%-- fight summaries button--%>
            <asp:Button runat="server" ID="btnFightSummary" Text="View Elemental Fight Summary" CssClass="button2" OnClick="btnFightSummary_Click" />

            <%-- main menu button --%>
            <asp:Button runat="server" ID="btnMainMenu" Text="Main Menu" CssClass="button2" OnClick="btnMainMenu_Click" />
        </div>
    </main>

</asp:Content>
