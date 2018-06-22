using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FichaEgresado
{

    public class agregarEstudio : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.Button Button1;
        protected System.Web.UI.WebControls.DropDownList egreso;
        protected System.Web.UI.WebControls.HiddenField estudioExtraID;
        protected System.Web.UI.WebControls.TextBox institucion;
        protected System.Web.UI.WebControls.Label rut;
        protected System.Web.UI.WebControls.SqlDataSource SqlDataSource1;
        private string tabla;
        protected System.Web.UI.WebControls.DropDownList tipoEstudioID;
        protected System.Web.UI.WebControls.TextBox titulo;

        public agregarEstudio()
        {
            tabla = System.Configuration.ConfigurationManager.AppSettings["tbPrEg"].ToString();
        }

        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string sql, mensaje;

            string tipoEstudioID = this.tipoEstudioID.SelectedItem.Value;
            string egreso = this.egreso.SelectedItem.Value;
            string institucion = this.institucion.Text;
            string titulo = this.titulo.Text;
            if (estudioExtraID.Value.Length < 1)
            {
                mensaje = "INSERT";
                sql = "INSERT INTO " + tabla + "estudioExtra (rut, egreso, institucion, titulo, tipoEstudioID) VALUES ('" + rut.Text + "', '" + egreso + "', '" + institucion + "', '" + titulo + "', '" + tipoEstudioID + "');";
            }
            else
            {
                mensaje = "UPDATE";
                sql = "UPDATE " + tabla + "estudioExtra SET egreso = '" + egreso + "', institucion = '" + institucion + "', titulo = '" + titulo + "', tipoEstudioID = '" + tipoEstudioID + "' WHERE estudioExtraID = '" + estudioExtraID.Value + "';";
            }
            System.Data.SqlClient.SqlConnection adoConn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString);
            adoConn.Open();
            System.Data.SqlClient.SqlCommand adoCmd = new System.Data.SqlClient.SqlCommand(sql, adoConn);
            Trace.Write(sql);
            if (adoCmd.ExecuteNonQuery() > 0)
            {
                System.DateTime dateTime1 = System.DateTime.Now;
                Trace.Write(dateTime1.ToString() + " OK/" + mensaje + " EGRESADOestudioExtra");
            }
            else
            {
                System.DateTime dateTime2 = System.DateTime.Now;
                Trace.Write(dateTime2.ToString() + " NOK/" + mensaje + "EGRESADOestudioExtra");
            }
            Response.Redirect("./fichaEgresado.aspx?rut=" + rut.Text, true);
        }

        private bool completarCampos(string estudioExtraID)
        {
            estudioExtraID = Convert.ToInt32(estudioExtraID).ToString();
            string sql = "SELECT institucion, titulo, tipoEstudioID, egreso FROM " + this.tabla + "estudioExtra WHERE estudioExtraID = '" + estudioExtraID + "';";
            SqlConnection adoConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString);
            adoConn.Open();
            SqlCommand adoCmd = new SqlCommand(sql, adoConn);
            base.Trace.Write(sql);
            SqlDataReader dr = adoCmd.ExecuteReader();
            if (dr.Read())
            {
                this.tipoEstudioID.DataBind();
                this.estudioExtraID.Value = estudioExtraID;
                this.institucion.Text = dr["institucion"].ToString();
                this.titulo.Text = dr["titulo"].ToString();
                this.tipoEstudioID.SelectedIndex = this.tipoEstudioID.Items.IndexOf(this.tipoEstudioID.Items.FindByValue(dr["tipoEstudioID"].ToString()));
                this.egreso.SelectedIndex = this.egreso.Items.IndexOf(this.egreso.Items.FindByValue(dr["egreso"].ToString()));
                return true;
            }
            return false;

        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if ((this.Session["administrador"].ToString() == "False") && (this.Session["escritura"].ToString() == "False"))
            {
                base.Response.Write("<h2>No tiene suficientes permisos para ver esta p&aacute;gina.</h2>");
                base.Response.End();
            }
            if (!this.Page.IsPostBack)
            {
                for (int i = DateTime.Now.Year; i > (DateTime.Now.Year - 60); i--)
                {
                    this.egreso.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                this.rut.Text = base.Request.QueryString["rut"].ToString();
                if (base.Request.QueryString["estudioExtraID"] != null)
                {
                    this.estudioExtraID.Value = base.Request.QueryString["estudioExtraID"].ToString();
                    if (this.completarCampos(base.Request.QueryString["estudioExtraID"].ToString()))
                    {
                        base.Trace.Write(DateTime.Now.ToString() + " OK/SELECT EGRESADOestudioExtra estudioExtraID(" + base.Request.QueryString["estudioExtraID"].ToString() + ")");
                    }
                    else
                    {
                        base.Trace.Write(DateTime.Now.ToString() + " NOK/SELECT EGRESADOestudioExtra estudioExtraID(" + base.Request.QueryString["estudioExtraID"].ToString() + ")");
                    }
                }
            }

        }

    } // class agregarEstudio

}

