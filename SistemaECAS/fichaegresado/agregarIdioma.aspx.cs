using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FichaEgresado
{

    public class WebForm5 : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.Button Button1;
        protected System.Web.UI.WebControls.DropDownList escrito;
        protected System.Web.UI.WebControls.DropDownList idiomaID;
        protected System.Web.UI.WebControls.Label mensaje;
        protected System.Web.UI.WebControls.HiddenField modificacion;
        protected System.Web.UI.WebControls.DropDownList oral;
        protected System.Web.UI.WebControls.Label rut;
        protected System.Web.UI.WebControls.SqlDataSource SqlDataSource1;
        private string tabla;

        public WebForm5()
        {
            tabla = System.Configuration.ConfigurationManager.AppSettings["tbPrEg"].ToString();
        }

        protected void Button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                string sql;
                string mensaje;
                string idiomaID = this.idiomaID.SelectedItem.Value;
                string escrito = this.escrito.SelectedItem.Value;
                string oral = this.oral.SelectedItem.Value;
                if (this.modificacion.Value == "false")
                {
                    mensaje = "INSERT";
                    sql = "INSERT INTO " + this.tabla + "idiomas (rut, idiomaID, oral, escrito) VALUES ('" + this.rut.Text + "', '" + idiomaID + "', '" + oral + "', '" + escrito + "');";
                }
                else
                {
                    mensaje = "UPDATE";
                    sql = "UPDATE " + this.tabla + "idiomas SET oral = '" + oral + "', escrito = '" + escrito + "' WHERE rut = '" + this.rut.Text + "' AND idiomaID = '" + idiomaID + "';";
                }
                SqlConnection adoConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString);
                adoConn.Open();
                SqlCommand adoCmd = new SqlCommand(sql, adoConn);
                base.Trace.Write(sql);
                if (adoCmd.ExecuteNonQuery() > 0)
                {
                    base.Trace.Write(DateTime.Now.ToString() + " OK/" + mensaje + " EGRESADOidiomas");
                }
                else
                {
                    base.Trace.Write(DateTime.Now.ToString() + " NOK/" + mensaje + "EGRESADOidiomas");
                }
            }
            catch (SqlException ex)
            {
                this.mensaje.Text = "OCurri&oacute; un error al ingresar el idioma. " + ex.Message;
            }
            base.Response.Redirect("./fichaEgresado.aspx?rut=" + this.rut.Text, true);

        }

        private bool completarCampos(string idiomaID, string rut)
        {
            int i = System.Convert.ToInt32(idiomaID);
            idiomaID = i.ToString();
            string sql = "SELECT * FROM " + tabla + "idiomas WHERE idiomaID = '" + idiomaID + "' AND rut = '" + rut + "';";
            System.DateTime dateTime = System.DateTime.Now;
            Trace.Write(dateTime.ToString() + " OK/EGRESADOidiomas / CompletarCampos");
            System.Data.SqlClient.SqlConnection adoConn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString);
            adoConn.Open();
            System.Data.SqlClient.SqlCommand adoCmd = new System.Data.SqlClient.SqlCommand(sql, adoConn);
            Trace.Write(sql);
            System.Data.SqlClient.SqlDataReader dr = adoCmd.ExecuteReader();
            if (dr.Read())
            {
                this.idiomaID.DataBind();
                oral.DataBind();
                escrito.DataBind();
                this.idiomaID.SelectedIndex = this.idiomaID.Items.IndexOf(this.idiomaID.Items.FindByValue(dr["idiomaID"].ToString()));
                oral.SelectedIndex = oral.Items.IndexOf(oral.Items.FindByValue(dr["oral"].ToString()));
                escrito.SelectedIndex = escrito.Items.IndexOf(escrito.Items.FindByValue(dr["escrito"].ToString()));
                this.idiomaID.Enabled = false;
            }
            else
            {
                return false;
            }
            return true;
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (Session["administrador"].ToString() == "False" && Session["escritura"].ToString() == "False")
            {
                Response.Write("<h2>No tiene suficientes permisos para ver esta p&aacute;gina.</h2>");
                Response.End();
            }
            if (!Page.IsPostBack)
            {
                rut.Text = Request.QueryString["rut"].ToString();
                if ((Request.QueryString["rut"] != null) && (Request.QueryString["idiomaID"] != null))
                {
                    modificacion.Value = "true";
                    if (completarCampos(Request.QueryString["idiomaID"].ToString(), Request.QueryString["rut"].ToString()))
                    {
                        System.DateTime dateTime1 = System.DateTime.Now;
                        System.Console.WriteLine(dateTime1.ToString() + " OK/SELECT EGRESADOidiomas idiomaID(" + Request.QueryString["idiomaID"].ToString() + ")");
                        return;
                    }
                    System.DateTime dateTime2 = System.DateTime.Now;
                    System.Console.WriteLine(dateTime2.ToString() + " NOK/SELECT EGRESADOidiomas idiomaID(" + Request.QueryString["idiomaID"].ToString() + ")");
                }
            }
        }

    } // class WebForm5

}

