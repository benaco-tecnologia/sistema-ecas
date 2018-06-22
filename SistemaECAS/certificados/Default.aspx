<%@ Page Title="Administraci&oacute;n de certificados." Language="C#" MasterPageFile="~/Base1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SistemaECAS.certificados.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Administraci&oacute;n de certificados.</h2>
<asp:Label ID="txtError" runat="server"></asp:Label>
<iframe width="100%" height="400px" frameborder="0" scrolling="auto" id="iframe_certificados" runat="server"></iframe>
</asp:Content>
