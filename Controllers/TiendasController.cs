using System.Collections.Generic;
using APITienda.Models;
using APITienda.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APITienda.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TiendasController : ControllerBase
    {
        private TiendaRepository tiendaRepository;
        private List<Tienda> tiendas = new List<Tienda>() {
            new Tienda(1, "Tienda Nunez", "San Jose")
        };

        public TiendasController()
        {
            tiendaRepository = new TiendaRepository();
        }

        [HttpGet]
        public List<Tienda> GetTiendas()
        {
            var tiendas = tiendaRepository.Obtener();
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
            return tiendaRepository.Agregar(nuevaTienda);
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