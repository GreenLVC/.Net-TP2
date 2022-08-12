namespace WebServicesBiblioteca.Models.Request
{
    public class LineaPrestamoRequest
    {
        public int IdLineaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public bool Devuelto { get; set; }
        public int IdEjemplar { get; set; }
        public int IdPrestamo { get; set; }

    }
}
