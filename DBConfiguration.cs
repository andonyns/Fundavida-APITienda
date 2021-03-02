using APITienda.Models;
using Microsoft.EntityFrameworkCore;

namespace APITienda
{
    public class TiendasContext : DbContext
    {
        public DbSet<Tienda> Tiendas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=tiendas.db");
    }
}