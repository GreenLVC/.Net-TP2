namespace WebServicesBiblioteca.Models.Response
{
    public class SocioRespuesta
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }

        public List<Socio> Data { get; set; }

        public SocioRespuesta()
        { 
        Exito = 0; 
        }
    }
}
