using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_MigracionRD.Models
{
    public class Status
    {
        [Required]
        public int Id { get; set; }
        public string StatusName { get; set; }

        public List<Request> Requests { get; set; }
    }
}
