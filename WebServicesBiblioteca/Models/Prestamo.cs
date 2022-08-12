using System;
using System.Collections.Generic;

namespace WebServicesBiblioteca.Models
{
    public partial class Prestamo
    {
        public Prestamo()
        {
            LineasPrestamos = new HashSet<LineasPrestamo>();
        }

        public int IdPrestamo { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public int IdSocio { get; set; }

        public virtual Socio IdSocioNavigation { get; set; } = null!;
        public virtual ICollection<LineasPrestamo> LineasPrestamos { get; set; }
    }
}
