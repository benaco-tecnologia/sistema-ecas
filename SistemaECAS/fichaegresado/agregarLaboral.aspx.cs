using System;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaECAS;

namespace FichaEgresado
{

    public class WebForm4 : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.Button Button1;
        protected System.Web.UI.WebControls.TextBox cargo;
        protected System.Web.UI.WebControls.TextBox ciudadactLaboral;
        protected System.Web.UI.WebControls.TextBox comunaLaboral;
        protected System.Web.UI.WebControls.DropDownList desdeAnio;
        protected System.Web.UI.WebControls.DropDownList desdeMes;
        protected System.Web.UI.WebControls.TextBox diractualLaboral;
        protected System.Web.UI.WebControls.TextBox empresa;
        protected System.Web.UI.WebControls.DropDownList hastaAnio;
        protected System.Web.UI.WebControls.DropDownList hastaMes;
        protected System.Web.UI.WebControls.HiddenField historiaLaboralID;
        protected System.Web.UI.WebControls.DropDownList rangoRenta;
        protected System.Web.UI.WebControls.TextBox responsabilidades;
        protected System.Web.UI.WebControls.Label rut;
        protected System.Web.UI.WebControls.SqlDataSource SqlDataSource1;
        private string tabla;
        protected System.Web.UI.WebControls.CheckBox trabajando;

        private static string absolutePath;

        public WebForm4()
        {
            tabla = System.Configuration.ConfigurationManager.AppSettings["tbPrEg"].ToString();
        }

        static WebForm4()
        {
            FichaEgresado.WebForm4.absolutePath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        }

        protected void Button1_Click(object sender, System.EventArgs e)
        {
            string rango = this.rangoRenta.SelectedItem.Value;
            string desdeAnio = this.desdeAnio.SelectedItem.Value;
            string desdeMes = this.desdeMes.SelectedItem.Value;
            string hastaAnio = this.hastaAnio.SelectedItem.Value;
            string hastaMes = this.hastaMes.SelectedItem.Value;
            string cargo = this.cargo.Text;
            string empresa = this.empresa.Text;
            string responsabilidades = this.responsabilidades.Text;
            string trabajando = "-1";
            string calle = this.diractualLaboral.Text;
            string comuna = this.comunaLaboral.Text;
            string ciudad = this.ciudadactLaboral.Text;
            if ((Convert.ToInt32(desdeAnio) > Convert.ToInt32(hastaAnio)) && !this.trabajando.Checked)
            {
                Console.WriteLine("Convert.ToInt32(desdeAnio) > Convert.ToInt32(hastaAnio) && !this.trabajando.Checked => TRUE");
            }
            else
            {
                string sql;
                string mensaje;
                if (this.trabajando.Checked)
                {
                    hastaAnio = "-1";
                    hastaMes = "-1";
                    trabajando = "1";
                }
                if (this.historiaLaboralID.Value.Length < 1)
                {
                    mensaje = "INSERT";
                    sql = "INSERT INTO " + this.tabla + "historiaLaboral (rut, desdeMes, desdeAnio, hastaMes, hastaAnio, empresa, cargo, responsabilidades, rangoRentaID, trabajando, calle, comuna, ciudad) VALUES ('" + this.rut.Text + "', '" + desdeMes + "', '" + desdeAnio + "', '" + hastaMes + "', '" + hastaAnio + "', '" + empresa + "', '" + cargo + "', '" + responsabilidades + "', '" + rango + "', '" + trabajando + "', '" + calle + "', '" + comuna + "',  '" + ciudad + "');";
                }
                else
                {
                    mensaje = "UPDATE";
                    sql = "UPDATE " + this.tabla + "historiaLaboral SET desdeMes = '" + desdeMes + "', desdeAnio = '" + desdeAnio + "', hastaMes = '" + hastaMes + "', hastaAnio = '" + hastaAnio + "', empresa = '" + empresa + "', cargo = '" + cargo + "', responsabilidades = '" + responsabilidades + "', rangoRentaID = '" + rango + "', trabajando = '" + trabajando + "', calle = '" + calle + "', comuna = '" + comuna + "', ciudad = '" + ciudad + "' WHERE historiaLaboralID = '" + this.historiaLaboralID.Value + "';";
                }
                Conexion conn = new Conexion();
                base.Trace.Write(sql);
                if (conn.ejecutar(sql) > 0)
                {
                    base.Trace.Write(DateTime.Now.ToString() + " OK/" + mensaje + " EGRESADOhistoriaLaboral");
                }
                else
                {
                    base.Trace.Write(DateTime.Now.ToString() + " NOK/" + mensaje + "EGRESADOhistoriaLaboral");
                }
                conn.Cerrar();
                base.Response.Redirect("./fichaEgresado.aspx?rut=" + this.rut.Text, true);
            }

        }

