using System;
using System.Collections.Generic;
using System.Linq;
using APITienda.Models;

namespace APITienda.Repositories
{
    public class TiendaRepository
    {
        private TiendasContext db;

        public TiendaRepository()
        {
            db = new TiendasContext();
        }
        public List<Tienda> Obtener()
        {
            return db.Tiendas.ToList();
        }

        public string Agregar(Tienda nuevaTienda)
        {
            var resultado = db.Tiendas.Add(nuevaTienda);
            db.SaveChanges();

            return "Agregué nueva tienda: " + resultado.Entity.Id;
        }
    }
}