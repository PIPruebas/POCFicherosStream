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
                if(IsPostBack == false)
                {
                    string fichero = string.Empty;
                    string rutaFicheros = System.Configuration.ConfigurationManager.AppSettings["RutaFicheros"];

                    // La opción de QueryString se ha dejado para saber que se puede utilizar pero se recomienda
                    // Session para que no se puede descargar cualquier fichero conociendo el nombre
                    if (Request.QueryString["fichero"] != null)
                    {
                        fichero = Request.QueryString["fichero"];
                    }
                    else if (Session["Fichero"] != null)
                    {
                        fichero = Session["Fichero"].ToString();
                    }

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