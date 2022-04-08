using LibreriaEntities.Entities;
using LibreriaLogica.Interfaces;
using LibreriaRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaLogica.Implementacion
{
    public class AutorLogica: IAutorLogica
    {
        private IAutorRepository repository;

        public AutorLogica(IAutorRepository autorRepository) {
            repository = autorRepository;
        }

        public List<Autor> ListarAutores() {
            return repository.Listar();
        }

        public List<Autor> Busqueda(string nombreAutor) {
            return repository.Buscar(nombreAutor);
        }

        public Autor Detalle(int id) {
            return repository.Detalle(id);
        }
    }
}
