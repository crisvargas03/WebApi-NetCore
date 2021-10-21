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
    public class StatusController : Controller
    {
        private readonly AppDBContext context;
        public StatusController(AppDBContext context)
        {
            this.context = context;
        }

        [HttpGet (Name = "Status")]
        public ActionResult<IEnumerable<Status>> Get()
        {
            return context.Estados.ToList();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Status status)
        {
            context.Estados.Add(status);
            context.SaveChanges();
            return new CreatedAtRouteResult("Status", new { id = status.Id }, status);
        }

    }
}
