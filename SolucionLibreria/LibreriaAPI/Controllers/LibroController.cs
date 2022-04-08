using LibreriaEntities.DTO;
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
    public class LibroController : ControllerBase
    {

        private ILibroLogica logica;

        public LibroController(ILibroLogica librologica) {
            logica = librologica;
        }
        // GET: api/<LibroController>
        [HttpGet]
        public IEnumerable<Libro> Listar()
        {
            return logica.ListarLibros();
        }

        // GET api/<LibroController>/5
        [HttpGet]
        public IEnumerable<Libro> Busqueda([FromQuery]BusquedaDto busqueda)
        {
            return logica.Busqueda(busqueda);
        }
        
        [HttpGet("{id}")]
        public Libro Detalle(int id)
        {
            return logica.Detalle(id);
        }

    }
}
