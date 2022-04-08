using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LibreriaEntities.Entities
{
    public partial class Libro
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public int AnioPublicacion { get; set; }
        public int IdAutor { get; set; }

        public virtual Autor Autor { get; set; }
    }
}
