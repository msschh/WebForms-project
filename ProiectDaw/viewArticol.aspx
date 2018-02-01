<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="viewArticol.aspx.cs" Inherits="ProiectDaw.viewArticol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 style="margin-left:35%;">Vezi articolul!</h3>
    <br />
    <div id="idDiv" runat="server"></div>
    Titlu:
    <asp:TextBox ID="ArticleTitleTxt" runat="server" Width="750px" Enabled="false"></asp:TextBox>
    <br />
    Autor:
    <asp:TextBox ID="AuthorUsernameTxt" runat="server" Enabled="false"></asp:TextBox>
    <br />
    Data creare:
    <asp:TextBox ID="DateOfCreationTxt" runat="server" Enabled="false"></asp:TextBox>
    <br />
    Domeniu:
    <asp:TextBox ID="DomainNameTxt" runat="server" Enabled="false"></asp:TextBox>
    <br />
    Protejat:
    <asp:CheckBox ID="CheckBox1" runat="server" Enabled="false"/>
    <br />
    Ultimul user care a modificat articolul:
    <asp:TextBox ID="ChangeUsernameTxt" runat="server" Enabled="false"></asp:TextBox>
    <br />
    Data ultimei modificari:
    <asp:TextBox ID="ChangeDateTxt" runat="server" Enabled="false"></asp:TextBox>
    <br />
    <h3 style="margin-left:33%;">Textul articolului!</h3>
    <br />
    <div runat="server" id="ContinutDiv"></div>
    <br /><br />
    <asp:Button ID="Button3" runat="server" OnClick="EditArticle" Text="Edit" />
    <asp:LoginView ID="LoginView2" runat="server">
        <RoleGroups>
            <asp:RoleGroup Roles="Editor">
                <ContentTemplate>
                    <asp:Button ID="Button6" runat="server" OnClick="DeleteModification" Text="Sterge ultima modificare" />
                    <asp:Button ID="Button5" runat="server" OnClick="DeleteArticle" Text="Sterge Articol" />    
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
    <br />
</asp:Content>
