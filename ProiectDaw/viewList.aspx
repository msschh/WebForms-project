<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="viewList.aspx.cs" Inherits="ProiectDaw.viewList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 style="margin-left:25%;">Ultimele articole din aceasta categorie</h3>
    <br />
    Sortati articolele dupa &nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Value="DATE">Data crearii</asp:ListItem>
        <asp:ListItem Value="TITLE">Titlu</asp:ListItem>
    </asp:DropDownList>
    &nbsp;
    <asp:DropDownList ID="DropDownList2" runat="server">
        <asp:ListItem Value="DESC">DESCENDENT</asp:ListItem>
        <asp:ListItem Value="ASC">ASCENDENT</asp:ListItem>
    </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button3" runat="server" OnClick="SortList" Text="Sorteaza" />
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
