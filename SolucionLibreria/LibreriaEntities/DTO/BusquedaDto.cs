using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaEntities.DTO
{
    public class BusquedaDto
    {
        public string NombreLibro { get; set; }

        public int AnioInicio { get; set; }

        public int AnioFin { get; set; }
    }
}
