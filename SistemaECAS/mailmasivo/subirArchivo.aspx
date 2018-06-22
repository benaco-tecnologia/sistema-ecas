<%@ Page Title="" Language="C#" MasterPageFile="~/Base1.Master" AutoEventWireup="true" CodeBehind="subirArchivo.aspx.cs" Inherits="SistemaECAS.mailmasivo.subirArchivo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 261px;
            height: 217px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    <p>
        Ingrese Asunto del correo</p>
    <p>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
    <p>
        Seleccione archivo excel con los destinatarios</p>
    <p>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:RegularExpressionValidator ID="FileUpLoadValidator" runat="server" ErrorMessage="Debe seleccionar un archivo Excel .xls" 
            ValidationExpression="^.+\.((xls)|(XLS))$"
            Display="Dynamic" ControlToValidate="FileUpload1" />
    </p>
    <p style="text-align: right;">        
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Atrás" />&nbsp;
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Aceptar" />
    </p>
    <p>
        * para un correcto funcionamiento del sistema, el archivo excel debe tener al 
        menos una columna con los <strong>correos</strong> y otra con los <strong>
        nombres</strong>, además de tener la hoja activa con el nombre <strong>Hoja1
        </strong>tal como lo muestra la figura:
    </p>
    <p align="center">
        <img class="style1" src="ejemplo.png" alt="Captura de ejemplo de archivo excel" />
    </p>
</asp:Content>