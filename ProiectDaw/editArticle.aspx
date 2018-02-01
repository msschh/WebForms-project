<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="editArticle.aspx.cs" Inherits="ProiectDaw.editArticle" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 style="margin-left:35%;">Editeaza articolul!</h3>
    <br />
    Titlu:
    <asp:TextBox ID="TextBox1" runat="server" Width="750px" Enabled="false"></asp:TextBox>
    <br />
    Autor:
    <asp:TextBox ID="TextBox2" runat="server" Enabled="false"></asp:TextBox>
    <br />
    Domeniu:
    <asp:TextBox ID="TextBox3" runat="server" Enabled="false"></asp:TextBox>
    <br />
    Continut:
    <textarea rows="20" cols="110" runat="server" id="TextArea"></textarea>
    <asp:RequiredFieldValidator ControlToValidate="TextArea" ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="Va rugam sa completati continutul articolului!">Va rugam sa completati continutul articolului!</asp:RequiredFieldValidator>
    <br />
    Schimba restrictionarea accesului la editare a vizitatorilor neinregistrati:
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Value="True">DA</asp:ListItem>
        <asp:ListItem Value="False">NU</asp:ListItem>
    </asp:DropDownList>
&nbsp;<asp:Button ID="Button5" runat="server" OnClick="ChangeProtection" Text="Schimba" />
&nbsp;
    <br /><br />
    <p>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Label ID="LabelUploadImage" ForeColor="Red" runat="server" Text=""></asp:Label><br /><br />
        
        <asp:Button ID="Button1" runat="server" Text="Upload Image" OnClick="UploadImage" />
        <asp:Button ID="Button3" runat="server" Text="Save" OnClick="UpdateArticle" />
        <asp:Button ID="Button4" runat="server" Text="Cancel" OnClick="BackToView" />
    </p>
</asp:Content>
