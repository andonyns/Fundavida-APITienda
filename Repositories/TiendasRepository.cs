using System.Collections.Generic;
using System.Linq;
using APITienda.Models;

namespace APITienda.Repositories
{
    public class TiendasRepository
    {
        private CadenaDeTiendasContext db;

        public TiendasRepository()
        {
            db = new CadenaDeTiendasContext();
        }

        public List<Tienda> ObtenerTiendas()
        {
            var tiendas = db.Tiendas.ToList();
            db.SaveChanges();
            return tiendas;
        }

        public int AgregarTienda(Tienda nuevaTienda)
        {
            var resultado = db.Tiendas.Add(nuevaTienda);
            db.SaveChanges();
            return resultado.Entity.Id;
        }




    }

}