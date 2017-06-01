<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BETTER.Pages.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BETTER Registration</title>
    <link rel="stylesheet" type="text/css" href="../../CSS/Welcome.css" />
</head>

<body>
    <form id="form1" runat="server">
        <h1 class="title">Registration</h1>
        <ul>
            <li class="content">
                <div>
                    <%-- Register form table --%>
                    <table border="0">

                        <%-- username/user email field must be a valid email i.e. _ @ _ _ . _ _
                            and is required --%>
                        <tr>
                            <td style="text-align: right">Email: 
                            </td>
                            <td style="text-align: center">
                                <asp:TextBox ID="txbEmail" runat="server" />
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txbEmail"
                                    runat="server" />
                                <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w{2,}([-.]\w{2,})*\.\w{2,}([-.]\w{2,})*"
                                    ControlToValidate="txbEmail" ForeColor="Red" ErrorMessage="Invalid email address." />
                            </td>
                        </tr>

                        <%-- Password is required. Password minimum of 8 alphanumeric characters and maximum of 40 characters --%>
                        <tr>
                            <td style="text-align: right">Password: 
                            </td>
                            <td style="text-align: center">
                                <asp:TextBox ID="txbPassword" runat="server" TextMode="Password" />
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txbPassword"
                                    runat="server" />
                                <asp:RegularExpressionValidator ErrorMessage="At least 8 characters" ForeColor="Red" ControlToValidate="txbPassword"
                                    runat="server" ValidationExpression="^[a-zA-Z0-9_-]{8,40}$" Display="Dynamic" />
                            </td>
                        </tr>

                        <%-- confirm password must match password field --%>
                        <tr>
                            <td style="text-align: right">Confirm Password: 
                            </td>
                            <td style="text-align: center">
                                <asp:TextBox ID="txbConfirmPassword" runat="server" TextMode="Password" />
                            </td>
                            <td>
                                <asp:CompareValidator ErrorMessage="Passwords do not match." ForeColor="Red" ControlToCompare="txbPassword"
                                    ControlToValidate="txbConfirmPassword" runat="server" />
                            </td>
                        </tr>

                        <%-- Parent Email must be a valid email i.e. _ @ _ _ . _ _
                            and is required. --%>
                        <tr>
                            <td style="text-align: right">Parent Email: 
                            </td>
                            <td style="text-align: center">
                                <asp:TextBox ID="txbParentEmail" runat="server" />
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ErrorMessage="Required" Display="Dynamic" ForeColor="Red"
                                    ControlToValidate="txbParentEmail" runat="server" />
                                <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w{2,}([-.]\w{2,})*\.\w{2,}([-.]\w{2,})*"
                                    ControlToValidate="txbParentEmail" ForeColor="Red" ErrorMessage="Invalid email address." />
                            </td>
                        </tr>

                        <%-- Username is required, must be under 20 characters --%>
                        <tr>
                            <td style="text-align: right">Username: 
                            </td>
                            <td style="text-align: center">
                                <asp:TextBox ID="txbUsername" runat="server" />
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ErrorMessage="Required" Display="Dynamic" ForeColor="Red"
                                    ControlToValidate="txbUsername" runat="server" />
                                <asp:RegularExpressionValidator runat="server" ValidationExpression="^[a-zA-Z0-9_-]{0,20}$"
                                    ControlToValidate="txbUsername" ForeColor="Red" ErrorMessage="Please enter valid username under 20 characters" />
                            </td>
                        </tr>

                        <%-- First Name is required and should be less than 50 characters. Apostrophes allowed --%>
                        <tr>
                            <td style="text-align: right">First Name: 
                            </td>
                            <td style="text-align: center">
                                <asp:TextBox ID="txbFirstName" runat="server" />
                            </td>
                            <td>
                                <asp:Label runat="server" text="Only first name will be displayed if in anonymous mode" />
                                <asp:RequiredFieldValidator ErrorMessage="Required" Display="Dynamic" ForeColor="Red"
                                    ControlToValidate="txbFirstName" runat="server" />
                                <asp:RegularExpressionValidator runat="server" ValidationExpression="^[a-zA-Z0-9'_-]{0,50}$"
                                    ControlToValidate="txbFirstName" ForeColor="Red" ErrorMessage="Please enter name under 50 characters" />
                            </td>
                        </tr>

                        <%-- Last Name is required and should be less than 50 characters. Apostrophes allowed --%>
                        <tr>
                            <td style="text-align: right">Last Name: 
                            </td>
                            <td style="text-align: center">
                                <asp:TextBox ID="txbLastName" runat="server" />
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ErrorMessage="Required" Display="Dynamic" ForeColor="Red"
                                    ControlToValidate="txbLastName" runat="server" />
                                <asp:RegularExpressionValidator runat="server" ValidationExpression="^[a-zA-Z0-9'_-]{0,50}$"
                                    ControlToValidate="txbLastName" ForeColor="Red" ErrorMessage="Please enter username under 50 characters" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">Anonymous Mode? 
                            </td>
                            <td style="text-align: center">
                                <asp:RadioButton ID="rdbAnonymous" runat="server" />
                            </td>
                            <td>
                            </td>
                        </tr>

                        <tr>
                            <td style="text-align: center">
                                <%-- already have an account? button leads to login page --%>
                                <asp:Button runat="server" Text="Already have an account?" ID="btnLogin" OnClick="btnLogin_Click" CausesValidation="false" />
                            </td>
                            <td>
                                <%--submit button runs validation --%>
                                <asp:Button Text="Submit" runat="server" ID="btnRegister" OnClick="btnRegister_Click" />
                            </td>
                            <td>
                                <asp:Label runat="server" Text="Email already exists" ID="lblEmailError" ForeColor="Red" Visible="false"/>
                                <asp:Label runat="server" Text="Username already exists" ID="lblNameError" ForeColor="Red" Visible="false"/>
                            </td>
                        </tr>
                    </table>

                </div>
                <asp:ImageButton runat="server" ID="imgBtnBack"
                    ImageUrl="~/Images/BackButton.jpg"
                    AlternateText="back"
                    Style="width: 50px; height: 50px;"
                    OnClick="imgBtnBack_Click"
                    CausesValidation="false" />
            </li>
        </ul>

    </form>
</body>
</html>
