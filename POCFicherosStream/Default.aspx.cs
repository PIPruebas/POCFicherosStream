using POCFicherosStream.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Optimization;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POCFicherosStream
{
    public partial class _Default : Page
    {
        private string rutaFicheros = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            rutaFicheros = System.Configuration.ConfigurationManager.AppSettings["RutaFicheros"];

            if(IsPostBack == false)
            {
                string nombreFicheroPDF = System.Configuration.ConfigurationManager.AppSettings["NombreFicheroPDF"];

                if(string.IsNullOrEmpty(nombreFicheroPDF) == false)
                {
                    HLAbrirFichero.NavigateUrl = $"DescargarFichero.aspx?fichero={nombreFicheroPDF}";
                }

                string nombreFicheroImagen = System.Configuration.ConfigurationManager.AppSettings["NombreFicheroImagen"];

                if (string.IsNullOrEmpty(nombreFicheroPDF) == false)
                {
                    HLAbrirImagen.NavigateUrl = $"DescargarFichero.aspx?fichero={nombreFicheroImagen}";
                }
            }

            PnlMensaje.Visible = false;
        }

        protected void BtnDescargarPDF_Click(object sender, EventArgs e)
        {
            string rutaFichero = Path.Combine(rutaFicheros, System.Configuration.ConfigurationManager.AppSettings["NombreFicheroPDF"]);

            if (File.Exists(rutaFichero))
            {
                FileInfo informacionFichero = new FileInfo(rutaFichero);
                informacionFichero.DescargarFichero(Response);
            }
            else
            {
                MostrarError($"No existe el fichero {rutaFichero}");
            }
        }

        private void MostrarError(string mensaje)
        {
            PnlMensaje.Visible = true;
            LblMensaje.Text = mensaje;
        }

        protected void BtnDescargarImagen_Click(object sender, EventArgs e)
        {
            string rutaFichero = Path.Combine(rutaFicheros, System.Configuration.ConfigurationManager.AppSettings["NombreFicheroImagen"]);

            if (File.Exists(rutaFichero))
            {
                string mimeType = MimeMapping.GetMimeMapping(rutaFichero);
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", string.Format("inline; filename={0}", System.Configuration.ConfigurationManager.AppSettings["NombreFicheroImagen"]));
                Response.TransmitFile(rutaFichero);
                Response.End();
            }
            else
            {
                MostrarError($"No existe el fichero {rutaFichero}");
            }
        }

        protected void BtnPDFSession_Click(object sender, EventArgs e)
        {
            Session["Fichero"] = System.Configuration.ConfigurationManager.AppSettings["NombreFicheroPDF"];

            Response.Redirect("DescargarFichero.aspx");
        }

        protected void BtnImagenSession_Click(object sender, EventArgs e)
        {
            Session["Fichero"] = System.Configuration.ConfigurationManager.AppSettings["NombreFicheroImagen"];

            Response.Redirect("DescargarFichero.aspx");
        }

        protected void LnkPDFSession_Click(object sender, EventArgs e)
        {
            Session["Fichero"] = System.Configuration.ConfigurationManager.AppSettings["NombreFicheroPDF"];

            Response.Redirect("DescargarFichero.aspx");
        }
    }
}
