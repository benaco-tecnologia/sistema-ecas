using System;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Drawing;

namespace SistemaECAS.mailmasivo
{

    public class remitentes : System.Web.UI.Page
    {

        private System.Collections.ArrayList arrPermisos;
        protected System.Web.UI.WebControls.Button btnAgregar;
        protected System.Web.UI.WebControls.Button btnPermisos;
        protected System.Web.UI.WebControls.TableHeaderCell headerTable;
        protected System.Web.UI.WebControls.Table permisos;
        protected System.Web.UI.HtmlControls.HtmlGenericControl permisos_div;
        protected System.Web.UI.WebControls.TableRow titulos;
        protected System.Web.UI.WebControls.TextBox txtCorreo;

        public remitentes()
        {
            System.Collections.ArrayList arrayList = new System.Collections.ArrayList();
            arrayList.Add("Sin Acceso");
            arrayList.Add("Lectura");
            arrayList.Add("Escritura");
            arrPermisos = arrayList;
        }

        protected void btnAgregar_Click(object sender, System.EventArgs e)
        {
            string correo_electronico = txtCorreo.Text.Trim();
            if (correo_electronico.Length < 3)
                return;
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString;
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString);
            try
            {
                string strQuery = "INSERT INTO [matricula].[SGPermisos] (usuario, certificado, correo, ficha, sistema, sincronizacion, actualizacion) VALUES ('" + correo_electronico + "', 2, 2, 2, 2, 2, getdate());";
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(strQuery, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (System.Exception e1)
            {
                System.Console.WriteLine("Ocurri\u00F3 un error al intentar ingresar un permiso de usuario. " + e1.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }
            txtCorreo.Text = "";
            cargarPermisos();
        }

        protected void btnPermisos_Click(object sender, System.EventArgs e)
        {
            if (Page.IsPostBack)
            {
                for (int i = 0; i < Page.Request.Form.Keys.Count; i++)
                {
                    string control = Page.Request.Form.Keys[i].ToString();
                    if (control.Contains("|"))
                    {
                        char[] chArr1 = new char[] { '|' };
                        char[] chArr2 = new char[] { '$' };
                        char[] chArr3 = new char[] { '|' };
                        char[] chArr4 = new char[] { '$' };
                        string username = control.Split(chArr1)[0].Split(chArr2)[control.Split(chArr3)[0].Split(chArr4).Length - 1].Trim();
                        char[] chArr5 = new char[] { '|' };
                        char[] chArr6 = new char[] { '|' };
                        string seccion = control.Split(chArr5)[control.Split(chArr6).Length - 1].Trim();
                        int i1 = arrPermisos.IndexOf(Page.Request.Form[control].ToString()) + 1;
                        string nivel = i1.ToString();
                        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString;
                        System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString);
                        try
                        {
                            string strQuery = "UPDATE [matricula].[SGPermisos] SET " + seccion + " = '" + nivel + "' WHERE usuario = '" + username + "';";
                            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(strQuery, connection);
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }
                        catch (System.Exception e1)
                        {
                            System.Console.WriteLine("Ocurri\u00F3 un error al intentar actualizar el permiso (" + seccion + ":" + Page.Request.Form[control].ToString() + ") del usuario " + username + ". " + e1.Message);
                        }
                        finally
                        {
                            if (connection != null)
                                connection.Dispose();
                        }
                    }
                }
            }
            cargarPermisos();
        }

        private void cargarPermisos()
        {
            string sql_base = "SELECT [usuario], [correo], [ficha], [sistema], [certificado], [sincronizacion], [actualizacion] FROM [matricula].[SGPermisos] ORDER BY [usuario];";
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
                    TableRow row = new TableRow
                    {
                        BackColor = BackColor
                    };
                    TableCell cell0 = new TableCell();
                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();
                    TableCell cell3 = new TableCell();
                    TableCell cell4 = new TableCell();
                    TableCell cell5 = new TableCell();
                    TableCell cell6 = new TableCell();
                    cell0.Font.Bold = true;
                    cell6.Text = adoDR["actualizacion"].ToString();
                    cell0.Text = adoDR["usuario"].ToString();
                    DropDownList ddl = new DropDownList
                    {
                        DataSource = this.arrPermisos
                    };
                    ddl.DataBind();
                    ddl.ID = adoDR["usuario"].ToString().Trim() + "|sistema";
                    ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByValue(this.arrPermisos[Convert.ToInt32(adoDR["sistema"].ToString()) - 1].ToString()));
                    cell1.Controls.Add(ddl);
                    ddl = new DropDownList
                    {
                        DataSource = this.arrPermisos
                    };
                    ddl.DataBind();
                    ddl.ID = adoDR["usuario"].ToString().Trim() + "|correo";
                    ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByValue(this.arrPermisos[Convert.ToInt32(adoDR["correo"].ToString()) - 1].ToString()));
                    cell2.Controls.Add(ddl);
                    ddl = new DropDownList
                    {
                        DataSource = this.arrPermisos
                    };
                    ddl.DataBind();
                    ddl.ID = adoDR["usuario"].ToString().Trim() + "|ficha";
                    ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByValue(this.arrPermisos[Convert.ToInt32(adoDR["ficha"].ToString()) - 1].ToString()));
                    cell3.Controls.Add(ddl);
                    ddl = new DropDownList
                    {
                        DataSource = this.arrPermisos
                    };
                    ddl.DataBind();
                    ddl.ID = adoDR["usuario"].ToString().Trim() + "|sincronizacion";
                    ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByValue(this.arrPermisos[Convert.ToInt32(adoDR["sincronizacion"].ToString()) - 1].ToString()));
                    cell4.Controls.Add(ddl);
                    ddl = new DropDownList
                    {
                        DataSource = this.arrPermisos
                    };
                    ddl.DataBind();
                    ddl.ID = adoDR["usuario"].ToString().Trim() + "|certificado";
                    ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByValue(this.arrPermisos[Convert.ToInt32(adoDR["certificado"].ToString()) - 1].ToString()));
                    cell5.Controls.Add(ddl);
                    cell0.Style.Add("letter-spacing", "1px");
                    row.Cells.Add(cell0);
                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    row.Cells.Add(cell3);
                    row.Cells.Add(cell4);
                    row.Cells.Add(cell5);
                    row.Cells.Add(cell6);
                    this.permisos.Rows.Add(row);
                }
                this.permisos.BorderColor = ColorTranslator.FromHtml("#999999");
                this.permisos.BorderWidth = Unit.Pixel(1);
                this.permisos.BorderStyle = BorderStyle.None;
                this.permisos.HorizontalAlign = HorizontalAlign.Center;
                this.permisos.BackColor = Color.White;
                this.titulos.Visible = true;
            }
            else
            {
                this.headerTable.Text = "No hay permisos personalizados.";
            }
            this.permisos_div.Visible = true;

        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            this.Session.Remove("editar_formato_id");
            if ((this.Session["administrador"].ToString() == "False") && (this.Session["escritura"].ToString() == "False"))
            {
                base.Response.Write("<h2>No tiene suficientes permisos para ver esta p&aacute;gina.</h2>");
                base.Response.End();
            }
            if (!base.IsPostBack)
            {
                this.cargarPermisos();
            }

        }

    } // class remitentes

}

