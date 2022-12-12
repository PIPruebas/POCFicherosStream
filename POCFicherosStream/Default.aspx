<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="POCFicherosStream._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <asp:Panel ID="PnlMensaje" runat="server" Visible="false">
        <div class="row">
            <div class="alert alert-danger" role="alert">
                <asp:Label ID="LblMensaje" runat="server" />
            </div>
        </div>
    </asp:Panel>

    <div class="row">
        <div class="col-md-4">
            <div class="row">
                <div class="col-md-12">
                    <h2>PDF con WriteFile</h2>
                    <p>
                        Descarga un PDF utilizando WriteFile.
                    </p>
                    <p>
                        <asp:Button ID="BtnDescargarPDF" runat="server" Text="Descargar pdf" CssClass="btn btn-default" OnClick="BtnDescargarPDF_Click" />
                    </p>
                </div>
                <div class="col-md-12">
                    <h2>PDF con HyperLink</h2>
                    <p>
                        Descarga un PDF con HyperLink.
                    </p>
                    <p>
                        <asp:HyperLink ID="HLAbrirFichero" runat="server" CssClass="btn btn-default" Text="Descargar pdf" Target="_blank" />
                    </p>
                </div>
                <div class="col-md-12">
                    <h2>PDF con Session</h2>
                    <p>
                        Descarga un PDF con Session.
                    </p>
                    <p>
                        <asp:Button ID="BtnPDFSession" runat="server" Text="Descargar pdf" CssClass="btn btn-default" OnClick="BtnPDFSession_Click" OnClientClick="target ='_blank';" />
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="row">
                <div class="col-md-12">
                    <h2>Imagen con TransmitFile</h2>
                    <p>
                        Muestra una imagen utilizando TransmitFile.
                    </p>
                    <p>
                        <asp:Button ID="BtnDescargarImagen" runat="server" Text="Descargar imagen" CssClass="btn btn-default" OnClick="BtnDescargarImagen_Click" />
                    </p>
                </div>
                <div class="col-md-12">
                    <h2>Imagen con HyperLink</h2>
                    <p>
                        Muestra una imagen con HyperLink.
                    </p>
                    <p>
                        <asp:HyperLink ID="HLAbrirImagen" runat="server" CssClass="btn btn-default" Text="Descargar imagen" Target="_blank" />
                    </p>
                </div>
                <div class="col-md-12">
                    <h2>Imagen con Session</h2>
                    <p>
                        Muestra una imagen utilizando Session..
                    </p>
                    <p>
                        <asp:Button ID="BtnImagenSession" runat="server" Text="Descargar imagen" CssClass="btn btn-default" OnClick="BtnImagenSession_Click" OnClientClick="target ='_blank';" />
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <h2>Formas de descarga</h2>
            <h3>Descargando con WriteFile</h3>
            <p>This method loads the file being download to the server's memory before sending it to the client. If the file size is large, you might the ASPNET worker process might get restarted.</p>
            <h3>Descargando con TransmitFile</h3>
            <p>This method sends the file to the client without loading it to the Application memory on the server. It is the ideal way to use it if the file size being download is large.</p>
            <h3>Descargando con HyperLink</h3>
            <p>Para poder abrir el enlace en otra pestaña es necesario crear un link con un target = “_blank” para ello se crea una página que recibe el nombre del fichero o un GUID que se genere al vuelo y sea esta página la que muestre el archivo.</p>
            <h3>Descargando con Session</h3>
            <p>Para poder abrir el enlace en otra página desde un asp:button añadir OnClientClick="target ='_blank';" esto permite ejecutar el código del servidor y la respuesta abrirla en otra pestaña.</p>
            <h3>Enlaces</h3>
            <ul>
                <li><a href="https://stackoverflow.com/questions/2110660/c-sharp-response-writefile-vs-response-transmitfile-filesize-issues">C# Response.WriteFile vs Response.TransmitFile filesize issues</a></li>
                <li><a href="https://stackoverflow.com/questions/34510275/how-to-open-page-in-new-tab-using-the-response-redirect-at-asp-net">How to open page in new tab using the response. redirect at asp.net</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
