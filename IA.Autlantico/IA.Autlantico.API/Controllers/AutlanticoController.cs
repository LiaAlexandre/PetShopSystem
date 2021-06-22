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

        // GET api/<AutlanticoController>/5
        [EnableCors("MyPolicy")]
        [Route("GetAnimal/{id}")]
        [HttpGet]
        public Animal GetAnimal(int id)
        {
            AutlanticoService autlanticoService = new AutlanticoService();

             var getAnimal = autlanticoService.GetAnimalById(id);

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

        [EnableCors("MyPolicy")]
        [Route("GetHostings")]
        [HttpGet]
        public IEnumerable<Hosting> GetHostings()
        {
            AutlanticoService autlanticoService = new AutlanticoService();

            var getHostings = autlanticoService.GetHostingList();

            return getHostings;
        }

        // PUT api/<AutlanticoController>/5
        [EnableCors("MyPolicy")]
        [HttpPut]
        public void Put([FromBody] Animal animal)
        {
            AutlanticoService autlanticoService = new AutlanticoService();

            autlanticoService.UpdateAnimal(animal);
        }

        // DELETE api/<AutlanticoController>/5
        [EnableCors("MyPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            AutlanticoService autlanticoService = new AutlanticoService();

            autlanticoService.DeleteAnimal(id);
        }
    }
}
