using System.Collections.Generic;
using APITienda.Models;
using Microsoft.AspNetCore.Mvc;

namespace APITienda.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TiendasController : ControllerBase
    {
        private List<Tienda> tiendas = new List<Tienda>() {
            new Tienda(1, "Tienda Nunez", "San Jose")
        };

        [HttpGet]
        public List<Tienda> GetTiendas()
        {
            return tiendas;
        }

        [HttpGet]
        [Route("{id}")]
        public Tienda GetTienda([FromRoute] int id)
        {
            return tiendas.Find(t => t.Id == id);
        }

        [HttpPost]
        public string AgregarTienda([FromBody] Tienda nuevaTienda)
        {
            tiendas.Add(nuevaTienda);
            return "Tienda Agregada! Nombre: " + nuevaTienda.Nombre;
        }

        [HttpPut]
        public string ActualizarTienda([FromBody] Tienda nuevaTienda)
        {
            var tiendaVieja = tiendas.Find(t => t.Id == nuevaTienda.Id);
            tiendas.Remove(tiendaVieja);
            tiendas.Add(nuevaTienda);
            return "Tienda Editada! Nombre: " + nuevaTienda.Nombre;
        }

        [HttpDelete]
        public string BorrarTienda([FromQuery] int id)
        {
            var tiendaVieja = tiendas.Find(t => t.Id == id);
            tiendas.Remove(tiendaVieja);
            return "Tienda Borrada! Id: " + id;
        }


    }

}