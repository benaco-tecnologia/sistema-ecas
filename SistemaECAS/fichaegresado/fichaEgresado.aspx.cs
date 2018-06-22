using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FichaEgresado
{

    public class WebForm1 : System.Web.UI.Page
    {

        protected System.Web.UI.WebControls.TableCell anoingreso;
        protected System.Web.UI.WebControls.TableCell anoegreso;
        protected System.Web.UI.WebControls.TableCell anotitulacion;
        protected System.Web.UI.WebControls.TableCell correo;
        protected System.Web.UI.WebControls.TableCell rut;
        protected System.Web.UI.WebControls.TableCell numeroecas;
        protected System.Web.UI.WebControls.TableCell fechanacimiento;
        protected System.Web.UI.WebControls.Table datosPersonales;
        protected System.Web.UI.WebControls.TableCell direccion;
        protected System.Web.UI.WebControls.TableCell direccionLaboral;
        protected System.Web.UI.WebControls.TableCell estacad;
        protected System.Web.UI.WebControls.Table estudioExtra;
        protected System.Web.UI.WebControls.Table historiaLaboral;
        protected System.Web.UI.WebControls.HyperLink hlDatosPersonales;
        protected System.Web.UI.WebControls.Table idiomas;
        protected System.Web.UI.WebControls.Image Image1;
        protected System.Web.UI.WebControls.Image Image2;
        protected System.Web.UI.WebControls.Image Image3;
        protected System.Web.UI.WebControls.Image Image4;
        protected System.Web.UI.WebControls.HyperLink linkAgregarEstudio;
        protected System.Web.UI.WebControls.HyperLink linkAgregarExperiencia;
        protected System.Web.UI.WebControls.HyperLink linkAgregarIdioma;
        protected System.Web.UI.WebControls.HyperLink linkAgregarNota;
        protected System.Web.UI.WebControls.TableCell nombre;
        protected System.Web.UI.WebControls.Table notas;
        private string tabla;
        protected System.Web.UI.WebControls.TableCell telefono;
        protected System.Web.UI.WebControls.TableRow tituloEstudio;
        protected System.Web.UI.WebControls.TableRow tituloIdioma;
        protected System.Web.UI.WebControls.TableRow tituloNota;
        protected System.Web.UI.WebControls.TableRow titulosLaboral;

        public WebForm1()
        {
            tabla = System.Configuration.ConfigurationManager.AppSettings["tbPrEg"].ToString();
        }

        private void estudio(string rut)
        {
            tituloEstudio.Visible = true;
            System.Data.SqlClient.SqlConnection adoConn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString);
            adoConn.Open();
            System.Web.UI.WebControls.TableRow row = new System.Web.UI.WebControls.TableRow();
            System.Web.UI.WebControls.TableCell cell1 = new System.Web.UI.WebControls.TableCell();
            System.Web.UI.WebControls.TableCell cell2 = new System.Web.UI.WebControls.TableCell();
            System.Web.UI.WebControls.TableCell cell3 = new System.Web.UI.WebControls.TableCell();
            cell2.Font.Bold = true;

            string sql = "select anotit, anoegre, rut, nombre_c from MT_ALUMNO, mt_carrer where MT_ALUMNO.codcarpr = mt_carrer.codcarr AND rut = '" + rut + "';";
            SqlCommand adoCmd = new System.Data.SqlClient.SqlCommand(sql, adoConn);
            SqlDataReader adoDR = adoCmd.ExecuteReader();

            if (adoDR.HasRows)
            {
                if (adoDR.Read())
                {
                    if ("".Equals(adoDR["anotit"].ToString()) || "null".Equals(adoDR["anotit"].ToString().ToLower()) || "0".Equals(adoDR["anotit"].ToString())) 
                    {
                        if ("".Equals(adoDR["anoegre"].ToString()) || "null".Equals(adoDR["anoegre"].ToString().ToLower()) || "0".Equals(adoDR["anoegre"].ToString()))
                        {
                            cell1.Text = "Sin informaci&oacte;n";
                        }
                        else
                        {
                            cell1.Text = adoDR["anoegre"].ToString();
                        }
                    }
                    else
                    {
                        cell1.Text = adoDR["anotit"].ToString();
                    }

                    cell2.Text = adoDR["nombre_c"].ToString() + "<br />Escuela de Contadores Auditores de Santiago";
                    cell3.Text = "Profesional";
                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    row.Cells.Add(cell3);
                    estudioExtra.Rows.Add(row);
                }
            }

            adoDR.Close();
            adoDR = null;
            adoCmd = null;
            sql = "SELECT " + tabla + "tipoEstudio.tipo, " + tabla + "estudioExtra.egreso, " + tabla + "estudioExtra.institucion, " + tabla + "estudioExtra.titulo, " + tabla + "estudioExtra.estudioExtraID FROM " + tabla + "estudioExtra, " + tabla + "tipoEstudio WHERE rut = " + rut + " AND " + tabla + "tipoEstudio.tipoEstudioID = " + tabla + "estudioExtra.tipoEstudioID;";
            adoCmd = new SqlCommand(sql, adoConn);
            adoDR = adoCmd.ExecuteReader();
            if (adoDR.HasRows)
            {
                while (adoDR.Read())
                {
                    System.Web.UI.WebControls.TableRow row1 = new System.Web.UI.WebControls.TableRow();
                    System.Web.UI.WebControls.TableCell cell1_1 = new System.Web.UI.WebControls.TableCell();
                    System.Web.UI.WebControls.TableCell cell2_1 = new System.Web.UI.WebControls.TableCell();
                    System.Web.UI.WebControls.TableCell cell3_1 = new System.Web.UI.WebControls.TableCell();
                    cell2_1.Font.Bold = true;
                    cell1_1.Text = adoDR["egreso"].ToString();
                    cell2_1.Text = adoDR["titulo"].ToString() + "<br />" + adoDR["institucion"].ToString();
                    cell3_1.Text = adoDR["tipo"].ToString();
                    row1.Cells.Add(cell1_1);
                    row1.Cells.Add(cell2_1);
                    row1.Cells.Add(cell3_1);
                    System.Web.UI.WebControls.TableCell cellx = new System.Web.UI.WebControls.TableCell();
                    System.Web.UI.WebControls.HyperLink hl = new System.Web.UI.WebControls.HyperLink();
                    System.Web.UI.WebControls.Image im = new System.Web.UI.WebControls.Image();
                    im.ImageUrl = "imagenes/cross.png";
                    im.AlternateText = "Borrar";
                    hl.Controls.Add(im);
                    hl.NavigateUrl = "borrarEstudio.aspx?rut=" + rut + "&estudioExtraID=" + adoDR["estudioExtraID"].ToString();
                    System.Web.UI.WebControls.HyperLink h2 = new System.Web.UI.WebControls.HyperLink();
                    System.Web.UI.WebControls.Image im2 = new System.Web.UI.WebControls.Image();
                    im2.ImageUrl = "imagenes/page_edit.png";
                    im2.AlternateText = "Editar";
                    h2.Controls.Add(im2);
                    h2.NavigateUrl = "agregarEstudio.aspx?rut=" + rut + "&estudioExtraID=" + adoDR["estudioExtraID"].ToString();

                    // Revision de permisos para usuarios con acceso de solo lectura
                    if (Session["ficha"].ToString().Equals(ConfigurationManager.AppSettings["escritura"].ToString()))
                    {
                        cellx.Controls.Add(hl);
                        cellx.Controls.Add(h2);
                    }

                    cellx.Width = (System.Web.UI.WebControls.Unit)10;
                    cellx.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
                    row1.Cells.Add(cellx);
                    estudioExtra.Rows.Add(row1);
                }
            }
        }

        private void idioma(string rut)
        {
            string sql = "SELECT " + this.tabla + "idioma.idioma, " + this.tabla + "idiomas.idiomaID, " + this.tabla + "idiomas.oral, " + this.tabla + "idiomas.escrito FROM " + this.tabla + "idiomas, " + this.tabla + "idioma WHERE rut = " + rut + " AND " + this.tabla + "idiomas.idiomaID = " + this.tabla + "idioma.idiomaID;";
            SqlConnection adoConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString);
            adoConn.Open();
            SqlDataReader adoDR = new SqlCommand(sql, adoConn).ExecuteReader();
            if (adoDR.HasRows)
            {
                while (adoDR.Read())
                {
                    TableRow row = new TableRow();
                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();
                    TableCell cell3 = new TableCell();
                    cell1.Font.Bold = true;
                    cell1.Text = adoDR["idioma"].ToString();
                    Image im3 = new Image
                    {
                        ImageUrl = "imagenes/star" + adoDR["oral"].ToString() + ".png"
                    };
                    cell2.Controls.Add(im3);
                    cell2.HorizontalAlign = HorizontalAlign.Center;
                    Image im2 = new Image
                    {
                        ImageUrl = "imagenes/star" + adoDR["escrito"].ToString() + ".png"
                    };
                    cell3.Controls.Add(im2);
                    cell3.HorizontalAlign = HorizontalAlign.Center;
                    row.Cells.Add(cell1);
                    row.Cells.Add(cell3);
                    row.Cells.Add(cell2);
                    TableCell cellx = new TableCell();
                    HyperLink hl = new HyperLink();
                    Image im = new Image
                    {
                        ImageUrl = "imagenes/cross.png",
                        AlternateText = "Borrar"
                    };
                    hl.Controls.Add(im);
                    hl.NavigateUrl = "borrarIdioma.aspx?rut=" + rut + "&idiomaID=" + adoDR["idiomaID"].ToString();
                    HyperLink h2 = new HyperLink();
                    Image im4 = new Image
                    {
                        ImageUrl = "imagenes/page_edit.png",
                        AlternateText = "Editar"
                    };
                    h2.Controls.Add(im4);
                    h2.NavigateUrl = "agregarIdioma.aspx?rut=" + rut + "&idiomaID=" + adoDR["idiomaID"].ToString();
                    
                    // Revision de permisos para usuarios con acceso de solo lectura
                    if (Session["ficha"].ToString().Equals(ConfigurationManager.AppSettings["escritura"].ToString()))
                    {
                        cellx.Controls.Add(hl);
                        cellx.Controls.Add(h2);
                    }

                    cellx.Width = 10;
                    cellx.HorizontalAlign = HorizontalAlign.Right;
                    row.Cells.Add(cellx);
                    this.idiomas.Rows.Add(row);
                }
                this.tituloIdioma.Visible = true;
            }
            adoDR.Close();
            adoConn.Close();
            adoDR = null;
            adoConn = null;

        }

        private void informacionLaboral(string rut)
        {
            string sql = "SELECT " + this.tabla + "historiaLaboral.historiaLaboralID, " + this.tabla + "historiaLaboral.desdeMes," + this.tabla + "historiaLaboral.desdeAnio," + this.tabla + "historiaLaboral.hastaMes," + this.tabla + "historiaLaboral.hastaAnio," + this.tabla + "historiaLaboral.cargo," + this.tabla + "historiaLaboral.empresa,responsabilidades, " + this.tabla + "rangoRenta.montoDesde + ' - ' + " + this.tabla + "rangoRenta.montoHasta AS Rango FROM " + this.tabla + "historiaLaboral, " + this.tabla + "rangoRenta WHERE rut = " + rut.ToString() + " AND " + this.tabla + "rangoRenta.rangoRentaID = " + this.tabla + "historiaLaboral.rangoRentaID";
            SqlConnection adoConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString);
            adoConn.Open();
            SqlDataReader adoDR = new SqlCommand(sql, adoConn).ExecuteReader();
            if (adoDR.HasRows)
            {
                while (adoDR.Read())
                {
                    TableRow row = new TableRow();
                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();
                    TableCell cell3 = new TableCell();
                    TableCell cell4 = new TableCell();
                    cell2.Font.Bold = true;
                    cell3.HorizontalAlign = HorizontalAlign.Center;
                    cell1.Text = adoDR["desdeMes"].ToString() + "/" + adoDR["desdeAnio"].ToString() + "<br />" + adoDR["hastaMes"].ToString() + "/" + adoDR["hastaAnio"].ToString();
                    cell2.Text = adoDR["cargo"].ToString() + "<br />" + adoDR["empresa"].ToString();
                    cell3.Text = adoDR["Rango"].ToString();
                    cell4.Text = adoDR["responsabilidades"].ToString();
                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    row.Cells.Add(cell3);
                    row.Cells.Add(cell4);
                    TableCell cellx = new TableCell();
                    HyperLink hl = new HyperLink();
                    Image im = new Image
                    {
                        ImageUrl = "imagenes/cross.png",
                        AlternateText = "Borrar"
                    };
                    hl.Controls.Add(im);
                    hl.NavigateUrl = "borrarLaboral.aspx?rut=" + rut + "&historiaLaboralID=" + adoDR["historiaLaboralID"].ToString();
                    HyperLink h2 = new HyperLink();
                    Image im2 = new Image
                    {
                        ImageUrl = "imagenes/page_edit.png",
                        AlternateText = "Editar"
                    };
                    h2.Controls.Add(im2);
                    h2.NavigateUrl = "agregarLaboral.aspx?rut=" + rut + "&historiaLaboralID=" + adoDR["historiaLaboralID"].ToString();

                    // Revision de permisos para usuarios con acceso de solo lectura
                    if (Session["ficha"].ToString().Equals(ConfigurationManager.AppSettings["escritura"].ToString()))
                    {
                        cellx.Controls.Add(hl);
                        cellx.Controls.Add(h2);
                    }

                    cellx.Width = 20;
                    cellx.HorizontalAlign = HorizontalAlign.Right;
                    row.Cells.Add(cellx);
                    this.historiaLaboral.Rows.Add(row);
                }
                this.titulosLaboral.Visible = true;
            }
            adoDR.Close();
            adoConn.Close();
            adoDR = null;
            adoConn = null;

        }

        private void informacionPersonal(string rut)
        {
            string sql = "SELECT rut, dig, codcli, nombre, fecnac, paterno, materno, anoegre, anotit, DATEPART(year, fecing) as anoingreso, mail, estacad, anotit, fecnac, diractual, comuna, ciudadact, fonoact " +
                         "FROM " + tabla + "listado WHERE rut = " + rut;
            System.Data.SqlClient.SqlConnection adoConn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString);
            adoConn.Open();
            System.Data.SqlClient.SqlCommand adoCmd = new System.Data.SqlClient.SqlCommand(sql, adoConn);
            System.Data.SqlClient.SqlDataReader adoDR = adoCmd.ExecuteReader();
            if (adoDR.HasRows)
            {
                while (adoDR.Read())
                {
                    nombre.Text = adoDR["nombre"].ToString() + " " + adoDR["paterno"].ToString() + " " + adoDR["materno"].ToString();
                    direccion.Text = adoDR["diractual"].ToString() + ". " + adoDR["comuna"].ToString() + " " + adoDR["ciudadact"].ToString();
                    telefono.Text = adoDR["fonoact"].ToString();
                    estacad.Text = adoDR["estacad"].ToString();
                    correo.Text = adoDR["mail"].ToString();
                    anotitulacion.Text = adoDR["anotit"].ToString() != "0" ? adoDR["anotit"].ToString() : "Sin informaci&oacute;n";
                    anoingreso.Text = adoDR["anoingreso"].ToString() != "0" ? adoDR["anoingreso"].ToString() : "Sin informaci&oacute;n";
                    anoegreso.Text = adoDR["anoegre"].ToString() != "0" ? adoDR["anoegre"].ToString() : "Sin informaci&oacute;n";
                    this.rut.Text = adoDR["rut"].ToString() + "-" + adoDR["dig"].ToString();
                    numeroecas.Text = adoDR["codcli"].ToString();
                    fechanacimiento.Text = adoDR["fecnac"].ToString().Replace(" 0:00:00", "");
                }
            }
            adoDR.Close();
            adoConn.Close();
            adoDR = null;
            adoCmd = null;
            adoConn = null;
            direccionLaboral.Text = "Sin informaci&oacute;n disponible.";
            sql = "SELECT rut, calle, comuna, ciudad FROM " + tabla + "historiaLaboral WHERE rut = '" + rut + "' AND hastaAnio = -1 AND hastaMes = -1";
            adoConn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString);
            adoConn.Open();
            adoCmd = new System.Data.SqlClient.SqlCommand(sql, adoConn);
            adoDR = adoCmd.ExecuteReader();
            if (adoDR.HasRows)
            {
                if (adoDR.Read())
                    direccionLaboral.Text = adoDR["calle"].ToString() + ". " + adoDR["comuna"].ToString() + " " + adoDR["ciudad"].ToString();
                else
                    direccionLaboral.Text = "Informaci&oacute;n no disponible.";
            }
            else
            {
                direccionLaboral.Text = "Informaci&oacute;n no disponible.";
            }
            adoDR.Close();
            adoConn.Close();
            adoDR = null;
            adoCmd = null;
            adoConn = null;

            // Revision de permisos para usuarios con acceso de solo lectura
            if (!Session["ficha"].ToString().Equals(ConfigurationManager.AppSettings["escritura"].ToString()))
            {
                hlDatosPersonales.Visible = false;
            }
        }

        private void nota(string rut)
        {
            string sql = "SELECT fecha, nota, notaID FROM " + this.tabla + "nota WHERE rut = " + rut + " ORDER BY fecha DESC;";
            SqlConnection adoConn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseSqlServer"].ConnectionString);
            adoConn.Open();
            SqlDataReader adoDR = new SqlCommand(sql, adoConn).ExecuteReader();
            if (adoDR.HasRows)
            {
                while (adoDR.Read())
                {
                    TableRow row = new TableRow();
                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();
                    cell1.Text = adoDR["fecha"].ToString();
                    cell2.Text = adoDR["nota"].ToString();
                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    TableCell cellx = new TableCell();
                    HyperLink hl = new HyperLink();
                    Image im = new Image
                    {
                        ImageUrl = "imagenes/cross.png",
                        AlternateText = "Borrar"
                    };
                    hl.Controls.Add(im);
                    hl.NavigateUrl = "borrarNota.aspx?rut=" + rut + "&notaID=" + adoDR["notaID"].ToString();

                    // Revision de permisos para usuarios con acceso de solo lectura
                    if (Session["ficha"].ToString().Equals(ConfigurationManager.AppSettings["escritura"].ToString()))
                    {
                        cellx.Controls.Add(hl);
                    }

                    cellx.Width = 10;
                    cellx.HorizontalAlign = HorizontalAlign.Right;
                    row.Cells.Add(cellx);
                    this.notas.Rows.Add(row);
                }
                this.tituloNota.Visible = true;
            }
            adoDR.Close();
            adoConn.Close();
            adoDR = null;
            adoConn = null;

        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            string rut = Request.QueryString["rut"].ToString();
            Page.Title = Page.Title + " -rut " + rut;
            linkAgregarNota.NavigateUrl = "./agregarNota.aspx?rut=" + rut;
            linkAgregarExperiencia.NavigateUrl = "./agregarLaboral.aspx?rut=" + rut;
            linkAgregarIdioma.NavigateUrl = "./agregarIdioma.aspx?rut=" + rut;
            linkAgregarEstudio.NavigateUrl = "./agregarEstudio.aspx?rut=" + rut;
            hlDatosPersonales.NavigateUrl = "./editarPersonales.aspx?rut=" + rut;
            informacionPersonal(rut);
            informacionLaboral(rut);
            nota(rut);
            idioma(rut);
            estudio(rut);

            if (!Session["ficha"].ToString().Equals(ConfigurationManager.AppSettings["escritura"].ToString()))
            {
                linkAgregarNota.Visible = false;
                linkAgregarExperiencia.Visible = false;
                linkAgregarIdioma.Visible = false;
                linkAgregarEstudio.Visible = false;
            }
        }

    } // class WebForm1

}

