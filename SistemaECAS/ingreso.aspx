<%@ Page Title="SG Ecas | Ingreso usuario" Language="C#" MasterPageFile="~/Base1.Master" AutoEventWireup="true" CodeBehind="ingreso.aspx.cs" Inherits="SistemaECAS.ingreso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 41%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Ingrese correo institucional y su contrase&ntilde;a.</h3>
    <asp:Label ID="lblError" runat="server" Text="" Font-Italic="true"></asp:Label>
    <br />
    <br />
    <table style="width: 100%;">
            <tr>
                <td align="right" class="style1">Correo</td>
                <td><asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>@ecas.cl</td>
            </tr>
            <tr>
                <td align="right" class="style1">Contrase&ntilde;a</td>
                <td> <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style1"></td>
                <td><asp:Button ID="btnLogin" runat="server" Text="Aceptar" 
                        onclick="btnLogin_Click" />
                </td>
            </tr>
        </table>
</asp:Content>
