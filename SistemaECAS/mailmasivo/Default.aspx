<%@ Page Title="" Language="C#" MasterPageFile="~/Base1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SistemaECAS.mailmasivo.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Env&iacute;o masivo de emails</h2>
    <asp:Label ID="txtError" runat="server"></asp:Label>
    <div runat="server" id="contendor">
    <p>Seleccione un formato de env&iacute;o: 
        <asp:DropDownList ID="DropDownList1" runat="server" 
            DataSourceID="SqlDataSource1" DataTextField="nombre" DataValueField="id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:BaseSqlServer %>" 
            SelectCommand="SELECT [nombre], [id] FROM [matricula].[mailxls_formato] ORDER BY [nombre]">
        </asp:SqlDataSource>
        <br />
        <a href="crearFormato.aspx">Crear nuevo formato</a>
    </p>
    <p style="text-align: right;">
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Aceptar" />
    </p>
    </div>
</asp:Content>