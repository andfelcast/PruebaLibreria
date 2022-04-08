using LibreriaEntities.Entities;
using LibreriaRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibreriaRepository.Implementacion
{
    public class LibroRepository : ILibroRepository
    {
        private LibreriaDBContext _context;

        public LibroRepository(LibreriaDBContext context)
        {
            _context = context;
        }

        public List<Libro> Listar()
        {
            return _context.Libro.Include(x => x.Autor).ToList();
        }

        public List<Libro> Buscar(string nombre, int anioInicio = 0, int anioFin = int.MaxValue)
        {
            if (string.IsNullOrEmpty(nombre) && anioInicio == 0 && anioFin == int.MaxValue)
                return Listar();
            return _context.Libro.Where(x => x.Autor.Nombre.Contains(nombre) && x.AnioPublicacion <= anioFin && x.AnioPublicacion >= anioInicio).Include(x=> x.Autor).ToList();
        }

        public Libro Detalle(int id) {
            return _context.Libro.Include(x => x.Autor).First(x => x.IdLibro == id);
        }
    }
}
