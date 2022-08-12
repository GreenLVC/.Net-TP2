namespace WebServicesBiblioteca.Models.Response
{
    public class EjemplaresRespuesta
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }

        public List<Ejemplare> Data { get; set; }

        public EjemplaresRespuesta()
        { 
        Exito = 0; 
        }
    }
}
