using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;

namespace FichaEgresado
{

    public class WebForm2 : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.TextBox apellido;
        protected System.Web.UI.WebControls.Button btnBuscar;
        protected System.Web.UI.WebControls.TableHeaderCell headerTable;
        protected System.Web.UI.WebControls.TextBox materno;
        protected System.Web.UI.WebControls.TextBox nombre;
        protected System.Web.UI.WebControls.TextBox numeroEcas;
        protected System.Web.UI.WebControls.Table resultado;
        protected System.Web.UI.HtmlControls.HtmlGenericControl resultado_div;
        protected System.Web.UI.WebControls.TextBox rut;
        private string tabla;
        protected System.Web.UI.WebControls.TableRow titulos;
        protected System.Web.UI.WebControls.Label txtError;

        public WebForm2()
        {
            tabla = System.Configuration.ConfigurationManager.AppSettings["tbPrEg"].ToString();
        }

        protected void btnBuscar_Click(object sender, System.EventArgs e)
        {
              string sql_base = "SELECT rut, codcli, nombre, paterno, materno, anoegre, anotit FROM " + this.tabla + "listado WHERE ";
            if (this.rut.Text.Trim().Length > 0)
            {
                sql_base = sql_base + " rut = '" + this.rut.Text.Trim() + "';";
            }
            else if (this.numeroEcas.Text.Trim().Length > 0)
            {
                sql_base = sql_base + " codcli = '" + this.numeroEcas.Text.Trim().ToUpper() + "';";
            }
            else
            {
                string apellido = this.apellido.Text.ToUpper().Trim();
                string materno = this.materno.Text.ToUpper().Trim();
                string nombre = this.nombre.Text.ToUpper().Trim();
                if (((apellido.Length > 0) && (materno.Length > 0)) && (nombre.Length > 0))
                {
                    sql_base = sql_base + " paterno = '" + apellido + "' AND materno = '" + materno + "' AND nombre like '%" + nombre + "%';";
                }
                else if (((apellido.Length > 0) && (materno.Length > 0)) && (nombre.Length == 0))
                {
                    sql_base = sql_base + " paterno = '" + apellido + "' AND materno = '" + materno + "';";
                }
                else if (((apellido.Length == 0) && (materno.Length > 0)) && (nombre.Length > 0))
                {
                    sql_base = sql_base + " materno = '" + materno + "' AND nombre like '%" + nombre + "%';";
                }
                else if (((apellido.Length > 0) && (materno.Length == 0)) && (nombre.Length > 0))
                {
                    sql_base = sql_base + " paterno = '" + apellido + "' AND nombre like '%" + nombre + "%';";
                }
                else if (((apellido.Length > 0) && (materno.Length == 0)) && (nombre.Length == 0))
                {
                    sql_base = sql_base + " paterno = '" + apellido + "';";
                }
                else if (((apellido.Length == 0) && (materno.Length == 0)) && (nombre.Length > 0))
                {
                    sql_base = sql_base + " nombre = 'like '%" + nombre + "%';";
                }
                else if (((apellido.Length == 0) && (materno.Length > 0)) && (nombre.Length == 0))
                {
                    sql_base = sql_base + " materno = '" + apellido + "';";
                }
                else
                {
                    return;
                }
            }
            SqlConnection adoConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString);
            adoConn.Open();
            SqlDataReader adoDR = new SqlCommand(sql_base, adoConn).ExecuteReader();
            if (adoDR.HasRows)
            {
                Color BackColor = Color.Black;
                while (adoDR.Read())
                {
                    if (BackColor == ColorTranslator.FromHtml("#EEEEEE"))
                    {
                        BackColor = ColorTranslator.FromHtml("#DCDCDC");
                    }
                    else
                    {
                        BackColor = ColorTranslator.FromHtml("#EEEEEE");
                    }
                    TableRow row = new TableRow {
                        BackColor = BackColor
                    };
                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();
                    TableCell cell3 = new TableCell();
                    TableCell cell4 = new TableCell();
                    TableCell cell5 = new TableCell();
                    cell1.Font.Bold = true;
                    cell1.HorizontalAlign = HorizontalAlign.Right;
                    cell2.HorizontalAlign = HorizontalAlign.Right;
                    cell4.HorizontalAlign = HorizontalAlign.Center;
                    cell5.HorizontalAlign = HorizontalAlign.Center;
                    HyperLink link = new HyperLink {
                        Text = adoDR["rut"].ToString(),
                        NavigateUrl = "fichaEgresado.aspx?rut=" + adoDR["rut"].ToString()
                    };
                    cell1.Controls.Add(link);
                    cell2.Text = adoDR["codcli"].ToString();
                    cell3.Text = adoDR["nombre"].ToString() + " " + adoDR["paterno"].ToString() + " " + adoDR["materno"].ToString();
                    cell4.Text = adoDR["anoegre"].ToString();
                    cell5.Text = adoDR["anotit"].ToString(); 
                    cell1.Style.Add("letter-spacing", "1px");
                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    row.Cells.Add(cell3);
                    row.Cells.Add(cell4);
                    row.Cells.Add(cell5);
                    this.resultado.Rows.Add(row);
                }
                this.resultado.BorderColor = ColorTranslator.FromHtml("#999999");
                this.resultado.BorderWidth = Unit.Pixel(1);
                this.resultado.BorderStyle = BorderStyle.None;
                this.resultado.HorizontalAlign = HorizontalAlign.Center;
                this.resultado.BackColor = Color.White;
                this.titulos.Visible = true;
            }
            else
            {
                this.headerTable.Text = "No hay resultados";
            }
            this.resultado_div.Visible = true;
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (Session["correo"].ToString().Equals("1") && Session["administrador"].ToString() == "False")
            {
                txtError.Text = "No tiene permisos para acceder a esta p\u00E1gina";
                return;
            }
            resultado_div.Visible = false;
            titulos.Visible = false;
        }

    } // class WebForm2

}

