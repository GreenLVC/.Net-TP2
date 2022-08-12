namespace WebServicesBiblioteca.Models.Request
{
    public class PrestamoRequest
    {
        public int IdPrestamo { get; set; }
        public DateTime FechaPrestamo { get; set; }  

        public int IdSocio { get; set; }

    }
}
