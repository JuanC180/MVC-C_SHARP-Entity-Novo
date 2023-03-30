using System;
using System.Collections.Generic;

namespace Novotic.Models
{
    public partial class Cartera
    {
        public int CodigoCartera { get; set; }
        public DateTime FechaCartera { get; set; }
        public int CoutaRestanteCartera { get; set; }
        public decimal PendienteCartera { get; set; }
        public bool EstadoCartera { get; set; }
        public int? IdCliente { get; set; }
        public int? CodigoVenta { get; set; }

    }
}
