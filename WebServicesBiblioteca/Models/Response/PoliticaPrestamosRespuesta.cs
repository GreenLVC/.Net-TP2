namespace WebServicesBiblioteca.Models.Response
{
    public class PoliticaPrestamoRespuesta
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }

        public List<PoliticaPrestamo> Data { get; set; }

        public PoliticaPrestamoRespuesta()
        { 
        Exito = 0; 
        }
    }
}
