using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_MigracionRD.Context;
using WebApi_MigracionRD.Models;

namespace WebApi_MigracionRD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly AppDBContext context;
        public PersonController(AppDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            return context.Personas.ToList();
        }

        [HttpGet ("{id}", Name ="PersonaById")]
        public ActionResult<Person> Get(int id)
        {
            var person = context.Personas.FirstOrDefault(x => x.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Person persona)
        {
            context.Personas.Add(persona);
            context.SaveChanges();
            return new CreatedAtRouteResult("PersonaById", new { id = persona.Id}, persona);
        }

        [HttpPut ("{id}")]
        public ActionResult Put(int id, [FromBody] Person personEdited)
        {
            if (id != personEdited.Id)
            {
                return BadRequest();
            }

            context.Entry(personEdited).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete ("{id}")]
        public ActionResult<Person> Delete(int id)
        {
            var persona = context.Personas.FirstOrDefault(x => x.Id == id);

            if (persona == null)
            {
                return NotFound();
            }
            context.Personas.Remove(persona);
            context.SaveChanges();
            return persona;
        }
    }
}
