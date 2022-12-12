using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace POCFicherosStream.Helpers
{
    public static class Utilidades
    {
        public static void DescargarFichero(this FileStream stream, string fileName, HttpResponse response)
        {
            response.Clear();
            response.ContentType = "application/octet-stream";
            response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
            stream.CopyTo(response.OutputStream);
            response.End();
        }

        public static void DescargarFichero(this FileInfo fichero, HttpResponse response)
        {
            string mimeType = MimeMapping.GetMimeMapping(fichero.FullName);

            using(FileStream stream = new FileStream(fichero.FullName, FileMode.Open, FileAccess.Read))
            {
                response.Clear();
                //response.ClearContent();
                //response.ClearHeaders();
                response.ContentType = mimeType;
                // response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", fichero.Name));
                response.AddHeader("Content-Disposition", string.Format("intline; filename={0}", fichero.Name));
                response.AddHeader("Content-Length", stream.Length.ToString());
                stream.CopyTo(response.OutputStream);
                response.End();
            }
        }
    }
}