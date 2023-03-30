using System;
using System.Collections.Generic;

namespace Novotic.Models
{
    public partial class DetalleVentum
    {
        public int CodigoDetalleVenta { get; set; }
        public decimal PrecioUnitarioDetalleVenta { get; set; }
        public decimal CantidadDetalleVenta { get; set; }
        public decimal ValorTotalDetalleVenta { get; set; }
        public decimal SubtotalDetalleVenta { get; set; }
        public int? CodigoVenta { get; set; }
        public int? CodigoProducto { get; set; }
    }
}
