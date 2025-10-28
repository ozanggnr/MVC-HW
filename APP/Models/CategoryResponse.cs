using CORE.APP.Models;

namespace APP.Models
{
    public class CategoryResponse : Response
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public string NameF => Name;
    }
}


