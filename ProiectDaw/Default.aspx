<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProiectDaw.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 style="margin-left:35%;">Welcome to my website!</h3>
    <!--<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button" />-->
    <br />
    Titlu articolului:&nbsp;
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    Numele autorului:
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button4" runat="server" Text="Cauta" OnClick="FiltreazaDupaTitlu" />
    <br />
    <asp:ListView ID="ListView1" runat="server">
        <ItemTemplate>
            <div style="margin-top: 20px; padding: 10px; background-color: #e6ff99; border: 1px solid silver">
            <table>
                <tr>
                    <td>
                        Titlu:&nbsp;<asp:Label id="LabelId" runat="server" Text='<%#Eval("ArticleTitle") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Autor:&nbsp;<asp:Label id="Label1" runat="server" Text='<%#Eval("Username") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Data crearii:&nbsp;<asp:Label id="Label2" runat="server" Text='<%#Eval("DateOfCreation") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Domeniu:&nbsp;<asp:Label id="Label4" runat="server" Text='<%#Eval("DomainName") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <asp:Button runat="server" Text="Vezi articol" CommandArgument='<%# Eval("ArticleId") %>' /><br /> 
                        </div>
                    </td>
                </tr>
            </table>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
