using System;
using System.Collections.Generic;

namespace Novotic.Models
{
    public partial class Producto
    {
        public int CodigoProducto { get; set; }
        public string NombreProducto { get; set; } = null!;
        public decimal PrecioPrducto { get; set; }
        public string DescripcionProducto { get; set; } = null!;
        public byte[] Imagen { get; set; } = null!;
        public bool? Estado { get; set; }
    }
}
