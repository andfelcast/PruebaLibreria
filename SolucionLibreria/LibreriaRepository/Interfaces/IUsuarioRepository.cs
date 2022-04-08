using LibreriaEntities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaRepository.Interfaces
{
    public interface IUsuarioRepository
    {
        bool Login(LoginDto objUsuario);
    }
}
