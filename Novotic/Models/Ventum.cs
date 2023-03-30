using System;
using System.Collections.Generic;

namespace Novotic.Models
{
    public partial class Ventum
    {
        public int CodigoVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal ValorTotalVenta { get; set; }
        public int? IdCliente { get; set; }
    }
}
