using ArmazemDoMago.Models;
using Microsoft.EntityFrameworkCore;

namespace ArmazemDoMago.Data
{
    public class ArmazemDoMagoDbContext : DbContext
    {
        public ArmazemDoMagoDbContext(DbContextOptions<ArmazemDoMagoDbContext> options)
        : base(options)
        { 
        }

        public DbSet<UsuarioModel> Usuarios => Set<UsuarioModel>();
        public DbSet<ArmazemModel> Armazem => Set<ArmazemModel>();
    }
}
