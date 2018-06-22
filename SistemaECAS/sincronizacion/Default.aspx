<%@ Page Title="Sincronizaci&oacute;n de Plataformas" Language="C#" MasterPageFile="~/Base1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SistemaECAS.sincronizacion.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Sincronizaci&oacute;n de plataformas.</h2>
    <asp:Label ID="txtError" runat="server"></asp:Label>
<iframe width="100%" height="400px" frameborder="0" scrolling="no" id="iframe_sincronizacion" runat="server"></iframe>
</asp:Content>