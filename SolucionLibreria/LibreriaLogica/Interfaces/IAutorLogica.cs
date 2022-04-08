using LibreriaEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaLogica.Interfaces
{
    public interface IAutorLogica
    {
        List<Autor> ListarAutores();
        List<Autor> Busqueda(string nombreAutor);
        Autor Detalle(int id);
    }
}
