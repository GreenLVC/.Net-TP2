using System;
using System.Collections.Generic;

namespace WebServicesBiblioteca.Models
{
    public partial class Socio
    {
        public Socio()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        public int IdSocio { get; set; }
        public string Apellido { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? Email { get; set; }
        public string Domicilio { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public bool Habilitado { get; set; }

        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
