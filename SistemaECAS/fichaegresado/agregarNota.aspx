<%@ Page Title="" Language="C#" MasterPageFile="~/Base1.Master" AutoEventWireup="true" CodeBehind="agregarNota.aspx.cs" Inherits="FichaEgresado.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table style="width:100%;" cellpadding="2">
    <tr><td class="titulo">Nota</td></tr>
    <tr><td class="subtitulo">Ingrese nota<br />
    <asp:TextBox ID="nota" runat="server" Height="92px" TextMode="MultiLine" 
        Width="100%"></asp:TextBox>
</td>
</tr>
        <tr>
<td align="right">
                    
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Aceptar" />
                    
    </td>
</tr>
</table>
<p>Modificando usuario <asp:Label ID="rut" runat="server"></asp:Label></p>
</asp:Content>
