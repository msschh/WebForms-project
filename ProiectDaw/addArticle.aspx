<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="addArticle.aspx.cs" Inherits="ProiectDaw.addArticle" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 style="margin-left:35%;">Adauga un nou articol!</h3>
    <br />
    <p>
        Titlu:
        <asp:TextBox ID="TextBox1" Width="750px" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ControlToValidate="TextBox1" ForeColor="Red" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Va rugam sa completati titlul!">Va rugam sa completati titlul!</asp:RequiredFieldValidator>
    </p>
    <p>
        Categorie:
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Domains]"></asp:SqlDataSource>
    </p>
    <p>
        Protejat:
        <asp:CheckBox ID="CheckBox1" runat="server" />
    </p>
    <p>
        Continut:</p>
    <p>
        <textarea rows="20" cols="110" runat="server" id="TextArea"></textarea>
        <asp:RequiredFieldValidator ControlToValidate="TextArea" ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="Va rugam sa completati continutul articolului!">Va rugam sa completati continutul articolului!</asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Button4" runat="server" Text="Upload Image" OnClick="UploadImage" />
        <br /><asp:Label ID="LabelUploadImage" ForeColor="Red" runat="server" Text=""></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button3" runat="server" OnClick="AddArticle" Text="Adauga Articol" />
    </p>
</asp:Content>
