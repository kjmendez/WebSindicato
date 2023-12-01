using Microsoft.EntityFrameworkCore;
using WebSindicato.Models;

namespace WebSindicato.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) 
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Chofer> Chofer { get; set; }
        public DbSet<Pago> Pago { get; set; }
    }
}
