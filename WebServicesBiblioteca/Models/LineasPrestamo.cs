using System;
using System.Collections.Generic;

namespace WebServicesBiblioteca.Models
{
    public partial class LineasPrestamo
    {
        public int IdLineaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public bool Devuelto { get; set; }
        public int IdEjemplar { get; set; }
        public int IdPrestamo { get; set; }

        public virtual Ejemplare IdLineaPrestamoNavigation { get; set; } = null!;
        public virtual Prestamo IdPrestamoNavigation { get; set; } = null!;
    }
}
