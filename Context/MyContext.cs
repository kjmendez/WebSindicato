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
    }
}
