using LibreriaEntities.DTO;
using LibreriaLogica.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibreriaAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private IUsuarioLogica logica;

        public UsuarioController(IUsuarioLogica usuarioLogica) {
            logica = usuarioLogica;
        }

        // GET api/<UsuarioController>/5
        [HttpPost]
        public bool Login(LoginDto objLogin)
        {
            return logica.Login(objLogin);
        }        
    }
}
