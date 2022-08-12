namespace WebServicesBiblioteca.Models.Request
{
    public class LibroRequest
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; } = null!;
        public string Isbn { get; set; } = null!;
        public int NroEdicion { get; set; }
        public DateTime FechaEdicion { get; set; }
        public int CantDiasMaxPrestamo { get; set; }

    }
}
