<%@ Page Title="SG Ecas | Buscar egresado" Language="C#" MasterPageFile="~/Base1.Master" AutoEventWireup="true" CodeBehind="buscarEgresado.aspx.cs" Inherits="FichaEgresado.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 120px;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Buscar Egresado</h2>
    <asp:Label ID="txtError" runat="server"></asp:Label>
    <p>Ingrese criterios de b&uacute;squeda.</p>
        <table style="width:50%;" cellpadding="2">
            <tr>
                <td class="style1">
                    Apellido paterno</td>
                <td>
                    <asp:TextBox ID="apellido" runat="server" TabIndex="1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Apellido materno</td>
                <td>
                    <asp:TextBox ID="materno" runat="server" TabIndex="1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Nombre</td>
                <td>
                    <asp:TextBox ID="nombre" runat="server" TabIndex="1"></asp:TextBox>
                </td>
            </tr><tr>
                <td class="style1">
                    RUT</td>
                <td>
                    <asp:TextBox ID="rut" runat="server" TabIndex="2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Número ECAS</td>
                <td>
                    <asp:TextBox ID="numeroEcas" runat="server" TabIndex="3"></asp:TextBox>
                </td>
            </tr>
            
                        <tr>
                <td class="style1">
                    </td>
                <td>
                    <asp:Button ID="btnBuscar" runat="server" Text="Aceptar" 
                        onclick="btnBuscar_Click"  TabIndex="4"/>
                            </td>
            </tr>
        </table>
    <p>&nbsp;</p>
    <div runat="server" id="resultado_div" visible="false">
        <asp:Table ID="resultado" runat="server" CellPadding="3" CellSpacing="0">
            <asp:TableHeaderRow BackColor="#000084" Font-Bold="True" ForeColor="White">
                <asp:TableHeaderCell Text="Resultados" ID="headerTable" ColumnSpan="5"></asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow ID="titulos" Visible="false" BackColor="#000084" Font-Bold="True" ForeColor="White">
                <asp:TableHeaderCell Text="Rut"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Número ECAS"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Nombre"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Año egreso"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Año titulación"></asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</asp:Content>
