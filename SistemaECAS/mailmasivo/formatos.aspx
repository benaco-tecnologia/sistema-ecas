<%@ Page Title="" Language="C#" MasterPageFile="~/Base1.Master" AutoEventWireup="true" CodeBehind="formatos.aspx.cs" Inherits="SistemaECAS.mailmasivo.formatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Formatos</h2>
        Seleccione el formato que desea eliminar.<br />
    <br />
    <asp:GridView ID="GridView1" 
            runat="server" AllowSorting="True" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" DataKeyNames="id" DataSourceID="SqlDataSource1" 
            EnableModelValidation="True" GridLines="Vertical" HorizontalAlign="Center" 
            AllowPaging="True" Width="50%" OnSelectedIndexChanged="EditarFormato">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="#" InsertVisible="False" 
                    ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" 
                    SortExpression="nombre" />
                <asp:BoundField DataField="campos" HeaderText="# campos" 
                    SortExpression="campos" />
                <asp:CommandField ButtonType="Button" CancelText="Cancelar" DeleteText="Borrar" 
                    EditText="Modificar" SelectText="Modificar" ShowSelectButton="True" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:BaseSqlServer %>" 
            DeleteCommand="DELETE FROM [matricula].[mailxls_formato] WHERE [id] = ?" 
            InsertCommand="INSERT INTO [matricula].[mailxls_formato] ([id], [nombre], [campos]) VALUES (?, ?, ?)"
            SelectCommand="SELECT [id], [nombre], [campos] FROM [matricula].[mailxls_formato] ORDER BY [nombre]" 
            UpdateCommand="UPDATE [matricula].[mailxls_formato] SET [nombre] = ?, [campos] = ? WHERE [id] = ?">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="id" Type="Int32" />
                <asp:Parameter Name="nombre" Type="String" />
                <asp:Parameter Name="campos" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="nombre" Type="String" />
                <asp:Parameter Name="campos" Type="Int32" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        <a href="crearFormato.aspx">Crear nuevo formato</a>
</asp:Content>
