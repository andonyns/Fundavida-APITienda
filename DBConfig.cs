using System.Collections.Generic;
using APITienda.Models;
using Microsoft.EntityFrameworkCore;

namespace APITienda
{
    public class CadenaDeTiendasContext : DbContext
    {
        public DbSet<Tienda> Tiendas { get; set; }
        //public DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=cadenaDeTiendas.db");
    }

}
