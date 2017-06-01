<%@ Page  Title="" Language="C#" MasterPageFile="~/UserLayerPages/MasterPages/BetterMenu.Master" AutoEventWireup="true" CodeBehind="CharacterManagement.aspx.cs" Inherits="BETTER.Pages.WebForm4" %>
<asp:Content ID="pageName" ContentPlaceHolderID="pageName" runat="server">
    <%-- Top of Page Title --%>
    B.E.T.T.E.R Character Management
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Character Management</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="rightcolumn">

        <div style="float: left; margin-left: 5%;">
            <%-- Displays list of all created Elementals to the left --%>
            <h2>Available Elementals</h2>
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
                                            Name: <asp:Label ID="lblTitanName" runat="server" Text='<%#Eval("titanName") %>' /></td>
                                    </tr>
                                    
                                </table>
                                <br /><br /><br /><br />
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

        <%-- Information about chosen displayed on the right. As of right now, only Name and Picture are updated
            according to selected character. Displayed info includes:
            ChampName, ChampImage, ChampLevel, ChampStep, ChampXP, ChampBattles, lblChampWins, lblChampLosses --%>
        <div style="float: right; margin-right: 5%">
            <h2>
                <asp:Label ID="lblChampName" runat="server" Width="100%" Text="Select a titan" />
            </h2>
            <asp:Image ImageUrl="~/Images/air.png" runat="server" ID="imgManage" AlternateText="Titan1" CssClass="elements" Style="align-content: center" />
            <br />
            <table>
                <tr>
                    <td>Level:</td>
                    <td>
                        <asp:Label ID="lblChampLevel" runat="server" Text="Select a titan"/></td>
                </tr>
                <tr>
                    <td>Step:</td>
                    <td>
                        <asp:Label ID="lblChampStep" runat="server" Text="Select a titan"/></td>
                </tr>
                <tr>
                    <td>XP:</td>
                    <td>
                        <asp:Label ID="lblChampXP" runat="server" Text="Select a titan"/></td>
                </tr>
                <tr>
                    <td>Battles Fought:</td>
                    <td>
                        <asp:Label ID="lblChampBattles" runat="server" Text="Select a titan"/></td>
                </tr>
                <tr>
                    <td>Wins:</td>
                    <td>
                        <asp:Label ID="lblChampWins" runat="server" Text="Select a titan"/></td>
                </tr>
                <tr>
                    <td>Losses:</td>
                    <td>
                        <asp:Label ID="lblChampLosses" runat="server"  Text="Select a titan"/></td>
                </tr>
            </table>

            <%-- table including name change and point allocation options --%>
            <table>

                <%-- Champ Name Change --%>
                <tr>
                    <td>
                        <asp:TextBox ID="txbNameChange" runat="server" Text="New Name Here" />
                    </td>
                    <td>
                        <asp:Button ID="btnNameChange" runat="server" Text="Edit Name" OnClick="btnNameChange_Click" />
                    </td>
                </tr>

                <%-- New Champ Name can't be longer than 20 Letters and must be alphanumeric --%>
                <tr>
                    <td>
                        <asp:RegularExpressionValidator ID="validationHeroName"
                            runat="server"
                            ForeColor="Red"
                            ControlToValidate="txbNameChange"
                            ErrorMessage="Up to 20 letters and valid characters only"
                            ValidationExpression="^[\w \s]{1,20}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>

                <%-- Assign points to character --%>
                <tr>
                    <td>
                        <asp:TextBox ID="txbAssignPoints" runat="server" /></td>
                    <td>
                        <asp:Button ID="btnAssignPoints" runat="server" Text="Assign Exercise Points" OnClick="btnAssignPoints_Click"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNameError" runat="server" Text="You already have a titan with that name. Please rename." Visible="false"/>
                    </td>
                </tr>

                <%-- Allocated points must be more than 0 but no more than the amount of leftover points that the user has --%>
                <tr>
                    <td>
                        <asp:RangeValidator ID="vldAssignPoints"
                            ControlToValidate="txbAssignPoints"
                            ForeColor="Red"
                            runat="server"
                            MinimumValue="0"
                            MaximumValue="<%#Points%>"
                            Type="Integer"
                            EnableClientScript="false">
                        </asp:RangeValidator>
                    </td>

                </tr>
            </table>
        </div>
    </main>
</asp:Content>
