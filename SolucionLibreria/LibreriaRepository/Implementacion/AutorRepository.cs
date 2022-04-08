using LibreriaEntities.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;
using LibreriaRepository.Interfaces;

namespace LibreriaRepository.Implementacion
{
    public class AutorRepository : IAutorRepository
    {
        private LibreriaDBContext _context;

        public AutorRepository(LibreriaDBContext context)
        {
            _context = context;
        }

        public List<Autor> Listar() {
            return _context.Autor.Include(x=>x.Libro).ToList();
        }

        public List<Autor> Buscar(string nombre)
        {
            if (nombre.Length == 0)
                return Listar();
            return _context.Autor.Where(x => x.Nombre.Contains(nombre)).Include(y => y.Libro).ToList();
        }

        public Autor Detalle(int id) {
            return _context.Autor.Include(x => x.Libro).FirstOrDefault(x => x.IdAutor == id);
        }
    }
}
