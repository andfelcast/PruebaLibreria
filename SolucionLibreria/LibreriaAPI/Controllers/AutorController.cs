using LibreriaEntities.Entities;
using LibreriaLogica.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
    public class AutorController : ControllerBase
    {
        private IAutorLogica logica;

        public AutorController(IAutorLogica autorLogica) {
            logica = autorLogica;
        }

        // GET: api/<AutorController>
        [HttpGet]
        public IEnumerable<Autor> Listar()
        {
            return logica.ListarAutores();
        }
        
        [HttpGet("{id}")]
        public Autor Detalle(int id)
        {
            return logica.Detalle(id);
        }

        [HttpGet]
        public List<Autor> Buscar([FromQuery] string termino)
        {
            return logica.Busqueda(termino);
        }
    }
}
