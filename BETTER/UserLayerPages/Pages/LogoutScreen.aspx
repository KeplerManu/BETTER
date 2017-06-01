<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogoutScreen.aspx.cs" Inherits="BETTER.Pages.LogoutScreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Successful Logout</title>
    <link rel="stylesheet" type="text/css" href="../../CSS/Welcome.css" />
</head>

<%-- logout splash with thank you message and continue button to return to welcome splash--%>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Thanks for playing BETTER!</h1>
        <ul>
            <li class="content">
                <h2 style="text-align:center; color:red; font-family:'Comic Sans MS'; text-shadow : 2px 2px #000000;">
                    You have been successfully Logged Out
                </h2>
                <asp:Button runat="server" ID="btnContinue" OnClick="btnContinue_Click" Text="Continue" CssClass="button" />
            </li>
        </ul>
    </div>
    </form>
</body>
</html>
