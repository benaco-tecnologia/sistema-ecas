<%@ Page Title="" Language="C#" MasterPageFile="~/Base1.Master" TraceMode="SortByTime" AutoEventWireup="true" CodeBehind="agregarEstudio.aspx.cs" Inherits="FichaEgresado.agregarEstudio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style3
        {
            width: 21%;
        }
        .style5
        {
            width: 4px;
        }
        .style6
        {
            width: 6%;
        }
        .style7
        {
            width: 21%;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:HiddenField ID="estudioExtraID" runat="server" Value="" />
    <table style="width: 100%;">
        <tr>
            <td class="style7">
                Título</td>
            <td colspan="2">
                <asp:TextBox ID="titulo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <b>Institución</b></td>
            <td colspan="2">
                <asp:TextBox ID="institucion" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <b>Año egreso</b></td>
            <td class="style6">
                <asp:DropDownList ID="egreso" runat="server">
                </asp:DropDownList>
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                <b>Grado</b></td>
            <td colspan="2">
                <asp:DropDownList ID="tipoEstudioID" runat="server" DataSourceID="SqlDataSource1" 
                    DataTextField="tipo" DataValueField="tipoEstudioID" Width="171px"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:BaseSqlServer %>" 
                    SelectCommand="SELECT [tipoEstudioID], [tipo] FROM matricula.EGRESADOtipoEstudio ORDER BY [tipo]">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Aceptar" onclick="Button1_Click" />
            </td>
        </tr>
    </table>
    <p>Modificando usuario <asp:Label ID="rut" runat="server"></asp:Label></p>
</asp:Content>
