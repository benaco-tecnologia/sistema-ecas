<%@ Page Title="" Language="C#" MasterPageFile="~/Base1.Master" AutoEventWireup="true" CodeBehind="~/mailmasivo/exito.aspx.cs" Inherits="SistemaECAS.exito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        El correo ha sido enviado con éxito a <asp:Label ID="Label1" runat="server" Text="Label" /> destinarios.
    </p>
    <p style="text-align: right;">
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Aceptar" />
    </p>
</asp:Content>
