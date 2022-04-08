using LibreriaEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaRepository.Interfaces
{
    public interface IAutorRepository
    {
        List<Autor> Listar();
        List<Autor> Buscar(string nombre);
        Autor Detalle(int id);
    }
}
