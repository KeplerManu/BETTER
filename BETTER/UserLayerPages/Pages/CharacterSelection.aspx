<%@ Page Title="" Language="C#" MasterPageFile="~/UserLayerPages/MasterPages/BetterMenu.Master" AutoEventWireup="true" CodeBehind="CharacterSelection.aspx.cs" Inherits="BETTER.Pages.WebForm3" %>
<asp:Content ID="pageName" ContentPlaceHolderID="pageName" runat="server">
    <%-- top of page title --%>
    B.E.T.T.E.R Character Selection
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Character Selection</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="rightcolumn">
        <div style="float: left; margin-left: 5%">

            <%-- list of currently active elementals. Information displayed includes: ChampImage and ChampLevel. 
                Remove button is currently unfunctional --%>
            <h2>Active Elementals</h2>

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
                                <asp:ImageButton ID="imgBtnTitan" runat="server" AlternateText="Elemental" ImageUrl='<%#Eval("imagePath") %>' CssClass="elements" Style="vertical-align: middle" />
                                <asp:Label ID="lblActiveTitanName" runat="server" Text='<%#Eval("titanName") %>' />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnRemove" runat="server" Text="Remove" CommandName="Remove"/>
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

            <ul style="list-style-type:none">
                <li>
                    <asp:Button runat="server"
                        ID="btnNewChamp" 
                        Text="Create New Elemental" 
                        OnClick="btnNewChamp_Click" 
                        style="width:100%; height:50px; border-radius:5px" />

                </li>
            </ul>
        </div>

        <div style="float: right; margin-right: 10%">

            <%-- list of elements that you can use to filter your list of created elementals --%>
            <h2>Filter your Elementals</h2>
            <ul class="horizontal">
                <li class="horizontal">
                    <asp:ImageButton ID="imgBtnAir" runat="server" AlternateText="air" ImageUrl="~/Images/air.png" OnClick="imgBtnAir_Click" CssClass="elements" />
                </li>
                <li class="horizontal">
                    <asp:ImageButton ID="imgBtnEarth" runat="server" AlternateText="earth" ImageUrl="~/Images/earth.png" OnClick="imgBtnEarth_Click" CssClass="elements" />
                </li>
                <li class="horizontal">
                    <asp:ImageButton ID="imgBtnFire" runat="server" AlternateText="fire" ImageUrl="~/Images/fire.png" OnClick="imgBtnFire_Click" CssClass="elements" />
                </li>
                <li class="horizontal">
                    <asp:ImageButton ID="imgBtnWater" runat="server" AlternateText="water" ImageUrl="~/Images/water.jpg" OnClick="imgBtnWater_Click" CssClass="elements" />
                </li>
            </ul>
            <br />
            <br />

            <%-- list view shows all available elementals. displayed information for elementals include: ChampImage, ChampName, ChampLevel
                Elemental titans are filtered after clicking corresponding filter element picture --%>

            <div>
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
                                <asp:ImageButton ID="imgBtnElement" runat="server" AlternateText="ElementPicture" ImageUrl='<%#Eval("imagePath") %>' CssClass="elements" Style="float: left; vertical-align: middle" />
                                <table style="text-align: left">
                                    <tr>
                                        <td>
                                            Name: <asp:Label ID="lblTitanName" runat="server" Text='<%#Eval("titanName") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <%-- button that leads to character management screen --%>
                                            <asp:Button ID="btnCharacterInfo" runat="server" Text="Character Info" CommandName="Info" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <%-- currently unfunctional button that will let you select the character --%>
                                            <asp:Button ID="btnActivate" runat="server" Text="Activate Character" CommandName="Activate"/>
                                        </td>
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
                <asp:Label runat="server" ID="lblActivateError" Text="Please deactivate a champion of the same element before activating another" Visible="false"/>
            </div>

            <br />
            <asp:Label ID="lblInfoError" runat="server" Text="Please select a character" style="color: red" visible="false"/>

        </div>
    </main>
</asp:Content>
