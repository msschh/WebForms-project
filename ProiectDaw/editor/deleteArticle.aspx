<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="deleteArticle.aspx.cs" Inherits="ProiectDaw.deleteArticle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 style="margin-left:35%;">Confirmare stergere</h3>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Button ID="Button3" runat="server" Text="Sterge" OnClick="DeleteArticle" />
    <asp:Button ID="Button4" runat="server" Text="Renunta" OnClick="BackToView" />
</asp:Content>
