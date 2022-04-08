using LibreriaEntities.DTO;
using LibreriaEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaLogica.Interfaces
{
    public interface ILibroLogica
    {
        List<Libro> ListarLibros();

        List<Libro> Busqueda(BusquedaDto objBusqueda);

        Libro Detalle(int id);
    }
}
