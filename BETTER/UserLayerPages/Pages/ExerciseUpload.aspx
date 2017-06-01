<%@ Page Title="" Language="C#" MasterPageFile="~/UserLayerPages/MasterPages/BetterMenu.Master" AutoEventWireup="true" CodeBehind="ExerciseUpload.aspx.cs" Inherits="BETTER.Pages.ExerciseUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Exercise Upload</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="pageName" runat="server">
    <%--top of page title--%>
    B.E.T.T.E.R Exercise Upload
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="rightcolumn">
        <ul>
            <%-- red bordered content --%>
            <li class="content">
                <table>
                    <%-- Enter exercise points, currently no cap since no business rules.
                        Required field --%>
                    <tr>
                        <td>Daily Exercise Points:</td>
                        <td>
                            <asp:TextBox runat="server" ID="txbExercisePoints" />
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="vldExercisePoints"
                                 runat="server"
                                 ErrorMessage="Required"
                                 ControlToValidate="txbExercisePoints"
                                 ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <%--Enter Parent PIN. Required field --%>
                    <tr>
                        <td>Parent PIN:</td>
                        <td>
                            <asp:TextBox runat="server" ID="txbParentPIN" />
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="vldParentPIN"
                                 runat="server"
                                 ErrorMessage="Required"
                                 ControlToValidate="txbParentPIN"
                                 ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <%--submit button--%>
                    <tr>
                        <td>
                            <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
                        </td>
                    </tr>
                </table>

                <%-- invisible messages that appear depending on whether PIN is correct or not --%>
                <%--PIN Correct message --%>
                <p runat="server" id="getPoints" visible="false">Congratulations! You just got
                    <asp:Label ID="lblPoints" runat="server" />
                    Exercise Points!!!</p>
                <%--PIN Incorrect message --%>
                <asp:Label ID="lblError" runat="server" />
            </li>
        </ul>
    </main>
</asp:Content>
