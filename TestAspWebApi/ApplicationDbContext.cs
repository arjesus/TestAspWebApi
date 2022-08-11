using Microsoft.EntityFrameworkCore;
using TestAspWebApi.Entities;

namespace TestAspWebApi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<GenreEntity> Genres { get; set; }

        public DbSet<ActorEntity> Actors { get; set; }
    }
}
