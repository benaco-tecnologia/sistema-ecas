using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECAS.mailmasivo
{

    public class envios : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.GridView GridView1;
        protected System.Web.UI.WebControls.Label htmlEnvio;
        protected System.Web.UI.WebControls.Label nombreFormato;
        protected System.Web.UI.WebControls.SqlDataSource SqlDataSource1;

        public envios()
        {
        }

        protected void GridView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.htmlEnvio.Text = "";
            string envioID = this.GridView1.SelectedDataKey.Value.ToString();
            Conexion conn = new Conexion();
            conn.leer("SELECT [html] FROM [matricula].[mailxls_envio] WHERE [id] = " + envioID);
            if (conn.registro())
            {
                this.htmlEnvio.Text = "<fieldset width=\"90%\"><legend>Contenido</legend>" + base.Server.HtmlDecode(conn.Dr["html"].ToString()) + "</fieldset>";
            }

        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["loggeado"] == null)
                    Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["urlRoot"].ToString() + "/ingreso.aspx", true);
                Session.Remove("editar_formato_id");
                htmlEnvio.Text = "";
            }
        }

    } // class envios

}

