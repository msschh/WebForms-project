<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="roluriUtilizatori.aspx.cs" Inherits="ProiectDaw.admin.ManageRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 style="margin-left:20%;">Bine ai venit pe pagina de administrare a utilizatorilor!</h3>
    
    <br />
    Acorda utilizatorului cu username-ul&nbsp;
    <asp:TextBox ID="usernameTextBox" runat="server"></asp:TextBox>
    &nbsp;rolul de&nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="RoleName" DataValueField="RoleId" >
    </asp:DropDownList>
    .<asp:Button ID="Button3" runat="server" OnClick="ChangeRole" Text="Aloca drept!" />
&nbsp;<br />
    <asp:Label ID="answerLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [RoleId], [RoleName] FROM [Roles]"></asp:SqlDataSource>
    
    <br /><br />

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" Width="800px" DataKeyNames="UserId" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" />
            <asp:BoundField DataField="UserId" HeaderText="UserId" ReadOnly="True" SortExpression="UserId" Visible="False" />
            <asp:BoundField DataField="UserName" HeaderText="Username" SortExpression="UserName" />
            <asp:BoundField DataField="RoleName" HeaderText="Rol" SortExpression="RoleName" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
        DeleteCommand="DELETE FROM Users WHERE UserId = @UserId"
        SelectCommand="SELECT Users.UserId, Users.UserName, Roles.RoleName FROM Roles INNER JOIN UsersInRoles ON Roles.RoleId = UsersInRoles.RoleId INNER JOIN Users ON UsersInRoles.UserId = Users.UserId">
        <DeleteParameters>
            <asp:Parameter Name="UserId" Type="Object" />
        </DeleteParameters>
    </asp:SqlDataSource>
</asp:Content>
