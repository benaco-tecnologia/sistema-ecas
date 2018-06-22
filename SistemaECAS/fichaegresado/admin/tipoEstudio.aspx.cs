using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FichaEgresado.admin
{

    public class tipoEstudio : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.Button Button1;
        protected System.Web.UI.WebControls.GridView GridView1;
        protected System.Web.UI.WebControls.SqlDataSource SqlDataSource1;
        protected System.Web.UI.WebControls.TextBox tipoEstudio_;

        public tipoEstudio()
        {
        }

        protected void Button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                string tipoEstudio = tipoEstudio_.Text;
                string sql = "INSERT INTO EGRESADOtipoEstudio (tipo) VALUES ('" + tipoEstudio + "');";
                System.Data.SqlClient.SqlConnection adoConn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString);
                adoConn.Open();
                System.Data.SqlClient.SqlCommand adoCmd = new System.Data.SqlClient.SqlCommand(sql, adoConn);
                adoCmd.ExecuteNonQuery();
                GridView1.DataBind();
            }
            catch (System.Exception)
            {
            }
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if ((this.Session["administrador"].ToString() == "False") && (this.Session["escritura"].ToString() == "False"))
            {
                base.Response.Write("<h2>No tiene suficientes permisos para ver esta p&aacute;gina.</h2>");
                base.Response.End();
            }

        }

    } // class tipoEstudio

}

