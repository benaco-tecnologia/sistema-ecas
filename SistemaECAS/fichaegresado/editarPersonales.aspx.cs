using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FichaEgresado
{

    public class WebForm6 : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.Button Button2;
        protected System.Web.UI.WebControls.TextBox ciudadact;
        protected System.Web.UI.WebControls.TextBox comuna;
        protected System.Web.UI.WebControls.TextBox diractual;
        protected System.Web.UI.WebControls.TextBox fonoact;
        protected System.Web.UI.WebControls.TextBox mail;
        protected System.Web.UI.WebControls.TextBox materno;
        protected System.Web.UI.WebControls.TextBox nombre;
        protected System.Web.UI.WebControls.TextBox paterno;
        protected System.Web.UI.WebControls.Label rut;

        public WebForm6()
        {
        }

        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string sql = "UPDATE MT_CLIENT SET nombre = '" + this.nombre.Text + "', paterno = '" + this.paterno.Text + "', materno = '" + this.materno.Text + "', mail = '" + this.mail.Text + "', diractual = '" + this.diractual.Text + "', comuna = '" + this.comuna.Text + "', ciudadact = '" + this.ciudadact.Text + "', fonoact  = '" + this.fonoact.Text + "' WHERE CODCLI = " + this.rut.Text;
            SqlConnection adoConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString);
            adoConn.Open();
            new SqlCommand(sql, adoConn).ExecuteNonQuery();
            base.Response.Redirect("./fichaEgresado.aspx?rut=" + this.rut.Text, true);

        }

        private void informacionPersonal(string rut)
        {
            string sql = "SELECT rut, nombre, paterno, materno, mail, diractual, comuna, ciudadact, fonoact FROM EGRESADOlistado WHERE rut = " + rut;
            System.Data.SqlClient.SqlConnection adoConn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString);
            adoConn.Open();
            System.Data.SqlClient.SqlCommand adoCmd = new System.Data.SqlClient.SqlCommand(sql, adoConn);
            System.Data.SqlClient.SqlDataReader adoDR = adoCmd.ExecuteReader();
            if (adoDR.HasRows)
            {
                while (adoDR.Read())
                {
                    nombre.Text = adoDR["nombre"].ToString();
                    paterno.Text = adoDR["paterno"].ToString();
                    materno.Text = adoDR["materno"].ToString();
                    diractual.Text = adoDR["diractual"].ToString();
                    comuna.Text = adoDR["comuna"].ToString();
                    ciudadact.Text = adoDR["ciudadact"].ToString();
                    fonoact.Text = adoDR["fonoact"].ToString();
                    mail.Text = adoDR["mail"].ToString();
                }
            }
            adoDR.Close();
            adoConn.Close();
            adoDR = null;
            adoCmd = null;
            adoConn = null;
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (Session["administrador"].ToString() == "False" && Session["escritura"].ToString() == "False")
            {
                Button2.Enabled = false;
                Button2.ToolTip = "No tiene permisos para realizar esta acci\u00F3n.";
            }
            if (!Page.IsPostBack)
            {
                informacionPersonal(Request.QueryString["rut"].ToString());
                rut.Text = Request.QueryString["rut"].ToString();
            }
        }

    } // class WebForm6

}

