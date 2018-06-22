<%@ Page Title="" Language="C#" MasterPageFile="~/Base1.Master" AutoEventWireup="true" CodeBehind="envios.aspx.cs" Inherits="SistemaECAS.mailmasivo.envios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <h2>Envíos</h2>
          Registro de envíos.<br />
    <br /><asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        DataSourceID="SqlDataSource1" EnableModelValidation="True" 
        GridLines="Vertical" PageSize="5" HorizontalAlign="Center" DataKeyNames="id"
        onselectedindexchanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
        <asp:BoundField DataField="id" HeaderText="ID" Visible="false"
                SortExpression="id" />
            <asp:BoundField DataField="fecha_envio" HeaderText="Fecha envío" 
                SortExpression="fecha_envio" />
            <asp:BoundField DataField="asunto" HeaderText="Asunto" 
                SortExpression="asunto" />
                 <asp:BoundField DataField="remitente" HeaderText="Remitente" 
                SortExpression="remitente" />
            <asp:BoundField DataField="destinatarios" HeaderText="# destinatarios" 
                SortExpression="destinatarios" />           
            <asp:BoundField DataField="formato" HeaderText="Formato" Visible="false"
                SortExpression="formato" />

            <asp:CommandField SelectText="Ver contenido" ShowSelectButton="True" />

        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:BaseSqlServer %>"
        SelectCommand="SELECT [id], [destinatarios], [fecha_envio], [remitente], [asunto], [formato] FROM [matricula].[mailxls_envio] ORDER BY [fecha_envio] DESC">
    </asp:SqlDataSource>
    <asp:Label ID="nombreFormato" runat="server"></asp:Label>
    <asp:Label ID="htmlEnvio" runat="server"></asp:Label>
    </asp:Content>