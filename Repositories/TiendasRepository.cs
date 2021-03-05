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

        public Tienda ObtenerTienda(int id)
        {
            var resultado = db.Tiendas.Find(id);
            db.SaveChanges();
            return resultado;
        }

        public Tienda ActualizarTienda(Tienda nuevaTienda)
        {
            var tiendaActual = db.Tiendas.Find(nuevaTienda.Id);
            db.Tiendas.Remove(tiendaActual);
            db.Tiendas.Add(nuevaTienda);
            db.SaveChanges();
            return nuevaTienda;
        }

        public Tienda BorrarTienda(int id)
        {
            var tiendaActual = db.Tiendas.Find(id);
            var resultado = db.Tiendas.Remove(tiendaActual);
            db.SaveChanges();
            return resultado.Entity;

        }

    }

}