using CatolicoCantorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CatolicoCantorAPI.Data
{
    public class AppDbContext : DbContext

    {

        public DbSet<Music> Musics { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
