using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
//OnSelectedIndexChanged="EditarFormato"
namespace SistemaECAS.mailmasivo
{

    public class formatos : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.GridView GridView1;
        protected System.Web.UI.WebControls.SqlDataSource SqlDataSource1;

        public formatos()
        {
        }

        protected void EditarFormato(object sender, System.EventArgs e)
        {
            this.Session.Remove("editar_formato_id");
            this.Session.Add("editar_formato_id", this.GridView1.SelectedDataKey.Value.ToString());
            base.Response.Redirect("crearFormato.aspx");
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (Session["loggeado"] == null)
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["urlRoot"].ToString() + "/ingreso.aspx", true);
            if (Session["administrador"].ToString() == "False" && Session["escritura"].ToString() == "False")
            {
                Response.Write("<h2>No tiene suficientes permisos para ver esta p&aacute;gina.</h2>");
                Response.End();
            }
            if (!IsPostBack)
            {
                GridView1.SelectedIndex = -1;
                GridView1.DataBind();
            }
        }

    } // class formatos

}

