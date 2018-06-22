<%@ Page Title="SG Ecas | Ficha egresado" Language="C#" MasterPageFile="~/Base1.Master" AutoEventWireup="true" CodeBehind="fichaEgresado.aspx.cs" Inherits="FichaEgresado.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Ficha Egresado</h2>
    <a href="./buscarEgresado.aspx">Buscar otro egresado</a>
    <asp:Table ID="datosPersonales" runat="server" CellPadding="5" CellSpacing="0" Width="650px">
    <asp:TableHeaderRow>
        <asp:TableHeaderCell Text="Datos personales" ColumnSpan="2"></asp:TableHeaderCell>
    </asp:TableHeaderRow>
        <asp:TableRow runat="server">
            <asp:TableCell Text="Nombre"></asp:TableCell>
            <asp:TableCell ID="nombre"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell Text="Rut"></asp:TableCell>
            <asp:TableCell ID="rut"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell Text="Numero Ecas"></asp:TableCell>
            <asp:TableCell ID="numeroecas"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell Text="Fecha Nacimiento"></asp:TableCell>
            <asp:TableCell ID="fechanacimiento"></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow runat="server">
            <asp:TableCell Text="Direcci&oacute;n"></asp:TableCell>
            <asp:TableCell ID="direccion"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow  runat="server">
            <asp:TableCell Text="Direcci&oacute;n laboral"></asp:TableCell>
            <asp:TableCell ID="direccionLaboral"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell Text="Tel&eacute;fono"></asp:TableCell>
            <asp:TableCell ID="telefono"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell Text="Correo"></asp:TableCell>
            <asp:TableCell ID="correo"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell Text="Estado acad&eacute;mico"></asp:TableCell>
            <asp:TableCell ID="estacad"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell Text="A&ntilde;o ingreso"></asp:TableCell>
            <asp:TableCell ID="anoingreso"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell Text="A&ntilde;o egreso"></asp:TableCell>
            <asp:TableCell ID="anoegreso"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell Text="A&ntilde;o titulacion"></asp:TableCell>
            <asp:TableCell ID="anotitulacion"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:HyperLink Text="" ID="hlDatosPersonales" runat="server"><asp:Image ID="Image4" ImageUrl="imagenes/page_edit.png" runat="server" ImageAlign="AbsMiddle" /> Modificar datos personales</asp:HyperLink>
    <br />
    <asp:Table ID="historiaLaboral" runat="server" CellPadding="5" CellSpacing="0" 
        Width="650px">
    <asp:TableHeaderRow>
        <asp:TableHeaderCell Text="Historial Laboral" ColumnSpan="4"></asp:TableHeaderCell>
    </asp:TableHeaderRow>
    <asp:TableRow ID="titulosLaboral" Visible="false">
        <asp:TableHeaderCell Text="Período"></asp:TableHeaderCell>
        <asp:TableHeaderCell Text="Cargo/Empresa"></asp:TableHeaderCell>
        <asp:TableHeaderCell Text="Rango renta"></asp:TableHeaderCell>
        <asp:TableHeaderCell Text="Responsabilidades"></asp:TableHeaderCell>
    </asp:TableRow>
    </asp:Table>
    <asp:HyperLink Text="" ID="linkAgregarExperiencia" runat="server"><asp:Image ID="Image3" ImageUrl="imagenes/add.png" runat="server" ImageAlign="AbsMiddle" /> Agregar experiencia</asp:HyperLink>
    <br />
    <asp:Table ID="estudioExtra" runat="server" CellPadding="5" CellSpacing="0" Width="650px">
    <asp:TableHeaderRow>
        <asp:TableHeaderCell Text="Estudios" ColumnSpan="3"></asp:TableHeaderCell>
    </asp:TableHeaderRow>
    <asp:TableRow ID="tituloEstudio" Visible="false">
        <asp:TableHeaderCell Text="Año"></asp:TableHeaderCell>
        <asp:TableHeaderCell Text="Título/Institución"></asp:TableHeaderCell>
        <asp:TableHeaderCell Text="Tipo"></asp:TableHeaderCell>
    </asp:TableRow>
    </asp:Table>
    <asp:HyperLink Text="" ID="linkAgregarEstudio" runat="server"><asp:Image ID="Image2" ImageUrl="imagenes/add.png" runat="server" ImageAlign="AbsMiddle" /> Agregar estudios</asp:HyperLink>
    <br />
    <asp:Table ID="idiomas" runat="server" CellPadding="5" CellSpacing="0" Width="650px">
    <asp:TableHeaderRow>
        <asp:TableHeaderCell Text="Idiomas" ColumnSpan="3"></asp:TableHeaderCell>
    </asp:TableHeaderRow>
    <asp:TableRow ID="tituloIdioma" Visible="false">
        <asp:TableHeaderCell Text="Idioma"></asp:TableHeaderCell>
        <asp:TableHeaderCell Text="Nivel escrito"></asp:TableHeaderCell>
        <asp:TableHeaderCell Text="Nivel oral"></asp:TableHeaderCell>
    </asp:TableRow>
    </asp:Table>
    <asp:HyperLink ID="linkAgregarIdioma" runat="server"><asp:Image ImageUrl="imagenes/add.png" runat="server" ImageAlign="AbsMiddle" /> Agregar idioma</asp:HyperLink>
    <br />

    <asp:Table ID="notas" runat="server" CellPadding="5" CellSpacing="0" Width="650px">
    <asp:TableHeaderRow>
        <asp:TableHeaderCell Text="Notas" ColumnSpan="2"></asp:TableHeaderCell>
    </asp:TableHeaderRow>
    <asp:TableRow ID="tituloNota" Visible="false">
        <asp:TableHeaderCell Text="Fecha" Width="150"></asp:TableHeaderCell>
        <asp:TableHeaderCell Text="Nota"></asp:TableHeaderCell>
    </asp:TableRow>
    </asp:Table>
    <asp:HyperLink Text="" ID="linkAgregarNota" runat="server"><asp:Image ID="Image1" ImageUrl="imagenes/add.png" runat="server" ImageAlign="AbsMiddle" /> Agregar nota</asp:HyperLink>
</asp:Content>
