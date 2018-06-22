using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Configuration;

namespace SistemaECAS
{

    public class Base1 : System.Web.UI.MasterPage
    {

        protected System.Web.UI.HtmlControls.HtmlGenericControl admin_;
        protected System.Web.UI.HtmlControls.HtmlForm Form2;
        protected System.Web.UI.WebControls.ContentPlaceHolder HeadContent;
        protected System.Web.UI.WebControls.HyperLink HyperLink1;
        protected System.Web.UI.WebControls.HyperLink HyperLink2;
        protected System.Web.UI.WebControls.Label lastUpdate;
        protected System.Web.UI.HtmlControls.HtmlGenericControl linkEstudios;
        protected System.Web.UI.HtmlControls.HtmlGenericControl linkFormato;
        protected System.Web.UI.HtmlControls.HtmlGenericControl linkIdioma;
        protected System.Web.UI.HtmlControls.HtmlGenericControl linkRenta;
        protected System.Web.UI.HtmlControls.HtmlGenericControl loginDisplay_;
        protected System.Web.UI.WebControls.ContentPlaceHolder MainContent;
        protected System.Web.UI.WebControls.HyperLink mBuscar;
        protected System.Web.UI.HtmlControls.HtmlGenericControl menu_r;
        protected System.Web.UI.WebControls.HyperLink mEnvios;
        protected System.Web.UI.WebControls.HyperLink mEscribir;
        protected System.Web.UI.WebControls.HyperLink mFormatos;
        protected System.Web.UI.WebControls.HyperLink mIdiomas;
        protected System.Web.UI.WebControls.HyperLink mInicio;
        protected System.Web.UI.WebControls.HyperLink mPermisos;
        protected System.Web.UI.WebControls.HyperLink mRangoRenta;
        protected System.Web.UI.WebControls.HyperLink mTipoEstudios;
        protected System.Web.UI.WebControls.Label strAno;
        protected System.Web.UI.HtmlControls.HtmlLink style;

        public Base1()
        {
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            string urlRoot = ConfigurationManager.AppSettings["urlRoot"].ToString();
            this.strAno.Text = DateTime.Now.Year.ToString();
            this.lastUpdate.Text = ConfigurationManager.AppSettings["lastUpdate"].ToString();
            this.admin_.Visible = false;
            string mensaje = null;
            if (!this.style.Href.Contains(urlRoot))
            {
                this.style.Href = urlRoot + this.style.Href;
                this.mInicio.NavigateUrl = urlRoot + this.mInicio.NavigateUrl;
                this.mEscribir.NavigateUrl = urlRoot + this.mEscribir.NavigateUrl;
                this.mFormatos.NavigateUrl = urlRoot + this.mFormatos.NavigateUrl;
                this.mEnvios.NavigateUrl = urlRoot + this.mEnvios.NavigateUrl;
                this.mBuscar.NavigateUrl = urlRoot + this.mBuscar.NavigateUrl;
                this.mIdiomas.NavigateUrl = urlRoot + this.mIdiomas.NavigateUrl;
                this.mRangoRenta.NavigateUrl = urlRoot + this.mRangoRenta.NavigateUrl;
                this.mTipoEstudios.NavigateUrl = urlRoot + this.mTipoEstudios.NavigateUrl;
                this.mPermisos.NavigateUrl = urlRoot + this.mPermisos.NavigateUrl;
            }
            if (!base.IsPostBack && (base.Session["loggeado"] == null))
            {
                this.menu_r.Visible = false;
            }
            if (base.Session["administrador"] != null)
            {
                if (base.Session["administrador"].ToString() != "True")
                {
                    mensaje = "Usuario normal";
                }
                else
                {
                    this.admin_.Visible = true;
                    mensaje = "Usuario administrador";
                }
            }
            if (base.Session["loggeado"] != null)
            {
                this.loginDisplay_.InnerHtml = "Logueado como <strong title=\"" + mensaje + "\" style=\"cursor: help;\">" + base.Session["nombre"].ToString() + "</strong> (<a href=\"" + urlRoot + "/ingreso.aspx\">salir</a>)";
                this.menu_r.Visible = true;
            }
            if (((base.Session["administrador"] != null) && (base.Session["escritura"] != null)) && ((base.Session["administrador"].ToString() == "False") && (base.Session["escritura"].ToString() == "False")))
            {
                this.linkEstudios.Visible = false;
                this.linkFormato.Visible = false;
                this.linkIdioma.Visible = false;
                this.linkRenta.Visible = false;
            }

        }

    } // class Base1

}

