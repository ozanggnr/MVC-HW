using CORE.APP.Models;
using System.ComponentModel.DataAnnotations;

namespace APP.Models
{
    public class ClubRequest : Request
    {
        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string? Stadium { get; set; }
    }
}


