using System;
using System.Collections.Generic;

namespace WebServicesBiblioteca.Models
{
    public partial class PoliticaPrestamo
    {
        public int CantMaxLibrosPend { get; set; }
        public DateTime FechaVigencia { get; set; }
    }
}
