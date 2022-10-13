using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidosController : ControllerBase
    {
        public IRepositorioPartidos RepoPartidos { get; set; }

        public PartidosController(IRepositorioPartidos repoPartidos)
        {
            RepoPartidos = repoPartidos;
        }
        // GET: api/<PartidosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PartidosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                Partido buscado = RepoPartidos.FindById(id);
                if (buscado == null) return NotFound();
                return Ok(buscado);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // POST api/<PartidosController>
        [HttpPost]
        public IActionResult Post([FromBody] Partido partido)
        {
            try
            {
                if (partido == null) return BadRequest("Body vacío");
                Estado estadoPartido = new Estado();
                estadoPartido.EstadoPartido = "PENDIENTE";
                partido.Estado = estadoPartido;
                RepoPartidos.Add(partido);
                return Created("api/partidos/" + partido.Id, partido);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("ERROR PARTIDO") || ex.Message.Contains("ERROR HORARIO")) return BadRequest(ex.Message);
                return StatusCode(500);
            }
        }

        // PUT api/<PartidosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PartidosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
