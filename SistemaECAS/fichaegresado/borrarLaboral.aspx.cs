using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace FichaEgresado
{

    public class borrarLaboral : System.Web.UI.Page
    {

        protected System.Web.UI.HtmlControls.HtmlForm form1;

        public borrarLaboral()
        {
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (Session["administrador"].ToString() == "False" && Session["escritura"].ToString() == "False")
            {
                Response.Write("<h2>No tiene suficientes permisos para ver esta p&aacute;gina.</h2>");
                Response.End();
            }
            string rut = Request.QueryString["rut"].ToString();
            string historiaLaboralID = Request.QueryString["historiaLaboralID"].ToString();
            string sql = "DELETE FROM EGRESADOhistoriaLaboral WHERE rut = '" + rut + "' AND historiaLaboralID = '" + historiaLaboralID + "';";
            System.Data.SqlClient.SqlConnection adoConn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString);
            adoConn.Open();
            System.Data.SqlClient.SqlCommand adoCmd = new System.Data.SqlClient.SqlCommand(sql, adoConn);
            adoCmd.ExecuteNonQuery();
            Response.Redirect("./fichaEgresado.aspx?rut=" + rut, true);
        }

    } // class borrarLaboral

}

