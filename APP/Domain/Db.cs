using Microsoft.EntityFrameworkCore;

namespace APP.Domain
{
    public class Db : DbContext
    {
        public DbSet<Footballer> Footballers { get; set; }

        public Db(DbContextOptions options) : base(options)
        {
        }
    }
}
