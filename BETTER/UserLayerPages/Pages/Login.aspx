<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BETTER.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BETTER Login</title>
    <link rel="stylesheet" type="text/css" href="../../CSS/Welcome.css" />
</head>

<body>
    <form id="form1" runat="server">
        <%-- big friendly heading --%>
        <h1 style="width: 100%; font-family: 'Comic Sans MS'; text-align: center">LOGIN</h1>
        <ul>
            <li class="content">
                <%--login form table--%>
                <table>
                        <%-- username required --%>
                        <tr>
                            <td style="text-align:right">
                                <asp:Label ID="lblEmail" runat="server" Text="Email: " CssClass="label"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txbEmail" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ForeColor="Red" ControlToValidate="txbEmail" ErrorMessage="Required"
                                    runat="server"/>
                            </td>
                        </tr>

                        <%--Password required--%>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblPassword" runat="server" Text="Password: " CssClass="label" />
                            </td>
                            <td>
                                <asp:TextBox ID="txbPassword" runat="server" TextMode="Password"/>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txbPassword"
                                    runat="server" />
                            </td>
                        </tr>
                        
                        <%-- submit button --%>
                        <tr>
                            <td style="text-align:right">
                                <asp:Label ID="lblLoginError" runat="server" style="color:red" Text="Email or Password is incorrect" Visible="false"/>
                            </td>
                            <td>
                                <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click"/>
                            </td>
                            <td></td>
                        </tr>
                    </table>

                    <%-- buttons table. includes don't have an account? which leads to registration and
                        forgot your password which will send an email to your entered email address (email functionality not set up yet) --%>
                    <table> 
                        <tr>
                            <td style="text-align: center">
                                <asp:Button ID="btnRegister" Text="Don't have an account?" runat="server" OnClick="btnRegister_Click" CausesValidation="false"/>
                            </td>
                            <td style="text-align: center">
                                <asp:Button ID="btnPasswordReset" Text="Forgot your password?" runat="server" OnClick="btnPasswordReset_Click" CausesValidation="false" />
                            </td>
                            <td></td>
                        </tr>
                    </table>

                <%-- back button --%>
                <div style="float:left">
                        <asp:ImageButton runat="server" ID="imgBtnBack" 
                            ImageUrl="~/Images/BackButton.jpg" 
                            AlternateText="back" 
                            style="width: 50px; height: 50px;" 
                            OnClick="imgBtnBack_Click" 
                            CausesValidation="false"/>
                </div>
            </li>
        </ul>
    </form>
</body>
</html>
