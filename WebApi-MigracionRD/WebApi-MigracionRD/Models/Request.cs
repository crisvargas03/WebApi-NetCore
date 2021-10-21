using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_MigracionRD.Models
{
    public class Request
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int PersonId { get; set; }
        [Required]
        public int StatusId { get; set; }
        public DateTime CreationDate { get; set; }

        public Person Person { get; set; }
        public Status Status { get; set; }

    }
}