        private bool completarCampos(string historiaLaboralID)
        {
            int i = System.Convert.ToInt32(historiaLaboralID);
            historiaLaboralID = i.ToString();
            Conexion conn = new Conexion();
            conn.Sql = "SELECT * FROM " + tabla + "historiaLaboral WHERE historiaLaboralID = '" + historiaLaboralID + "';";
            conn.leer(null);
            Trace.Write(conn.Sql);
            if (conn.registro())
            {
                rangoRenta.DataBind();
                this.historiaLaboralID.Value = historiaLaboralID;
                cargo.Text = conn.Dr["cargo"].ToString();
                empresa.Text = conn.Dr["empresa"].ToString();
                responsabilidades.Text = conn.Dr["responsabilidades"].ToString();
                desdeAnio.SelectedIndex = desdeAnio.Items.IndexOf(desdeAnio.Items.FindByValue(conn.Dr["desdeAnio"].ToString()));
                desdeMes.SelectedIndex = desdeMes.Items.IndexOf(desdeMes.Items.FindByValue(conn.Dr["desdeMes"].ToString()));
                rangoRenta.SelectedIndex = rangoRenta.Items.IndexOf(rangoRenta.Items.FindByValue(conn.Dr["rangoRentaID"].ToString()));
                diractualLaboral.Text = conn.Dr["calle"].ToString();
                comunaLaboral.Text = conn.Dr["comuna"].ToString();
                ciudadactLaboral.Text = conn.Dr["ciudad"].ToString();
                if (conn.Dr["hastaAnio"].ToString() != "-1" && conn.Dr["hastaMes"].ToString() != "-1")
                {
                    hastaAnio.SelectedIndex = hastaAnio.Items.IndexOf(hastaAnio.Items.FindByValue(conn.Dr["hastaAnio"].ToString()));
                    hastaMes.SelectedIndex = hastaMes.Items.IndexOf(hastaMes.Items.FindByValue(conn.Dr["hastaMes"].ToString()));
                    trabajando.Checked = false;
                }
                else
                {
                    trabajando.Checked = true;
                }
                conn.Cerrar();
            }
            else
            {
                return false;
            }
            return true;
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            System.DateTime dateTime2;

            if (Session["administrador"].ToString() == "False" && Session["escritura"].ToString() == "False")
            {
                Response.Write("<h2>No tiene suficientes permisos para ver esta p&aacute;gina.</h2>");
                Response.End();
            }
            if (!Page.IsPostBack)
            {
                System.DateTime dateTime1 = System.DateTime.Now;
                int i = dateTime1.Year;
                while (i > (dateTime1.Year - 60))
                {
                    desdeAnio.Items.Add(new System.Web.UI.WebControls.ListItem(i.ToString(), i.ToString()));
                    hastaAnio.Items.Add(new System.Web.UI.WebControls.ListItem(i.ToString(), i.ToString()));
                    i--;
                    dateTime2 = System.DateTime.Now;
                }
                rut.Text = Request.QueryString["rut"].ToString();
                if (Request.QueryString["historiaLaboralID"] != null)
                {
                    historiaLaboralID.Value = Request.QueryString["historiaLaboralID"].ToString();
                    if (completarCampos(Request.QueryString["historiaLaboralID"].ToString()))
                    {
                        System.DateTime dateTime3 = System.DateTime.Now;
                        System.Console.WriteLine(dateTime3.ToString() + " OK/SELECT EGRESADOhistoriaLaboral historiaLaboralID(" + Request.QueryString["historiaLaboralID"].ToString() + ")");
                        return;
                    }
                    System.DateTime dateTime4 = System.DateTime.Now;
                    System.Console.WriteLine(dateTime4.ToString() + " NOK/SELECT EGRESADOhistoriaLaboral historiaLaboralID(" + Request.QueryString["historiaLaboralID"].ToString() + ")");
                }
            }
        }

        protected void trabajando_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.trabajando.Checked)
            {
                this.hastaAnio.Enabled = false;
                this.hastaMes.Enabled = false;
            }
            else
            {
                this.hastaAnio.Enabled = true;
                this.hastaMes.Enabled = true;
            }

        }

    } // class WebForm4

}

