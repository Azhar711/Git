<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebWcf.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <h1>Clinical Summary</h1>
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
        <Columns>
        <asp:BoundField DataField="Goal" HeaderText="Goal" ItemStyle-Width="500" />
        <asp:BoundField DataField="GoalPriority" HeaderText="Priority" ItemStyle-Width="150" />
        <asp:BoundField DataField="GoalStartDate" HeaderText="Start Date" ItemStyle-Width="200" />
        <asp:BoundField DataField="AchievedDate" HeaderText="Acheived Date" ItemStyle-Width="200" />
        </Columns>
        </asp:GridView>

        <asp:GridView ID="GridView2" runat="server">
        <Columns>
        <asp:BoundField DataField="Goal" HeaderText="Goal" ItemStyle-Width="500" />
        <asp:BoundField DataField="GoalPriority" HeaderText="Priority" ItemStyle-Width="150" />
        <asp:BoundField DataField="GoalStartDate" HeaderText="Start Date" ItemStyle-Width="200" />
        <asp:BoundField DataField="CompletionDate" HeaderText="Completion Date" ItemStyle-Width="200" />
        </Columns>
        </asp:GridView>
    </form>
</body>
</html>
