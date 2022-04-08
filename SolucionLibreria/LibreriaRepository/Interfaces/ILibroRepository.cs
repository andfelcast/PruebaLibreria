using LibreriaEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaRepository.Interfaces
{
    public interface ILibroRepository
    {
        List<Libro> Listar();
        List<Libro> Buscar(string nombre, int anioInicio = 0, int anioFin = int.MaxValue);
        Libro Detalle(int id);
    }
}
