using ChallengeBackEnd5.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeBackEnd5.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Video> videos { get; set; }

        public DbSet<Categoria> categorias { get; set; }

    }
}
