<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="ClinicalSummaryWeb.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel runat="server">
            <asp:TextBox runat="server">Member ID</asp:TextBox>
            <asp:Button runat="server" Text="GetDetails" OnClick="Unnamed3_Click"/>
        </asp:Panel>
    <div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
<Columns>
    <asp:BoundField DataField="Goal" HeaderText="Goal" ItemStyle-Width="150" />
    <asp:BoundField DataField="StartDate" HeaderText="StartDate" ItemStyle-Width="150" />
    <asp:BoundField DataField="Goal Priority" HeaderText="Goal Priority" ItemStyle-Width="100" />
    <asp:BoundField DataField="Completion Date" HeaderText="Completion Date" ItemStyle-Width="100" />
</Columns>
</asp:GridView>
    </div>
    </form>
</body>
</html>
