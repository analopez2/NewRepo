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
    public class GruposController : ControllerBase
    {
        public IRepositorioGrupos RepoGrupos { get; set; }

        public GruposController(IRepositorioGrupos repoGrupos)
        {
            RepoGrupos = repoGrupos;
        }

        // GET: api/<GruposController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Grupo> grupos = RepoGrupos.FindAll();
                if (grupos.Count() == 0) return NotFound();
                return Ok(grupos);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // GET api/<GruposController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                Grupo buscado = RepoGrupos.FindById(id);
                if (buscado == null) return NotFound();
                return Ok(buscado);
            }
            catch 
            {
                return StatusCode(500);
            }
            
        }

        // POST api/<GruposController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GruposController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GruposController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
