namespace WebServicesBiblioteca.Models.Response
{
    public class LibroRespuesta
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }

        public List<Libro> Data { get; set; }

        public LibroRespuesta()
        { 
        Exito = 0; 
        }
    }
}
