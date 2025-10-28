#nullable enable
using CORE.APP.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APP.Domain
{
    public class Club : Entity
    {
        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string? Stadium { get; set; }

        public List<FootballerClub> FootballerClubs { get; set; } = new List<FootballerClub>();
    }
}


