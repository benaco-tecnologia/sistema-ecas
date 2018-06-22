using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECAS
{
    public class exito : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Button Button1;
        protected System.Web.UI.WebControls.Label Label1;

        public exito()
        {
        }

        protected void Button1_Click(object sender, System.EventArgs e)
        {
            base.Response.Redirect("Default.aspx", true);
            base.Response.End();
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (this.Session["loggeado"] == null)
            {
                base.Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["urlRoot"].ToString() + "/ingreso.aspx", true);
            }

            if (!this.IsPostBack)
            {
                Label1.Text = this.Session["destinatarios"].ToString();
                this.Session.Remove("formato_id");
                this.Session.Remove("formato_nombre");
                this.Session.Remove("archivo_excel");
                this.Session.Remove("mail_subject");
                this.Session.Remove("formato_html");
            }
        }
    }
}

