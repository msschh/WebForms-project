<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="addDomain.aspx.cs" Inherits="ProiectDaw.editor.addDomain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 style="margin-left:35%;">Adauga un nou domeniu</h3>
    <br />
    <p>
        Nume domeniu:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>&nbsp;
        <asp:Button ID="Button3" runat="server" OnClick="AddDomain" Text="Adauga domeniu" />
    </p>
</asp:Content>
