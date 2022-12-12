using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POCFicherosStream
{
    public partial class DescargarFichero : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["fichero"] != null)
                {
                    string fichero = Request.QueryString["fichero"];
                    string rutaFicheros = System.Configuration.ConfigurationManager.AppSettings["RutaFicheros"];

                    if (string.IsNullOrEmpty(fichero) == false && string.IsNullOrEmpty(rutaFicheros) == false)
                    {
                        fichero = Path.Combine(rutaFicheros, fichero);

                        if (File.Exists(fichero))
                        {
                            string mimeType = MimeMapping.GetMimeMapping(fichero);
                            Response.ContentType = mimeType;
                            Response.AddHeader("content-disposition", string.Format("inline; filename={0}", System.Configuration.ConfigurationManager.AppSettings["NombreFicheroImagen"]));
                            Response.TransmitFile(fichero);
                            Response.End();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // MostrarError($"No existe el fichero {ex.Message}");
            }
        }
    }
}