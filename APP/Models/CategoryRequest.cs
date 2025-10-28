using CORE.APP.Models;
using System.ComponentModel.DataAnnotations;

namespace APP.Models
{
    public class CategoryRequest : Request
    {
        [Required, StringLength(75)]
        public string Name { get; set; }

        [StringLength(250)]
        public string? Description { get; set; }
    }
}


