using System;
using System.Collections.Generic;

namespace WebServicesBiblioteca.Models
{
    public partial class Ejemplare
    {
        public int IdEjemplar { get; set; }
        public int IdLibro { get; set; }

        public virtual Libro IdLibroNavigation { get; set; } = null!;
        public virtual LineasPrestamo LineasPrestamo { get; set; } = null!;
    }
}
