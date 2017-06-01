<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatabaseTest.aspx.cs" Inherits="BETTER.DataAccessLayer.Pages.DatabaseTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblDatabaseTest" runat="server" Text="Screen Name: "></asp:Label>
        <asp:TextBox ID="txbDatabaseTest1" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Sceen Name: "></asp:Label>
        <asp:TextBox ID="txbDatabaseTest2" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Sceen Name: "></asp:Label>
        <asp:TextBox ID="txbDatabaseTest3" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Sceen Name: "></asp:Label>
        <asp:TextBox ID="txbDatabaseTest4" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Sceen Name: "></asp:Label>
        <asp:TextBox ID="txbDatabaseTest5" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
        <br />
        <br />
        <br />
        <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="1">
            <WizardSteps>
                <asp:WizardStep runat="server" title="Step 1">
                </asp:WizardStep>
                <asp:WizardStep runat="server" title="Step 2">
                </asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
            <Columns>
                <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:udbBetterConnectionString %>" SelectCommand="SELECT [username] FROM [tblUser]"></asp:SqlDataSource>
        <br />
    
    </div>
    </form>
</body>
</html>
