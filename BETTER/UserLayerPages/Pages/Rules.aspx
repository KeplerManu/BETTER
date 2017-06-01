 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rules.aspx.cs" Inherits="BETTER.Pages.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BETTER Rules</title>
    <link rel="stylesheet" type="text/css" href="../../CSS/Welcome.css" />
</head>

<%-- static rules page with general explanation and a back button --%>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Rules of B.E.T.T.E.R</h1>
        <ul>
            <li class="content" style="text-align: justify">
                <p>
                Play as an Elemental Titan and fight your way through enemy Elementals to become a God of Elemental Titans and get your name in the Hall of Fame!* <br />
                Earn experience for your Titans by exercising, and feel yourself become stronger alongside your giant companions. <br />
                Verse other players in the Elemental Battle Arena to become the strongst Elemental Titan!<br /><br />
                *UserName Optional
                </p>
                <asp:ImageButton runat="server" ID="imgBtnBack" ImageUrl="~/Images/BackButton.jpg" AlternateText="back" style="width: 50px; height: 50px;" OnClick="imgBtnBack_Click"/>
            </li>
        </ul>
    </div>
    </form>
</body>
</html>
