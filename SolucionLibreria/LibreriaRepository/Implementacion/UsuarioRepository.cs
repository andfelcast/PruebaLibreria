using LibreriaEntities.DTO;
using LibreriaEntities.Entities;
using LibreriaRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibreriaRepository.Implementacion
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private LibreriaDBContext _context;

        public UsuarioRepository(LibreriaDBContext context)
        {
            _context = context;
        }

        public List<Usuario> Listar()
        {
            return _context.Usuario.ToList();
        }

        public bool Login(LoginDto objUsuario)
        {
            if (objUsuario.NombreUsuario.Length == 0 || objUsuario.Password.Length == 0)
                return false;
            try
            {
                var usuario = _context.Usuario.FirstOrDefault(x => x.NombreUsuario.Equals(objUsuario.NombreUsuario) && x.Password.Equals(objUsuario.Password));
                if (usuario == null)
                {
                    return false;
                }
                usuario.FechaIngreso = DateTime.Now;
                _context.Usuario.Update(usuario);
                _context.SaveChanges();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        public bool LogOff(string nombreUsuario) {
            try
            {
                var usuario = _context.Usuario.FirstOrDefault(x => x.NombreUsuario.Equals(nombreUsuario));                
                usuario.FechaLogout = DateTime.Now;
                _context.Usuario.Update(usuario);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
