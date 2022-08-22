using System;
using System.Collections.Generic;

namespace WebServicesBiblioteca.Models
{
    public partial class PoliticaPrestamo
    {
        public DateTime FechaVigencia { get; set; }
        public int CantMaxLibrosPend { get; set; }
    }
}
