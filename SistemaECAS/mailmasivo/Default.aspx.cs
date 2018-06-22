using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SistemaECAS.mailmasivo
{

    public class Default : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.Button Button1;
        protected System.Web.UI.HtmlControls.HtmlGenericControl contendor;
        protected System.Web.UI.WebControls.DropDownList DropDownList1;
        protected System.Web.UI.WebControls.SqlDataSource SqlDataSource1;
        protected System.Web.UI.WebControls.Label txtError;

        public Default()
        {
        }

        protected void Button1_Click(object sender, System.EventArgs e)
        {
            this.Session.Add("formato_id", this.DropDownList1.SelectedItem.Value);
            this.Session.Add("formato_nombre", this.DropDownList1.SelectedItem.Text);
            base.Response.Redirect("subirArchivo.aspx", true);

        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (Session["loggeado"] == null)
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["urlRoot"].ToString() + "/ingreso.aspx", true);
            if (Session["correo"].ToString().Equals("1"))
            {
                txtError.Text = "No tiene permisos para acceder a esta p\u00E1gina";
                contendor.InnerText = "";
                return;
            }
            Session.Remove("editar_formato_id");
            Session.Add("remitente_mail", System.String.Concat(Session["login"], "@ecas.cl"));
            Session.Add("remitente", Session["nombre"] + " <" + Session["login"] + "@ecas.cl>");
            Session.Add("remitente_nombre", Session["nombre"]);
        }

    } // class Default

}

