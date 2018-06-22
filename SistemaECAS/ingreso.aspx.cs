using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaECAS
{

    public class ingreso : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.Button btnLogin;
        protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.TextBox txtContrasena;
        protected System.Web.UI.WebControls.TextBox txtLogin;

        public ingreso()
        {
        }

        protected void btnLogin_Click(object sender, System.EventArgs e)
        {
            if (this.txtLogin.Text.Trim().Length < 1)
            {
                return;
            }

            string nombre;
            string Sql;
            HttpServerUtility httpUtility = HttpContext.Current.Server;
            this.Session.Add("administrador", "False");
            this.Session.Add("escritura", "False");
            this.Session.Add("sincronizacion", "2");
            this.Session.Add("certificado", "2");
            this.Session.Add("correo", "2");
            this.Session.Add("ficha", "2");

            try
            {
                Conexion conn = new Conexion();

                Sql = "SELECT usuario FROM [matricula].[SGPermisos] WHERE usuario = '" + this.txtLogin.Text.Trim() + "' and sistema = '" + ConfigurationManager.AppSettings["sinAcceso"].ToString() + "';";
                conn.leer(Sql);
                
                if (conn.registro())
                {
                    this.lblError.Text = "<h2>Usted no est&aacute; habilitado para ingresar al sistema.</h2>";
                    return;
                }

                conn.Cerrar();
                conn = new Conexion();
                Sql = "SELECT sistema, certificado, correo, ficha, sincronizacion FROM [matricula].[SGPermisos] WHERE usuario = '" + this.txtLogin.Text.Trim() + "';";
                conn.leer(Sql);

                if (conn.registro())
                {
                    this.Session.Add("sincronizacion", conn.Dr["sincronizacion"].ToString());
                    this.Session.Add("certificado", conn.Dr["certificado"].ToString());
                    this.Session.Add("correo", conn.Dr["correo"].ToString());
                    this.Session.Add("ficha", conn.Dr["ficha"].ToString());
                    if ((conn.Dr["sistema"].ToString().Equals(ConfigurationManager.AppSettings["escritura"].ToString()) || ConfigurationManager.AppSettings["administrador1"].ToString().Equals(this.txtLogin.Text.Trim())) || ConfigurationManager.AppSettings["administrador2"].ToString().Equals(this.txtLogin.Text.Trim()))
                    {
                        this.Session.Add("administrador", "True");
                        this.Session.Add("escritura", "True");
                        base.Trace.Write(DateTime.Now.ToString() + this.txtLogin.Text.Trim() + "|Usuario administrador.");
                    }
                    else
                    {
                        base.Trace.Write(DateTime.Now.ToString() + this.txtLogin.Text.Trim() + "|Usuario no administrador.");
                    }
                }
                else
                {
                    base.Trace.Write(DateTime.Now.ToString() + this.txtLogin.Text.Trim() + "|No se encontr\x00f3 registro de permisos.");
                }
                conn.Cerrar();
            }
            catch (Exception ex)
            {
                this.lblError.Text = "No se pudo conectar con la base de datos. " + ex.Message;
                return;
            }
            
            string user = httpUtility.UrlEncode(this.txtLogin.Text.Trim());
            string password = httpUtility.UrlEncode(this.txtContrasena.Text.Trim());
            string properties = httpUtility.UrlEncode("displayname");
            string url = ConfigurationManager.AppSettings["urlCheckAD"].ToString() + "?user=" + user + "&password=" + password + "&properties=" + properties;

            if (!ConfigurationManager.AppSettings["desarrollo"].ToString().Equals("1"))
            {
                try
                {
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    req.Timeout = 0x2710;
                    StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream());
                    nombre = reader.ReadToEnd().ToString();
                }
                catch (Exception ex)
                {
                    this.lblError.Text = "No se pudo conectar al servidor AD. " + ex.Message;
                    return;
                }
            }
            else
            {
                nombre = "Desarrollador";
            }
        
            if (!(nombre == "-1"))
            {
                this.Session.Add("login", this.txtLogin.Text.Trim());
                this.Session.Add("password", this.txtContrasena.Text.Trim());
                this.Session.Add("nombre", nombre);
                this.Session.Add("loggeado", "true");
                base.Response.Redirect(ConfigurationManager.AppSettings["urlRoot"].ToString() + "/Default.aspx", true);
            }
            else
            {
                this.lblError.Text = "El usuario ingresado no es v&aacute;lido.";
                this.Session.Remove("login");
                this.Session.Remove("password");
                this.Session.Remove("nombre");
                this.Session.Remove("loggeado");
                this.Session.Remove("administrador");
                this.Session.Remove("escritura");
            }

        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.Session.Clear();
                this.Session.Abandon();
            }

        }

    } // class ingreso

}

