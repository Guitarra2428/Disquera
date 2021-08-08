using Disquera.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Disquera.AccesoDatos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Cancion> Cancions { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Album> Albums { get; set; }


    }
}
