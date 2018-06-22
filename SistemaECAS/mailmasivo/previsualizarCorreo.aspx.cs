using System;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace SistemaECAS.mailmasivo
{

    public class previsualizarCorreo : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.Button Button1;
        protected System.Web.UI.WebControls.Button Enviar;
        protected System.Web.UI.WebControls.Label lblFormato;
        protected System.Web.UI.WebControls.Label lblError;

        public previsualizarCorreo()
        {
        }

        protected void Button1_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("SubirArchivo.aspx", true);
        }

        protected void Enviar_Click(object sender, System.EventArgs e)
        {
            string envio_id;
            string connectionString = ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString;
            string formato_id = this.Session["formato_id"].ToString();
            string archivo_excel = this.Session["archivo_excel"].ToString();
            string formato_html = this.Session["formato_html"].ToString();
            int destinatarios = 0;
            if (formato_html.Contains(@"\'"))
            {
                formato_html = formato_html.Replace(@"\'", "'");
            }
            if (formato_html.Contains("\\\""))
            {
                formato_html = formato_html.Replace("\\\"", "\"");
            }
            formato_html = base.Server.HtmlDecode(formato_html);
            OleDbConnection cnExcel = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + base.Server.MapPath(archivo_excel) + ";Extended Properties=Excel 8.0");
            cnExcel.Open();
            OleDbDataReader drExcel = new OleDbCommand("select * from [Hoja1$]", cnExcel).ExecuteReader();
            int numero_campos = drExcel.FieldCount;
            string[] nombre_campos = new string[numero_campos];
            for (int i = 0; i < numero_campos; i++)
            {
                nombre_campos[i] = "{" + drExcel.GetName(i).Trim() + "}";
            }
            SmtpClient mail = new SmtpClient(ConfigurationManager.AppSettings["smtpServer"].ToString());
            mail.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["smtpUser"].ToString(), ConfigurationManager.AppSettings["smtpPassword"].ToString());
            mail.UseDefaultCredentials = false;
            mail.Port = int.Parse(ConfigurationManager.AppSettings["smtpPort"].ToString());
            mail.EnableSsl = true;

            MailAddress from = new MailAddress(this.Session["login"].ToString() + "@ecas.cl", this.Session["remitente_nombre"].ToString());
            //MailAddress from = new MailAddress(this.Session["remitente_mail"].ToString(), this.Session["remitente_nombre"].ToString());
            //Debug.WriteLine(from.Address);
           // Debug.WriteLine(from.User);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [matricula].[mailxls_envio] (formato_id, html, remitente, asunto, formato) VALUES (" + formato_id + ",'" + this.Session["formato_html"].ToString() + "', '" + this.Session["remitente"].ToString() + "', '" + this.Session["mail_subject"].ToString() + "', '" + this.Session["formato_nombre"].ToString() + "'); SELECT id=@@IDENTITY; SET NOCOUNT OFF;", connection);
                connection.Open();
                envio_id = cmd.ExecuteScalar().ToString();
                connection.Close();
                goto Label_05D3;
            }
        Label_029B:
            try
            {
                MailAddress to;
                MailMessage message;
                string to_email = drExcel[0].ToString().Trim();
                string to_nombre = drExcel[1].ToString().Trim();
                if (to_email.Equals(""))
                {
                    goto Label_05DF;
                }
                if (to_email.Contains(";"))
                {
                    string[] arr_to_email = to_email.Split(new char[] { ';' });
                    if (!isEmail(arr_to_email[0].Trim()))
                    {
                        goto Label_05D3;
                    }
                    to = new MailAddress(arr_to_email[0].Trim(), to_nombre);
                    message = new MailMessage(from, to);
                    for (int i = 1; i < arr_to_email.Length; i++)
                    {
                        if (isEmail(arr_to_email[i].Trim()))
                        {
                            message.CC.Add(arr_to_email[i].Trim());
                        }
                    }
                }
                else
                {
                    if (!isEmail(to_email))
                    {
                        goto Label_05D3;
                    }
                    to = new MailAddress(to_email, to_nombre);
                    message = new MailMessage(from, to);
                }
                string formato_tmp = formato_html;
                for (int i = 0; i < numero_campos; i++)
                {
                    formato_tmp = formato_tmp.Replace(nombre_campos[i], drExcel[i].ToString().Trim());
                }
                message.Body = formato_tmp;
                message.Subject = this.Session["mail_subject"].ToString();
                message.IsBodyHtml = true;
                int adjuntos = 1;
                while (this.Session["adjunto" + adjuntos] != null)
                {
                    string adjunto = ConfigurationManager.AppSettings["path_adjuntos"].ToString() + this.Session["adjunto" + adjuntos].ToString();
                    try
                    {
                        message.Attachments.Add(new Attachment(base.Server.MapPath(adjunto)));
                        adjuntos++;
                        continue;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("No se pudo adjuntar el archivo " + adjunto + ". " + ex.Message);
                        continue;
                    }
                }
                try
                {
                    mail.Send(message);
                    message.Dispose();
                    destinatarios++;
                }
                catch (Exception ex)
                {
                    this.lblError.Text = ex.Message.ToString()+" "+ex.StackTrace.ToString();
                    Debug.Write(" mail.Send(message); " + DateTime.Now.ToString() + "|" + ex.Message.ToString());
                    //return;
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [matricula].[mailxls_destinatario] (email, nombre, envio_id) VALUES ('" + to_email + "', '" + to_nombre + "', '" + envio_id + "');", connection);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(" INSERT INTO [matricula].[mailxls_destinatario] " + DateTime.Now.ToString() + "|" + ex.Message.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("All "+DateTime.Now.ToString() + "|" + ex.Message.ToString());
            }
        Label_05D3:
            if (drExcel.Read())
            {
                goto Label_029B;
            }
        Label_05DF:
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE [matricula].[mailxls_envio] SET [destinatarios] = '" + destinatarios.ToString() + "' WHERE [id] = '" + envio_id + "';", connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            this.Session.Add("destinatarios", destinatarios.ToString());
            drExcel.Close();
            cnExcel.Close();
            drExcel = null;
            cnExcel = null;
            try
            {
                for (int adjuntos = 1; this.Session["adjunto" + adjuntos] != null; adjuntos++)
                {
                    if (File.Exists(base.Server.MapPath(ConfigurationManager.AppSettings["path_adjuntos"].ToString() + this.Session["adjunto" + adjuntos].ToString())))
                    {
                        Directory.Delete(base.Server.MapPath(ConfigurationManager.AppSettings["path_adjuntos"].ToString() + this.Session["adjunto" + adjuntos].ToString().Split(new char[] { '/' })[0]), true);
                    }
                }
                if (File.Exists(base.Server.MapPath(archivo_excel)))
                {
                    File.Delete(base.Server.MapPath(archivo_excel));
                }
            }
            catch (IOException ex2)
            {
                Debug.Write("Error eliminar adjunto" + DateTime.Now.ToString() + "|" + ex2.Message.ToString() + "|Error al intentar eliminar los archivos adjuntos y/o archivo de destinatarios");
            }
            base.Response.Redirect("exito.aspx", true);

        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            string formato_html;

            if (Session["loggeado"] == null)
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["urlRoot"].ToString() + "/ingreso.aspx", true);
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString;
            string formato_id = Session["formato_id"].ToString();
            string archivo_excel = Session["archivo_excel"].ToString();
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                string strQuery = "SELECT html FROM matricula.mailxls_formato WHERE id = " + formato_id + ";";
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(strQuery, connection);
                connection.Open();
                System.Data.SqlClient.SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                formato_html = dr[0].ToString();
                connection.Close();
                Session.Add("formato_html", formato_html);
            }
            System.Data.OleDb.OleDbConnection cnExcel = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath(archivo_excel) + ";Extended Properties=Excel 8.0");
            System.Data.OleDb.OleDbCommand cmdExcel = new System.Data.OleDb.OleDbCommand("select * from [Hoja1$]", cnExcel);
            cnExcel.Open();
            System.Data.OleDb.OleDbDataReader drExcel = cmdExcel.ExecuteReader();
            int numero_campos = drExcel.FieldCount;
            string[] nombre_campos = new string[numero_campos];
            int j = 1;
            for (int i = 0; i < numero_campos; i++)
            {
                nombre_campos[i] = "{" + drExcel.GetName(i).Trim() + "}";
            }
            if (drExcel.Read())
            {
                for (int i1 = 0; i1 < numero_campos; i1++)
                {
                    formato_html = formato_html.Replace(nombre_campos[i1], drExcel[i1].ToString());
                }
            }
            while (drExcel.Read())
            {
                if (drExcel[0].ToString() != "")
                    j++;
            }
            lblFormato.Text = "<p align=\"right\">" + numero_campos.ToString() + " campos ha reemplazar.<br />" + j.ToString() + " destinatarios.</p>";
            drExcel.Close();
            cnExcel.Close();
            if (formato_html.Contains("\\'"))
                formato_html = formato_html.Replace("\\'", "'");
            if (formato_html.Contains("\\\""))
                formato_html = formato_html.Replace("\\\"", "\"");
            formato_html = Server.HtmlDecode(formato_html);
            lblFormato.Text += formato_html;
        }

        protected static bool isEmail(string inputEmail)
        {
            inputEmail = inputEmail.Trim();
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            return re.IsMatch(inputEmail);

        }

    } // class previsualizarCorreo

}

