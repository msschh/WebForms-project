<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProiectDaw.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 style="margin-left:35%;">Login</h3>
    <br />
    <div style="margin-left:25%;">
        <asp:Login ID="Login1" runat="server">
        </asp:Login>
    </div>
</asp:Content>
