using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SistemaECAS.certificados
{

    public class Default : System.Web.UI.Page
    {

        protected System.Web.UI.HtmlControls.HtmlGenericControl iframe_certificados;
        protected System.Web.UI.WebControls.Label txtError;

        public Default()
        {
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            System.Random random = new System.Random();
            int rnd = random.Next(1000000, 9999999);
            string path_certificado = System.Configuration.ConfigurationManager.AppSettings["path_certificados"].ToString();
            switch (System.Convert.ToInt32(Session["certificado"].ToString()))
            {
                case 1:
                    txtError.Text = "No tiene permisos para acceder a esta p\u00E1gina";
                    iframe_certificados.Visible = false;
                    return;

                case 2:
                    iframe_certificados.Attributes["src"] = path_certificado + "?ClientID=" + rnd.ToString() + "&usrcod=user";
                    return;

                case 3:
                    iframe_certificados.Attributes["src"] = path_certificado + "?ClientID=" + rnd.ToString() + "&usrcod=admin";
                    break;
            }
        }

    } // class Default

}

