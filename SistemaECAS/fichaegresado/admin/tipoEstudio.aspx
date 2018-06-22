<%@ Page Title="SG Ecas | Tipo de estudio" Language="C#" MasterPageFile="~/Base1.Master" AutoEventWireup="true" CodeBehind="tipoEstudio.aspx.cs" Inherits="FichaEgresado.admin.tipoEstudio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 158px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Grados acad&eacute;micos</h2>
    Administración grados acad&eacute;micos<br /><br /><asp:GridView ID="GridView1" runat="server" 
        AutoGenerateColumns="False" DataKeyNames="tipoEstudioID" 
        DataSourceID="SqlDataSource1" EnableModelValidation="True" 
        GridLines="Vertical" AllowPaging="True" BackColor="White" 
        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" HorizontalAlign="Center" CellPadding="3" CellSpacing="0">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:BoundField DataField="tipoEstudioID" HeaderText="tipoEstudioID" 
                InsertVisible="False" ReadOnly="True" SortExpression="tipoEstudioID" 
                Visible="False" />
            <asp:BoundField DataField="tipo" HeaderText="Grado acad&eacute;mico" 
                SortExpression="tipo" />
            <asp:CommandField ButtonType="Button" CancelText="Cancelar" DeleteText="Borrar" 
                EditText="Modificar" ShowDeleteButton="True" ShowEditButton="True" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:BaseSqlServer %>" 
        DeleteCommand="DELETE FROM [matricula].[EGRESADOtipoEstudio] WHERE [tipoEstudioID] = ?" 
        InsertCommand="INSERT INTO [matricula].[EGRESADOtipoEstudio] ([tipoEstudioID], [tipo]) VALUES (?, ?)"
        SelectCommand="SELECT [tipoEstudioID], [tipo] FROM [matricula].[EGRESADOtipoEstudio]" 
        UpdateCommand="UPDATE [matricula].[EGRESADOtipoEstudio] SET [tipo] = ? WHERE [tipoEstudioID] = ?">
        <DeleteParameters>
            <asp:Parameter Name="tipoEstudioID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="tipoEstudioID" Type="Int32" />
            <asp:Parameter Name="tipo" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="tipo" Type="String" />
            <asp:Parameter Name="tipoEstudioID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
    Ingreso grado acad&eacute;mico<br />
    <table style="width:100%;">
        <tr>
            <td class="style1">
                Grado acad&eacute;mico</td>
            <td>
                <asp:TextBox ID="tipoEstudio_" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Aceptar" onclick="Button1_Click" />
            </td>
        </tr>
    </table>
    <br />

</asp:Content>
