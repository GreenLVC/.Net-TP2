namespace WebServicesBiblioteca.Models.Response
{
    public class LineasPrestamosRespuesta
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }

        public List<LineasPrestamo> Data { get; set; }

        public LineasPrestamosRespuesta()
        { 
        Exito = 0; 
        }
    }
}
