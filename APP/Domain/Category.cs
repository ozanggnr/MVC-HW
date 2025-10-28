#nullable enable
using CORE.APP.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APP.Domain
{
    public class Category : Entity
    {
        [Required, StringLength(75)]
        public string Name { get; set; }

        [StringLength(250)]
        public string? Description { get; set; }

        public List<Footballer> Footballers { get; set; } = new List<Footballer>();
    }
}


