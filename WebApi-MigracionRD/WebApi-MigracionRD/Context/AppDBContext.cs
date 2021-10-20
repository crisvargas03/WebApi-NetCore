using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_MigracionRD.Models;

namespace WebApi_MigracionRD.Context
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            :base(options)
        {

        }

        public DbSet<Person> Personas { get; set; }
        public DbSet<Request> Solicitudes { get; set; }
        public DbSet<Status> Estados { get; set; }
    }
}
