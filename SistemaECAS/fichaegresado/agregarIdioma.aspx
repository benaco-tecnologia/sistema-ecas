<%@ Page Title="" Language="C#" MasterPageFile="~/Base1.Master" AutoEventWireup="true" CodeBehind="agregarIdioma.aspx.cs" Inherits="FichaEgresado.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:HiddenField ID="modificacion" Value="false" runat="server" />
<asp:Label Text="" ID="mensaje" runat="server" />
    <table style="width:100%;">
        <tr><td class="titulo">Idiomas</td></tr>
        <tr>
            <td class="subtitulo">Idioma<br />
                <asp:DropDownList ID="idiomaID" runat="server" 
                    DataSourceID="SqlDataSource1" DataTextField="idioma" DataValueField="idiomaID">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:BaseSqlServer %>" 
                    SelectCommand="SELECT [idioma], [idiomaID] FROM matricula.EGRESADOidioma ORDER BY [idioma]">
                </asp:SqlDataSource>
            </td>
            <td class="subtitulo">Nivel Escrito<br />
                <asp:DropDownList ID="escrito" runat="server">
                    <asp:ListItem Value="1"></asp:ListItem>
                    <asp:ListItem Value="2"></asp:ListItem>
                    <asp:ListItem Value="3"></asp:ListItem>
                    <asp:ListItem Value="4"></asp:ListItem>
                    <asp:ListItem Value="5"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="subtitulo">Nivel Oral<br />
                <asp:DropDownList ID="oral" runat="server">
                    <asp:ListItem Value="1"></asp:ListItem>
                    <asp:ListItem Value="2"></asp:ListItem>
                    <asp:ListItem Value="3"></asp:ListItem>
                    <asp:ListItem Value="4"></asp:ListItem>
                    <asp:ListItem Value="5"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="right">
                <asp:Button ID="Button1" runat="server" Text="Aceptar" onclick="Button1_Click" />
            </td>
        </tr>
    </table>
    <p>Modificando usuario <asp:Label ID="rut" runat="server"></asp:Label></p>
</asp:Content>
