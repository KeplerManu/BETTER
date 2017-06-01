<%@ Page Title="" Language="C#" MasterPageFile="~/UserLayerPages/MasterPages/BetterMenu.Master" AutoEventWireup="true" CodeBehind="CharacterCreation.aspx.cs" Inherits="BETTER.Pages.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>
        Elemental Creation
    </title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="pageName" runat="server">
    B.E.T.T.E.R New Elemental
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="rightcolumn">
        <div style="width: 80%; text-align: center">

            <%-- list of elements to use to filter creatable characters --%>
            <h2>Select Element</h2>
            <ul class="horizontal">
                <li class="horizontal">
                    <asp:ImageButton ID="imgBtnAir" runat="server" AlternateText="air" ImageUrl="~/Images/air.png" OnClick="imgBtnAir_Click" CssClass="elements" CausesValidation="false"/>
                </li>
                <li class="horizontal">
                    <asp:ImageButton ID="imgBtnEarth" runat="server" AlternateText="earth" ImageUrl="~/Images/earth.png" OnClick="imgBtnEarth_Click" CssClass="elements" CausesValidation="false" />
                </li>
                <li class="horizontal">
                    <asp:ImageButton ID="imgBtnFire" runat="server" AlternateText="fire" ImageUrl="~/Images/fire.png" OnClick="imgBtnFire_Click" CssClass="elements" CausesValidation="false"/>
                </li>
                <li class="horizontal">
                    <asp:ImageButton ID="imgBtnWater" runat="server" AlternateText="water" ImageUrl="~/Images/water.jpg" OnClick="imgBtnWater_Click" CssClass="elements" CausesValidation="false"/>
                </li>
            </ul>
            <br />
            <br />

            <%-- filter air shows available air elementals. displayed information for elementals include: ChampImage, ChampName, ChampLevel
                Initially invisible. Becomes visible after clicking corresponding filter element picture --%>
            <div runat="server" id="filterAir" visible="false" style="text-align: center; width: 100%;">
                <ul class="horizontal">
                    <li class="horizontal">
                        <div style="display: inline-block">
                            <div>
                                <asp:ImageButton ID="imgBtnAir1" runat="server" AlternateText="Air1" ImageUrl="~/Images/air.png" OnClick="imgBtnAir1_Click" CssClass="elements" CausesValidation="false" />
                            </div>
                            <div>
                                <asp:Label ID="lblAir1Name" runat="server" Text="Air Elemental 1" />
                            </div>
                        </div>
                    </li>
                    <li class="horizontal">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</li>
                    <li class="horizontal">
                        <div style="display: inline-block">
                            <div>
                                <asp:ImageButton ID="imgBtnAir2" runat="server" AlternateText="Air2" ImageUrl="~/Images/air.png" OnClick="imgBtnAir2_Click" CssClass="elements" CausesValidation="false"/>
                            </div>
                            <div>
                                <asp:Label ID="lblAir2Name" runat="server" Text="Air Elemental 2" />
                            </div>
                        </div>
                    </li>
                </ul>
            </div>

            <%-- filter earth shows available earth elementals --%>
            <div runat="server" id="filterEarth" visible="false">
                <ul class="horizontal">
                    <li class="horizontal">
                        <div style="display: inline-block">
                            <div>
                                <asp:ImageButton ID="imgBtnEarth1" runat="server" AlternateText="Earth1" ImageUrl="~/Images/earth.png" OnClick="imgBtnEarth1_Click" CssClass="elements" CausesValidation="false" />
                            </div>
                            <div>
                                <asp:Label ID="lblEarth1Name" runat="server" Text="Earth Elemental 1" />
                            </div>
                        </div>
                    </li>
                    <li class="horizontal">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</li>
                    <li class="horizontal">
                        <div style="display: inline-block">
                            <div>
                                <asp:ImageButton ID="imgBtnEarth2" runat="server" AlternateText="Earth2" ImageUrl="~/Images/earth.png" OnClick="imgBtnEarth2_Click" CssClass="elements" CausesValidation="false" />
                            </div>
                            <div>
                                <asp:Label ID="lblEarth2Name" runat="server" Text="Earth Elemental 2" />
                            </div>
                        </div>
                    </li>
                </ul>
            </div>

            <%--Filter fire displays available fire elementals--%>
            <div runat="server" id="filterFire" visible="false">
                <ul class="horizontal">
                    <li class="horizontal">
                        <div style="display: inline-block">
                            <div>
                                <asp:ImageButton ID="imgBtnFire1" runat="server" AlternateText="Fire1" ImageUrl="~/Images/fire.png" OnClick="imgBtnFire1_Click" CssClass="elements" CausesValidation="false" />
                            </div>
                            <div>
                                <asp:Label ID="lblFire1Name" runat="server" Text="Fire Elemental 1" />
                            </div>
                        </div>
                    </li>
                    <li class="horizontal">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</li>
                    <li class="horizontal">
                        <div style="display: inline-block">
                            <div>
                                <asp:ImageButton ID="imgBtnFire2" runat="server" AlternateText="Fire2" ImageUrl="~/Images/fire.png" OnClick="imgBtnFire2_Click" CssClass="elements" CausesValidation="false" />
                            </div>
                            <div>
                                <asp:Label ID="lblFire2Name" runat="server" Text="Fire Elemental 2" />
                            </div>
                        </div>
                    </li>
                </ul>
            </div>

            <%-- filter water displays all available water elementals --%>
            <div runat="server" id="filterWater" visible="false">
                <ul class="horizontal">
                    <li class="horizontal">
                        <div style="display: inline-block">
                            <div>
                                <asp:ImageButton ID="imgBtnWater1" runat="server" AlternateText="Water1" ImageUrl="~/Images/water.jpg" OnClick="imgBtnWater1_Click" CssClass="elements" CausesValidation="false"/>
                            </div>
                            <div>
                                <asp:Label ID="lblWater1Name" runat="server" Text="Water Elemental 1" />
                            </div>
                        </div>
                    </li>
                    <li class="horizontal">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</li>
                    <li class="horizontal">
                        <div style="display: inline-block">
                            <div>
                                <asp:ImageButton ID="imgBtnWater2" runat="server" AlternateText="Water2" ImageUrl="~/Images/water.jpg" OnClick="imgBtnWater2_Click" CssClass="elements" CausesValidation="false" />
                            </div>
                            <div>
                                <asp:Label ID="Water2" runat="server" Text="Water Elemental 2" />
                            </div>
                        </div>
                    </li>
                </ul>
            </div>

            <div style="margin-left:30%; margin-right: 20%;">
            <table>
                <tr>
                    <td>Name (optional):&nbsp;
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txbChampName" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <%-- currently unfunctional button that will let you select the character.
                            Clicking this button takes you to character management with selected character info --%>
                        <asp:Button ID="btnCharacterSelect" runat="server" Text="Select this Character" OnClick="btnCharacterSelect_Click" CausesValidation="false"/>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <%-- Champ name can't be longer than 20 alphanumeric letters--%>
                        <asp:RegularExpressionValidator ID="validationHeroName"
                            runat="server"
                            ForeColor="Red"
                            ControlToValidate="txbChampName"
                            ErrorMessage="Up to 20 letters and valid characters only"
                            ValidationExpression="^[\w \s]{1,20}$"></asp:RegularExpressionValidator>
                        <br />
                        <%-- label that appears if user hasn't chosen an elemental --%>
                        <asp:Label ID="lblError" runat="server" />
                        <br />
                        <asp:Label ID="lblEmptyError" runat="server" Text="Please name your character" Visible="false" />
                        <br />
                        <asp:Label ID="lblActivateError" runat="server" Text="Please deactivate a character before creating a new one" Visible="false" />
                        <br />
                        <asp:Label ID="lblNameError" runat="server" Text="You already have a titan with that name. Please rename." Visible="false" />
                    </td>
                </tr>
            </table>
                </div>
        </div>
    </main>
</asp:Content>
