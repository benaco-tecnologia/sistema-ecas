using System;
using System.DirectoryServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace SistemaECAS
{

    public class ChequearUsuario : System.Web.UI.Page
    {

        protected System.Web.UI.HtmlControls.HtmlForm form1;

        public ChequearUsuario()
        {
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            Response.ClearContent();
            if ((Request.QueryString["user"] == null) || (Request.QueryString["password"] == null) || (Request.QueryString["properties"] == null))
            {
                Response.Write("-1");
                Response.End();
                return;
            }
            string user = Request.QueryString["user"].ToString().Trim();
            string password = Request.QueryString["password"].ToString().Trim();
            try
            {
                string domain = "ecas.local";
                System.DirectoryServices.DirectoryEntry entry = new System.DirectoryServices.DirectoryEntry("LDAP://" + domain, user, password, System.DirectoryServices.AuthenticationTypes.Secure);
                try
                {
                    System.DirectoryServices.DirectorySearcher search = new System.DirectoryServices.DirectorySearcher(entry);
                    search.Filter = "(SAMAccountName=" + user + ")";
                    search.PropertiesToLoad.Add("displayName");
                    System.DirectoryServices.SearchResult result = search.FindOne();
                    if (result == null)
                    {
                        Response.Write("-1");
                        Response.End();
                        return;
                    }
                    string properties = Request.QueryString["properties"].ToString().Trim();
                    string nombre = result.Properties[properties][0].ToString();
                    Response.Write(nombre);
                    Response.End();
                    return;
                }
                catch (System.DirectoryServices.DirectoryServicesCOMException)
                {
                    Response.Write("-1");
                    Response.End();
                }
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException)
            {
                Response.Write("-1");
                Response.End();
            }
        }

    } // class ChequearUsuario

}

