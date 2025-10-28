using CORE.APP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Models
{
    public class FootballerResponse : Response
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public int ShirtNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string National { get; set; }
        public string? Foot { get; set; }
        public bool IsInjured { get; set; }


        [DisplayName("Footballer")]
        public string FullName { get; set; } 

        [DisplayName("Birth Date")]
        public string BirthDateF { get; set; }

        [DisplayName("Shirt Number")]
        public int ShirtNumberF { get; set; }


        [DisplayName("Injury")]
        public bool IsInjuredF { get; set; }
    }
}
