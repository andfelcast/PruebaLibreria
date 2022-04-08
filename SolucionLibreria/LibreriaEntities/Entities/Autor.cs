using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LibreriaEntities.Entities
{
    public partial class Autor
    {
        public Autor()
        {
            Libro = new HashSet<Libro>();
        }

        public int IdAutor { get; set; }
        public string Nombre { get; set; }
        public string PaisOrigen { get; set; }

        public virtual ICollection<Libro> Libro { get; set; }
    }
}
