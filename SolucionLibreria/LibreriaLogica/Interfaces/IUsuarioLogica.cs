using LibreriaEntities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaLogica.Interfaces
{
    public interface IUsuarioLogica
    {
        bool Login(LoginDto objLogin);
    }
}
