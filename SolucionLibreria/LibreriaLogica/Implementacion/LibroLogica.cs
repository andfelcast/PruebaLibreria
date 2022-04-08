using LibreriaEntities.DTO;
using LibreriaEntities.Entities;
using LibreriaLogica.Interfaces;
using LibreriaRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaLogica.Implementacion
{
    public class LibroLogica : ILibroLogica
    {
        private ILibroRepository repository;

        public LibroLogica(ILibroRepository LibroRepository)
        {
            repository = LibroRepository;
        }

        public List<Libro> ListarLibros()
        {
            return repository.Listar();
        }

        public List<Libro> Busqueda(BusquedaDto objBusqueda)
        {
            int inicio = 0;
            int fin = int.MaxValue;
            if (objBusqueda.AnioInicio != 0)
                inicio = objBusqueda.AnioInicio;
            if (objBusqueda.AnioFin != 0) {
                fin = objBusqueda.AnioFin;
            }
            if (string.IsNullOrEmpty(objBusqueda.NombreLibro))
                objBusqueda.NombreLibro = " ";
            return repository.Buscar(objBusqueda.NombreLibro,inicio,fin);
        }

        public Libro Detalle(int id) {
            return repository.Detalle(id);
        }
    }
}
