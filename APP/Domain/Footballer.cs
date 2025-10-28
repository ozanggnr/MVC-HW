#nullable enable
using CORE.APP.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Domain
{
    public class Footballer : Entity
    {
        [Required, StringLength(75)]
        public string Name { get; set; }

        [Required, StringLength(75)]
        public string Surname { get; set; }
        
        
        [Required]
        public string Position { get; set; }

        public int ShirtNumber { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string National { get; set; }

        public string? Foot { get; set; }

        public bool IsInjured { get; set; }
    }
}
