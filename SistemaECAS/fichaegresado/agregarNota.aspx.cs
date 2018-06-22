using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace FichaEgresado
{

    public class WebForm3 : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.Button Button1;
        protected System.Web.UI.WebControls.TextBox nota;
        protected System.Web.UI.WebControls.Label rut;
        private string tabla;

        public WebForm3()
        {
            tabla = System.Configuration.ConfigurationManager.AppSettings["tbPrEg"].ToString();
        }

        protected void Button1_Click(object sender, System.EventArgs e)
        {
            if (this.nota.Text.Trim().Length >= 1)
            {
                string sql = "INSERT INTO EGRESADOnota (rut, nota) VALUES ('" + this.rut.Text + "', '" + this.nota.Text.Trim() + "');";
                SqlConnection adoConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString);
                adoConn.Open();
                new SqlCommand(sql, adoConn).ExecuteNonQuery();
                base.Response.Redirect("./fichaEgresado.aspx?rut=" + this.rut.Text, true);
            }

        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (Session["administrador"].ToString() == "False" && Session["escritura"].ToString() == "False")
            {
                Response.Write("<h2>No tiene suficientes permisos para ver esta p&aacute;gina.</h2>");
                Response.End();
            }
            if (!Page.IsPostBack)
                rut.Text = Request.QueryString["rut"].ToString();
        }

    } // class WebForm3

}

