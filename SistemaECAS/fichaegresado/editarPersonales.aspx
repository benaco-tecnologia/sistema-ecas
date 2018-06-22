<%@ Page Title="Editar datos personales" Language="C#" MasterPageFile="~/Base1.Master" AutoEventWireup="true" CodeBehind="editarPersonales.aspx.cs" Inherits="FichaEgresado.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="titulo" colspan="3">Nombre completo</td>
        </tr>
        <tr>
            <td class="subtitulo">Nombres<br /><asp:TextBox ID="nombre" runat="server" Width="80%"></asp:TextBox></td>
            <td class="subtitulo">Apellido paterno<br /><asp:TextBox ID="paterno" runat="server" Width="80%"></asp:TextBox></td>
            <td class="subtitulo">Apellido materno<br /><asp:TextBox ID="materno" runat="server" Width="80%"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="titulo" colspan="3">
                <br />
                Direccion personal</td>
        </tr>
        <tr>
            <td class="subtitulo">Calle<br /><asp:TextBox ID="diractual" runat="server" Width="80%"></asp:TextBox></td>
            <td class="subtitulo">Comuna<br /><asp:TextBox ID="comuna" runat="server" Width="80%"></asp:TextBox></td>
            <td class="subtitulo">Ciudad<br /><asp:TextBox ID="ciudadact" runat="server" Width="80%"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="titulo">
                <br />
                Correo electrónico<br /><asp:TextBox ID="mail" runat="server" Width="80%"></asp:TextBox></td>
            <td class="titulo">
                <br />
                Teléfono<br /><asp:TextBox ID="fonoact" runat="server" Width="80%"></asp:TextBox></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp</td>
            <td align="right"><asp:Button ID="Button2" runat="server" onclick="Button1_Click" Text="Aceptar" /></td>
        </tr>
    </table>
    <p>Modificando usuario <asp:Label ID="rut" runat="server"></asp:Label></p>
</asp:Content>
