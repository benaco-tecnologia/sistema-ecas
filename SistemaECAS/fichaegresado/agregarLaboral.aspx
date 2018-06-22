<%@ Page Title="" Language="C#" MasterPageFile="~/Base1.Master" AutoEventWireup="true" CodeBehind="agregarLaboral.aspx.cs" Inherits="FichaEgresado.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style3
        {
            width: 8%;
        }
        .style7
        {
            font-weight: bold;
            letter-spacing: 1px;
            width: 8%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="historiaLaboralID" runat="server" Value="" />
    <table style="width: 100%;">
        <tr>
            <td class="style3">
                <b>Cargo</b></td>
            <td>
                <asp:TextBox ID="cargo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <b>Empresa</b></td>
            <td>
                <asp:TextBox ID="empresa" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
        <td class="style7">
            Direccion empresa</td>
        
            <td colspan="2" class="subtitulo">Calle<br /><asp:TextBox ID="diractualLaboral" runat="server" Width="80%"></asp:TextBox><br /><br />
            Comuna<br /><asp:TextBox ID="comunaLaboral" runat="server" Width="80%"></asp:TextBox><br /><br />
            Ciudad<br /><asp:TextBox ID="ciudadactLaboral" runat="server" Width="80%"></asp:TextBox></td>
        </tr>




        <tr>
            <td class="style3">
                <b>Período</b>
               </td>
            <td class="subtitulo">
                Desde<br />
                <asp:DropDownList ID="desdeMes" runat="server">
                    <asp:ListItem Value="1">Enero</asp:ListItem>
                    <asp:ListItem Value="2">Febrero</asp:ListItem>
                    <asp:ListItem Value="3">Marzo</asp:ListItem>
                    <asp:ListItem Value="4">Abril</asp:ListItem>
                    <asp:ListItem Value="5">Mayo</asp:ListItem>
                    <asp:ListItem Value="6">Junio</asp:ListItem>
                    <asp:ListItem Value="7">Julio</asp:ListItem>
                    <asp:ListItem Value="8">Agosto</asp:ListItem>
                    <asp:ListItem Value="9">Septiembre</asp:ListItem>
                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                </asp:DropDownList> <asp:DropDownList ID="desdeAnio" runat="server">
                </asp:DropDownList><br /><br />
            
                Hasta<br />
                <asp:DropDownList ID="hastaMes" runat="server">
                <asp:ListItem Value="1">Enero</asp:ListItem>
                    <asp:ListItem Value="2">Febrero</asp:ListItem>
                    <asp:ListItem Value="3">Marzo</asp:ListItem>
                    <asp:ListItem Value="4">Abril</asp:ListItem>
                    <asp:ListItem Value="5">Mayo</asp:ListItem>
                    <asp:ListItem Value="6">Junio</asp:ListItem>
                    <asp:ListItem Value="7">Julio</asp:ListItem>
                    <asp:ListItem Value="8">Agosto</asp:ListItem>
                    <asp:ListItem Value="9">Septiembre</asp:ListItem>
                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                </asp:DropDownList> <asp:DropDownList ID="hastaAnio" runat="server">
                </asp:DropDownList>
            &nbsp;(<asp:CheckBox ID="trabajando" runat="server" oncheckedchanged="trabajando_CheckedChanged" />todavía trabaja)</td>
        </tr>
        <tr>
            <td class="style3">
                <b>Rango de renta</b></td>
            <td>
                <asp:DropDownList ID="rangoRenta" runat="server" DataSourceID="SqlDataSource1" 
                    DataTextField="Rango" DataValueField="rangoRentaID" Width="171px"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:BaseSqlServer %>"
                    SelectCommand="SELECT rangoRentaID, montoDesde + ' - ' + montoHasta AS Rango FROM matricula.EGRESADOrangoRenta">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <b>Responsabilidades</b></td>
            <td>
                <asp:TextBox ID="responsabilidades" runat="server" Height="100px" TextMode="MultiLine" 
                     Width="80%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Aceptar" onclick="Button1_Click" />
            </td>
        </tr>
    </table>
    <p>Modificando usuario <asp:Label ID="rut" runat="server"></asp:Label></p>
</asp:Content>
