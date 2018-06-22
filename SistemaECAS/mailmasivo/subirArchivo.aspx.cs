using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace SistemaECAS.mailmasivo
{

    public class subirArchivo : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.Button Button1;
        protected System.Web.UI.WebControls.Button Button2;
        protected System.Web.UI.WebControls.FileUpload FileUpload1;
        protected System.Web.UI.WebControls.RegularExpressionValidator FileUpLoadValidator;
        protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.TextBox TextBox1;

        public subirArchivo()
        {
        }

        protected void Button1_Click(object sender, System.EventArgs e)
        {
            if (FileUpload1.HasFile && (FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                try
                {
                    string file = FileUpload1.FileName.ToString();
                    try
                    {
                        if (System.IO.File.Exists(Server.MapPath(".\\") + file))
                            System.IO.File.Delete(Server.MapPath(".\\") + file);
                    }
                    catch (System.Exception)
                    {
                    }
                    System.Random random = new System.Random();
                    int rnd = random.Next(1000, 9999);
                    FileUpload1.PostedFile.SaveAs(Server.MapPath(".\\") + rnd.ToString() + file);
                    Session.Add("archivo_excel", rnd.ToString() + file);
                    Session.Add("mail_subject", TextBox1.Text.Trim());
                    Response.Redirect("seleccionarAdjuntos.aspx", true);
                }
                catch (System.Exception e1)
                {
                    lblError.Text = "Ocurri&oacute; un error al subir el archivo, intente nuevamente. " + e1.ToString();
                }
            }
        }

        protected void Button2_Click(object sender, System.EventArgs e)
        {
            base.Response.Redirect("Default.aspx", true);

        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (this.Session["loggeado"] == null)
            {
                base.Response.Redirect(ConfigurationManager.AppSettings["urlRoot"].ToString() + "/ingreso.aspx", true);
            }

        }

    } // class subirArchivo

}

