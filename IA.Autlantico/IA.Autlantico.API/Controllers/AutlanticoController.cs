using IA.Autlantico.Entity;
using IA.Autlantico.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IA.Autlantico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutlanticoController : ControllerBase
    {
        // GET: api/<AutlanticoController>
        [EnableCors("MyPolicy")]
        [HttpGet]
        public IEnumerable<Animal> GetAnimals()
        {
            AutlanticoService autlanticoService = new AutlanticoService();

            var getAll = autlanticoService.GetAnimals();

            return getAll;
        }

        // GET api/<AutlanticoController>/5
        [EnableCors("MyPolicy")]
        [HttpGet("{name}")]
        public IEnumerable<Animal> Get(string name)
        {
            AutlanticoService autlanticoService = new AutlanticoService();

            var getAnimal = autlanticoService.GetAnimalBySearch(name);

            return getAnimal;
        }

        // POST api/<AutlanticoController>
        [EnableCors("MyPolicy")]
        [HttpPost]
        public int Post([FromBody] Animal animal)
        {
            AutlanticoService autlanticoService = new AutlanticoService();

            var hostingId = autlanticoService.SaveAnimal(animal);

            return hostingId;
        }

        // PUT api/<AutlanticoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AutlanticoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
