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
    public class RequestController : Controller
    {
        private readonly AppDBContext context;
        public RequestController(AppDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Request>> Get()
        {
            return context.Solicitudes.ToList();
        }

        [HttpGet("{id}", Name = "RequestsById")]
        public ActionResult<Request> Get(int id)
        {
            var request = context.Solicitudes.FirstOrDefault(x => x.Id == id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Request requestEdited)
        {
            if (id != requestEdited.Id)
            {
                return BadRequest();
            }

            context.Entry(requestEdited).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpPatch("{id}")]
        public ActionResult<Request> Patch(int id)
        {
            var requestCanceled = context.Solicitudes.FirstOrDefault(x => x.Id == id);

            if (requestCanceled == null)
            {
                return NotFound();
            }
            requestCanceled.StatusId = 3; /* 3 is the status code of Canceled.*/
            context.Solicitudes.Attach(requestCanceled);
            context.Entry(requestCanceled).Property(x => x.StatusId).IsModified = true;
            context.SaveChanges();
            return requestCanceled;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Request request)
        {
            context.Solicitudes.Add(request);
            context.SaveChanges();
            return new CreatedAtRouteResult("RequestsById", new { id = request.Id }, request);
        }
    }
}
