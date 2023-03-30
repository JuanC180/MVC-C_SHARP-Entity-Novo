using System;
using System.Collections.Generic;

namespace Novotic.Models
{
    public partial class Cliente
    {
        public int IdCliente { get; set; }
        public string CedulaCliente { get; set; } = null!;
        public string NombreCliente { get; set; } = null!;
        public string ApellidoCliente { get; set; } = null!;
        public string EmailCliente { get; set; } = null!;
        public string TelefonoCliente { get; set; } = null!;
        public string DireccionCliente { get; set; } = null!;
        public string? CamaraComercioCliente { get; set; }
        public string? NitRutCliente { get; set; }
        public string DepartamentoCliente { get; set; } = null!;
        public string CiudadCliente { get; set; } = null!;
        public string? EstadoCliente { get; set; }
        public string PasswordCliente { get; set; } = null!;
        public int? RolCliente { get; set; }
    }
}
