using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;

namespace SistemaECAS
{
    public class Default : Page
    {
        public Default()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack && base.Session["loggeado"] == null)
            {
                base.Response.Redirect(String.Concat(ConfigurationManager.AppSettings["urlRoot"].ToString(), "/ingreso.aspx"), true);
            }
        }
    }

}
