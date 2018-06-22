using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace FichaEgresado.admin
{

    public class rangoRenta : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.Button Button1;
        protected System.Web.UI.WebControls.GridView GridView1;
        protected System.Web.UI.WebControls.TextBox montoDesde;
        protected System.Web.UI.WebControls.TextBox montoHasta;
        protected System.Web.UI.WebControls.SqlDataSource SqlDataSource1;

        public rangoRenta()
        {
        }

        protected void Button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                string montoDesde_ = this.montoDesde.Text;
                string montoHasta_ = this.montoHasta.Text;
                string sql = "INSERT INTO EGRESADOrangoRenta (montoDesde, montoHasta) VALUES ('" + montoDesde_ + "', '" + montoHasta_ + "');";
                SqlConnection adoConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString);
                adoConn.Open();
                new SqlCommand(sql, adoConn).ExecuteNonQuery();
                this.GridView1.DataBind();
            }
            catch (Exception)
            {
            }

        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (Session["administrador"].ToString() == "False" && Session["escritura"].ToString() == "False")
            {
                Response.Write("<h2>No tiene suficientes permisos para ver esta p&aacute;gina.</h2>");
                Response.End();
            }
        }

    } // class rangoRenta

}

