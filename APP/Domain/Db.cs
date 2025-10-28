using Microsoft.EntityFrameworkCore;

namespace APP.Domain
{
    public class Db : DbContext
    {
        public DbSet<Footballer> Footballers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<FootballerClub> FootballerClubs { get; set; }

        public Db(DbContextOptions options) : base(options)
        {
        }
    }
}
