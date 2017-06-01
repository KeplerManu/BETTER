<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="BETTER.Pages.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to BETTER</title>
    <link rel="stylesheet" type="text/css" href="../../CSS/Welcome.css" />
</head>
<body>
    <form id="form1" runat="server">
            <h1>Welcome to BETTER</h1>
        <div>
            <%-- 4 big friendly buttons that direct to Login, Register, Rules, and Hall of Fame, respectively --%>
            <table>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <%-- login --%>
                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="button" OnClick="btnLogin_Click" />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%-- register --%>
                        <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="button" OnClick="btnRegister_Click" />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%-- rules --%>
                        <asp:Button ID="btnRules" runat="server" Text="Rules" CssClass="button" OnClick="btnRules_Click" />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%-- Hall of Fame--%>
                        <asp:Button ID="btnHOF" runat="server" Text="Hall of Fame" CssClass="button" OnClick="btnHOF_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
