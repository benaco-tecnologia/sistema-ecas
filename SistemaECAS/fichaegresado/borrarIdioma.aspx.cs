using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;

namespace FichaEgresado
{

    public class borrarIdioma : System.Web.UI.Page
    {

        protected System.Web.UI.HtmlControls.HtmlForm form1;

        public borrarIdioma()
        {
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if ((this.Session["administrador"].ToString() == "False") && (this.Session["escritura"].ToString() == "False"))
            {
                base.Response.Write("<h2>No tiene suficientes permisos para ver esta p&aacute;gina.</h2>");
                base.Response.End();
            }
            string rut = base.Request.QueryString["rut"].ToString();
            string idiomaID = base.Request.QueryString["id"].ToString();
            string sql = "DELETE FROM EGRESADOidiomas WHERE rut = '" + rut + "' AND idiomaID = '" + idiomaID + "';";
            SqlConnection adoConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString);
            adoConn.Open();
            new SqlCommand(sql, adoConn).ExecuteNonQuery();
            base.Response.Redirect("./fichaEgresado.aspx?rut=" + rut, true);

        }

    } // class borrarIdioma

}

