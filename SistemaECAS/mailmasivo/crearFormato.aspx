<%@ Page Title="" Language="C#" MasterPageFile="~/Base1.Master" AutoEventWireup="true" CodeBehind="crearFormato.aspx.cs" Inherits="SistemaECAS.mailmasivo.crearFormato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <!-- TinyMCE -->
<script type="text/javascript" src="jscripts/tiny_mce/tiny_mce.js"></script>
<script type="text/javascript">
    tinyMCE.init({
        mode: "textareas",
        theme: "advanced",
        theme_advanced_toolbar_location: "top",
        theme_advanced_resizing: true,
        theme_advanced_toolbar_align: "left",
        theme_advanced_statusbar_location: "bottom",

        theme_advanced_buttons2: "cut,copy,paste,pasteword,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,image,cleanup,code,|,forecolor,backcolor"
    });
</script>
<!-- /TinyMCE -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    <p><asp:Label ID="lblNombre" runat="server" Text="Nombre del formato"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
    <p style="margin-bottom: 10px;">
    <!-- Gets replaced with TinyMCE, remember HTML in a textarea should be encoded -->
    <asp:TextBox ID="elm1" runat="server" Height="400px" TextMode="MultiLine" 
        Width="100%" ></asp:TextBox>
        </p>
         <p style="float: right;">
         <asp:Button ID="btnBorrar" runat="server" Text="Borrar formato" BackColor="Red" 
                 BorderColor="Red" onclick="btnBorrar_Click" />
         </p>
	<p style="float: left;">
        <asp:Button ID="btnAceptar" runat="server" onclick="btnAceptar_Click" 
            Text="Aceptar" />
    &nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Atrás" />

       
    </p>
</asp:Content>
