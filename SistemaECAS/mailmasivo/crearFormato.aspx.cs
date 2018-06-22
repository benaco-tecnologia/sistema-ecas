using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECAS.mailmasivo
{
    public class crearFormato : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Button btnAceptar;
        protected System.Web.UI.WebControls.Button Button1;
        protected System.Web.UI.WebControls.TextBox elm1;
        private string html;
        protected System.Web.UI.WebControls.Label lblMensaje;
        protected System.Web.UI.WebControls.Label lblNombre;
        protected System.Web.UI.WebControls.TextBox TextBox1;
        protected System.Web.UI.WebControls.Button btnBorrar;

        public crearFormato()
        {
        }

        protected void btnAceptar_Click(object sender, System.EventArgs e)
        {
            if ((this.TextBox1.Text.Length == 0) || (this.elm1.Text.Length == 0))
            {
                base.Trace.Write("Error: Mail Masivo / Administrador de Formatos / Cuerpo o titulo del formato sin valores.");
            }
            else
            {
                int campos0 = CountChar(this.elm1.Text, '{');
                int campos1 = CountChar(this.elm1.Text, '}');
                int campos = 0;
                if (campos0 != campos1)
                {
                    base.Trace.Write("Error: Mail Masivo / Administrador de Formatos / Definicion de campos a reemplazar incorrecto, cantidad de { distinto a }.");
                }
                else
                {
                    campos = campos0;
                    string connectionString = ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString;
                    if (this.Session["editar_formato_id"] != null)
                    {
                        base.Trace.Write("Info: Mail Masivo / Administrador de Formatos / Inicio modificacion formato");
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            this.html = base.Server.HtmlEncode(this.elm1.Text);
                            if (this.html.Contains("'"))
                            {
                                this.html = this.html.Replace("'", @"\'");
                            }
                            if (this.html.Contains("\""))
                            {
                                this.html = this.html.Replace("\"", "\\\"");
                            }
                            string strQuery = "UPDATE matricula.mailxls_formato SET nombre = '" + this.TextBox1.Text + "', html = '" + this.html + "', campos = " + campos.ToString() + " WHERE id = " + this.Session["editar_formato_id"].ToString() + ";";
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = connection;
                            cmd.CommandText = strQuery;
                            connection.Open();
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                base.Trace.Write("Info: Mail Masivo / Administrador de Formatos / SQL ejecutado correctamente\n" + strQuery);
                            }
                            else
                            {
                                base.Trace.Write("Error: Mail Masivo / Administrador de Formatos / SQL no ejecutado\n" + strQuery);
                            }
                            this.Session.Add("formato_id", this.Session["editar_formato_id"].ToString());
                            this.Session.Add("formato_nombre", this.TextBox1.Text);
                            connection.Close();
                        }
                        this.Session.Remove("editar_formato_id");
                        base.Response.Redirect("formatos.aspx");
                    }
                    else
                    {
                        base.Trace.Write("Info: Mail Masivo / Administrador de Formatos / Inicio ingreso nuevo formato");
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            this.html = base.Server.HtmlEncode(this.elm1.Text);
                            if (this.html.Contains("'"))
                            {
                                this.html = this.html.Replace("'", @"\'");
                            }
                            if (this.html.Contains("\""))
                            {
                                this.html = this.html.Replace("\"", "\\\"");
                            }
                            SqlCommand cmd = new SqlCommand("INSERT INTO mailxls_formato (nombre, html, campos) VALUES ('" + this.TextBox1.Text + "', '" + this.html + "', " + campos.ToString() + "); SELECT id=@@IDENTITY; SET NOCOUNT OFF;", connection);
                            connection.Open();
                            this.Session.Add("formato_id", cmd.ExecuteScalar());
                            this.Session.Add("formato_nombre", this.TextBox1.Text);
                            connection.Close();
                        }
                        base.Response.Redirect("subirArchivo.aspx");
                    }
                }
            }

        }

        protected void Button1_Click(object sender, System.EventArgs e)
        {
            if (Session["editar_formato_id"] != null)
            {
                Session.Remove("editar_formato_id");
                Response.Redirect("formatos.aspx", true);
                return;
            }
            Response.Redirect("Default.aspx", true);
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            btnBorrar.Enabled = false;
            btnBorrar.Visible = false;

            if (Session["loggeado"] == null)
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["urlRoot"].ToString() + "/ingreso.aspx", true);
            if (Session["administrador"].ToString() == "False" && Session["escritura"].ToString() == "False")
            {
                Response.Write("<h2>No tiene suficientes permisos para ver esta p&aacute;gina.</h2>");
                Response.End();
            }
            if ((Session["editar_formato_id"] != null) && !IsPostBack)
            {
                btnBorrar.Enabled = true;
                btnBorrar.Visible = true;

                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString;
                using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    string strQuery = "SELECT html, nombre FROM matricula.mailxls_formato WHERE id = " + Session["editar_formato_id"].ToString() + ";";
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(strQuery, connection);
                    connection.Open();
                    System.Data.SqlClient.SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    html = dr[0].ToString();
                    if (html.Contains("\\'"))
                        html = html.Replace("\\'", "'");
                    if (html.Contains("\\\""))
                        html = html.Replace("\\\"", "\"");
                    elm1.Text = Server.HtmlDecode(html);
                    TextBox1.Text = dr[1].ToString();
                    connection.Close();
                }
            }
        }

        public static int CountChar(string input, char c)
        {
            int retval = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (c == input[i])
                {
                    retval++;
                }
            }
            return retval;

        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString;
            if (this.Session["editar_formato_id"] != null)
            {
                base.Trace.Write("Info: Mail Masivo / Administrador de Formatos / Inicio modificacion formato");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string strQuery = "DELETE FROM matricula.mailxls_formato WHERE id = " + this.Session["editar_formato_id"].ToString() + ";";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = strQuery;
                    connection.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        base.Trace.Write("Info: Mail Masivo / Administrador de Formatos / SQL ejecutado correctamente\n" + strQuery);
                    }
                    else
                    {
                        base.Trace.Write("Error: Mail Masivo / Administrador de Formatos / SQL no ejecutado\n" + strQuery);
                    }
                    this.Session.Remove("formato_id");
                    this.Session.Remove("formato_nombre");
                    connection.Close();
                }
                this.Session.Remove("editar_formato_id");
                base.Response.Redirect("formatos.aspx");
            }
        }
    } // class crearFormato
}