using LibreriaEntities.DTO;
using LibreriaLogica.Interfaces;
using LibreriaRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaLogica.Implementacion
{
    public class UsuarioLogica : IUsuarioLogica
    {
        private IUsuarioRepository repositorio;

        public UsuarioLogica(IUsuarioRepository usuarioRepository) {
            repositorio = usuarioRepository;
        }

        public bool Login(LoginDto objLogin) {
            return repositorio.Login(objLogin);
        }
    }
}
