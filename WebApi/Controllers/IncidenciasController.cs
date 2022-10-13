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
    public class IncidenciasController : ControllerBase
    {
        public IRepositorioIncidencias RepoIncidencias { get; set; }

        public IncidenciasController(IRepositorioIncidencias repoIncidencias)
        {
            RepoIncidencias = repoIncidencias;
        }
        // GET: api/<IncidenciasController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<IncidenciasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<IncidenciasController>
        [HttpPost]
        public IActionResult Post([FromBody] Incidencia incidencia)
        {
            try
            {
                if (incidencia == null) return BadRequest("Body vacío");
                RepoIncidencias.Add(incidencia);
                return Created("api/incidencias/" + incidencia.Id, incidencia);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("ERROR INCIDENCIA")) return BadRequest(ex.Message);
                return StatusCode(500);
            }
        }

        // PUT api/<IncidenciasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IncidenciasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
