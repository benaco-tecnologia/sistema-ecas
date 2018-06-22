<%@ Page Title="" Language="C#" MasterPageFile="~/Base1.Master" AutoEventWireup="true" CodeBehind="previsualizarCorreoBkp.aspx.cs" Inherits="SistemaECAS.mailmasivo.previsualizarCorreo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblError" runat="server" Text="" Font-Italic="true"></asp:Label>
<asp:Label ID="lblFormato" runat="server" Text="Label"></asp:Label>
    <br />
    <p style="text-align: right;">
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
    Text="Atrás" />&nbsp;
    <asp:Button ID="Enviar" runat="server" onclick="Enviar_Click" Text="Aceptar" />
    </p>
</asp:Content>
