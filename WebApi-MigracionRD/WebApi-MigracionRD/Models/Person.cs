using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_MigracionRD.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        [Required]
        public string Passport { get; set; }
        public string Address { get; set; }
        public bool Gender { get; set; }

        public List<Request> Requests { get; set; }
    }
}
