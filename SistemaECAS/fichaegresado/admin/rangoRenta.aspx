<%@ Page Title="SG Ecas | Rango renta" Language="C#" MasterPageFile="~/Base1.Master" AutoEventWireup="true" CodeBehind="rangoRenta.aspx.cs" Inherits="FichaEgresado.admin.rangoRenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Rango renta</h2>
    Administración rangos de renta<br /><br />
    <asp:GridView ID="GridView1" 
        runat="server" AutoGenerateColumns="False" DataKeyNames="rangoRentaID" DataSourceID="SqlDataSource1" 
        EnableModelValidation="True" GridLines="Vertical" AllowPaging="True" BackColor="White" BorderColor="#999999"
        BorderStyle="None" BorderWidth="1px" HorizontalAlign="Center" CellPadding="3" CellSpacing="0">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:BoundField DataField="rangoRentaID" HeaderText="rangoRentaID" 
                InsertVisible="False" ReadOnly="True" ShowHeader="False" 
                SortExpression="rangoRentaID" Visible="False" />
            <asp:BoundField DataField="montoDesde" HeaderText="Desde" 
                SortExpression="montoDesde" />
            <asp:BoundField DataField="montoHasta" HeaderText="Hasta" 
                SortExpression="montoHasta" />
            <asp:CommandField ButtonType="Button" CancelText="Cancelar" DeleteText="Borrar" 
                EditText="Modificar" ShowDeleteButton="True" ShowEditButton="True" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" 
        runat="server" ConnectionString="<%$ ConnectionStrings:BaseSqlServer %>" 
        DeleteCommand="DELETE FROM [matricula].[EGRESADOrangoRenta] WHERE [rangoRentaID] = ?" 
        InsertCommand="INSERT INTO [matricula].[EGRESADOrangoRenta] ([montoDesde], [montoHasta]) VALUES (?, ?)"
        SelectCommand="SELECT [rangoRentaID], [montoDesde], [montoHasta] FROM [matricula].[EGRESADOrangoRenta]" 
        UpdateCommand="UPDATE [matricula].[EGRESADOrangoRenta] SET [montoDesde] = ?, [montoHasta] = ? WHERE [rangoRentaID] = ?">
        <DeleteParameters>
            <asp:Parameter Name="rangoRentaID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="montoDesde" Type="String" />
            <asp:Parameter Name="montoHasta" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="montoDesde" Type="String" />
            <asp:Parameter Name="montoHasta" Type="String" />
            <asp:Parameter Name="rangoRentaID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
    Ingreso de nuevo rango<br />
    <table style="width:100%;">
        <tr>
            <td>
                Desde</td>
            <td>
                <asp:TextBox ID="montoDesde" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Hasta</td>
            <td>
                <asp:TextBox ID="montoHasta" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Aceptar" onclick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>