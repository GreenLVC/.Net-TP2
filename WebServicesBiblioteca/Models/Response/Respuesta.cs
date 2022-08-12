namespace WebServicesBiblioteca.Models.Response
{
    public class Respuesta
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }

        public List<Socio> Data { get; set; }

        public Respuesta()
        { 
        Exito = 0; 
        }
    }
}
