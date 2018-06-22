<%@ Page Title="" Language="C#" MasterPageFile="~/Base1.Master" AutoEventWireup="true" CodeBehind="seleccionarAdjuntos.aspx.cs" Inherits="SistemaECAS.mailmasivo.seleccionarAdjuntos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript" language="javascript">
//<![CDATA[
    $(document).ready(function () {
        var i = 2;
        $('#agregarArchivo').click(function () {
            var fileUpload = '<br /><input type="file" name="File" runat="server" />';
            $('#listadoArchivos').append(fileUpload);
            i++;
        });
    });
//]]>
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    <p>Seleccione archivos a adjuntar:</p>
    <p id="listadoArchivos">
         <input type="file" name="file" runat="server" />
    </p>
    <input type="button" id="agregarArchivo" value="Adjuntar otro archivo" />
    <p style="text-align: right;">
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Volver" />&nbsp;
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Continuar" />
    </p>
</asp:Content>
