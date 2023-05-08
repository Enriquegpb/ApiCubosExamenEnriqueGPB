using ApiCubosExamenEnriqueGPB.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCubosExamenEnriqueGPB.Data
{
    public class CubosContext:DbContext
    {
        public CubosContext(DbContextOptions<CubosContext> options) : base(options) { }

        public DbSet<Cubo> Cubos { get; set; }
        public DbSet<UsuarioCubo> UsuarioCubos { get; set; }
        public DbSet<CompraCubo> CompraCubos { get; set; }

    }
}
