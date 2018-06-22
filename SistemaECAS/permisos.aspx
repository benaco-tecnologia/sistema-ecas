<%@ Page Title="" Language="C#" MasterPageFile="~/Base1.Master" AutoEventWireup="true" CodeBehind="permisos.aspx.cs" Inherits="SistemaECAS.mailmasivo.remitentes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Permisos</h2>
    En la tabla se muestran los usuarios tienen permisos personalizados (Los usuarios no personalizados tiene acceso de lectura).<br />
    <br />
    Ingrese usuario que desea personalizar:
    <asp:TextBox ID="txtCorreo" runat="server" style="width: 128px"></asp:TextBox>&nbsp;@ecas.cl&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnAgregar" runat="server" Text="Aceptar" 
        onclick="btnAgregar_Click" />
    <p>&nbsp;</p>
    <div runat="server" id="permisos_div" visible="true">
        <asp:Table ID="permisos" runat="server" CellPadding="3" CellSpacing="0" HorizontalAlign="Center">
            <asp:TableHeaderRow BackColor="#000084" Font-Bold="True" ForeColor="White">
                <asp:TableHeaderCell Text="Asignación de Permisos" ID="headerTable" ColumnSpan="7"></asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow ID="titulos" Visible="true" BackColor="#000084" Font-Bold="True" ForeColor="White">
                <asp:TableHeaderCell Text="Usuario"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Sistema/Administración"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Correo Masivo"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Ficha Egresado"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Sincronización"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Certificados"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Última actualización"></asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>
        <p style="text-align: right;">
            <asp:Button ID="btnPermisos" runat="server" Text=" Aceptar " 
                onclick="btnPermisos_Click" />
        </p>
    </div>
    <!-- 

    Certificados
    Correos Masivos
    Ficha Egresado
    Sistema ECAS

    Sin Acceso
    Lectura
    Escritura
    Administrador

    -->
</asp:Content>