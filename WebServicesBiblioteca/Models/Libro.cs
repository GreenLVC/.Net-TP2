using System;
using System.Collections.Generic;

namespace WebServicesBiblioteca.Models
{
    public partial class Libro
    {
        public Libro()
        {
            Ejemplares = new HashSet<Ejemplare>();
        }

        public int IdLibro { get; set; }
        public string Titulo { get; set; } = null!;
        public string Isbn { get; set; } = null!;
        public int NroEdicion { get; set; }
        public DateTime FechaEdicion { get; set; }
        public int CantDiasMaxPrestamo { get; set; }

        public virtual ICollection<Ejemplare> Ejemplares { get; set; }
    }
}
