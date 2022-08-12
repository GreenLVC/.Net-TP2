namespace WebServicesBiblioteca.Models.Response
{
    public class PrestamosRespuesta
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }

        public List<Prestamo> Data { get; set; }

        public PrestamosRespuesta()
        { 
        Exito = 0; 
        }
    }
}
