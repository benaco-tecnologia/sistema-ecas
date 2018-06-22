using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web;

namespace SistemaECAS.mailmasivo
{

    public class seleccionarAdjuntos : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.Button Button1;
        protected System.Web.UI.WebControls.Button Button2;
        protected System.Web.UI.WebControls.Label lblError;

        public seleccionarAdjuntos()
        {
        }

        protected void Button1_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("SubirArchivo.aspx", true);
        }

        protected void Button2_Click(object sender, System.EventArgs e)
        {
            int numero_adjuntos = 0;
            if (this.Session["numero_adjuntos"] != null)
            {
                numero_adjuntos = int.Parse(this.Session["numero_adjuntos"].ToString());
            }
            for (int i = 0; i < base.Request.Files.Count; i++)
            {
                HttpPostedFile file = base.Request.Files[i];
                if (((file != null) && (file.ContentLength > 0)) && !file.FileName.ToString().Equals(""))
                {
                    try
                    {
                        string fileName = file.FileName.ToString();
                        string newFolderName = Path.GetRandomFileName();
                        string newPath = Path.Combine(base.Server.MapPath(ConfigurationManager.AppSettings["path_adjuntos"].ToString()), newFolderName);
                        Directory.CreateDirectory(newPath);
                        file.SaveAs(newPath + "/" + fileName);
                        numero_adjuntos++;
                        this.Session.Add("adjunto" + numero_adjuntos, newFolderName + "/" + fileName);
                        this.Session.Remove("numero_adjuntos");
                        this.Session.Add("numero_adjuntos", numero_adjuntos);
                    }
                    catch (Exception ex)
                    {
                        this.lblError.Text = "Ocurri&oacute; un error al subir el archivo. " + ex.Message;
                    }
                }
            }
            base.Response.Redirect("previsualizarCorreo.aspx", true);

        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (Session["loggeado"] == null)
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["urlRoot"].ToString() + "/ingreso.aspx", true);
        }

    } // class seleccionarAdjuntos

}

