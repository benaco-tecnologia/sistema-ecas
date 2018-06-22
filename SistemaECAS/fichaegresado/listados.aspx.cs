using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FichaEgresado
{

    public class listados : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.Button Button1;
        protected System.Web.UI.WebControls.DropDownList ddlEgreso;
        protected System.Web.UI.WebControls.DropDownList ddlIdioma;
        protected System.Web.UI.WebControls.TableHeaderCell headerTable;
        protected System.Web.UI.WebControls.Table resultado;
        protected System.Web.UI.WebControls.SqlDataSource SqlDataSource1;
        protected System.Web.UI.WebControls.TableRow titulos;
        protected System.Web.UI.WebControls.CheckBox trabajando;

        public listados()
        {
        }

        protected void Button1_Click(object sender, System.EventArgs e)
        {
            
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            for (int i = 1950; i < 2011; i++)
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
                li.Text = i.ToString();
                li.Value = i.ToString();
                ddlEgreso.Items.Add(li);
            }
        }

    } // class listados

}

