using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LibreriaEntities.Entities
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string UsuarioAcceso { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaLogout { get; set; }
    }
}
