using CORE.APP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Models
{
    public class FootballerRequest : Request
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }

        [Range(1,99)]
        public int ShirtNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string National { get; set; }
        public string? Foot { get; set; }
        public bool IsInjured { get; set; }

        public bool IsInjuredF { get; set; }
    }
}
