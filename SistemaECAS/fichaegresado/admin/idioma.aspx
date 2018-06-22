<%@ Page Title="SG Ecas | Idiomas" Language="C#" MasterPageFile="~/Base1.Master" AutoEventWireup="true" CodeBehind="idioma.aspx.cs" Inherits="FichaEgresado.admin.idioma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .style1
        {
            width: 158px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Idiomas</h2>
    Seleccione un idioma para modificar o eliminar<br />
    <br />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="idiomaID" DataSourceID="SqlDataSource1" 
        EnableModelValidation="True" BackColor="White" BorderColor="#999999" 
        BorderStyle="None" BorderWidth="1px" GridLines="Vertical" 
        HorizontalAlign="Center" AllowPaging="True" CellPadding="3" CellSpacing="0">
    <AlternatingRowStyle BackColor="#DCDCDC" />
    <Columns>
        <asp:BoundField DataField="idioma" HeaderText="Idioma" 
            SortExpression="idioma" />
        <asp:BoundField DataField="idiomaID" HeaderText="idiomaID" 
            InsertVisible="False" ReadOnly="True" SortExpression="idiomaID" 
            Visible="False" />
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
        DeleteCommand="DELETE FROM [matricula].[EGRESADOidioma] WHERE [idiomaID] = ?" 
        InsertCommand="INSERT INTO [matricula].[EGRESADOidioma] ([idioma], [idiomaID]) VALUES (?, ?)"
        SelectCommand="SELECT [idioma], [idiomaID] FROM [matricula].[EGRESADOidioma]" 
        UpdateCommand="UPDATE [matricula].[EGRESADOidioma] SET [idioma] = ? WHERE [idiomaID] = ?">
        <DeleteParameters>
            <asp:Parameter Name="idiomaID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="idioma" Type="String" />
            <asp:Parameter Name="idiomaID" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="idioma" Type="String" />
            <asp:Parameter Name="idiomaID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
    <br />
    <table style="width:100%;">
        <tr>
            <td class="style1">
                Ïngrese idioma</td>
            <td>
                <asp:TextBox ID="idioma_" runat="server"></asp:TextBox>
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
