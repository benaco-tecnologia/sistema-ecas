using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SistemaECAS.sincronizacion
{

    public class Default : System.Web.UI.Page
    {

        protected System.Web.UI.HtmlControls.HtmlGenericControl iframe_sincronizacion;
        protected System.Web.UI.WebControls.Label txtError;

        public Default()
        {
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            System.Random random = new System.Random();
            int rnd = random.Next(1000000, 9999999);
            string path_sincronizacion = System.Configuration.ConfigurationManager.AppSettings["path_sincronizacion"].ToString();
            if (this.Session["sincronizacion"] != null)
            {
                switch (System.Convert.ToInt32(this.Session["sincronizacion"].ToString()))
                {
                    case 1:
                        txtError.Text = "No tiene permisos para acceder a esta p\u00E1gina";
                        iframe_sincronizacion.Visible = false;
                        return;

                    case 2:
                        iframe_sincronizacion.Attributes["src"] = path_sincronizacion + "?ClientID=" + rnd.ToString() + "&usrcod=user";
                        return;

                    case 3:
                        iframe_sincronizacion.Attributes["src"] = path_sincronizacion + "?ClientID=" + rnd.ToString() + "&usrcod=admin";
                        break;
                }
            }
            else
            {
                if ((this.Session["administrador"].ToString() == "False") && (this.Session["escritura"].ToString() == "False"))
                {
                    base.Response.Write("<h2>No tiene suficientes permisos para ver esta p&aacute;gina.</h2>");
                    base.Response.End();
                }
            }
        }

    } // class Default

}

