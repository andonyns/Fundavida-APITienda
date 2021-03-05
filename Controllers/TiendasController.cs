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
        //Quitar esto cuando nadie lo llame
        private List<Tienda> tiendas = new List<Tienda>() {
            new Tienda(1, "Tienda Nunez", "San Jose")
        };
        private TiendasRepository tiendasRepository;

        public TiendasController()
        {
            tiendasRepository = new TiendasRepository();
        }

        [HttpGet]
        public List<Tienda> GetTiendas()
        {
            var tiendas = tiendasRepository.ObtenerTiendas();
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
            var resultado = tiendasRepository.AgregarTienda(nuevaTienda);
            return "Tienda Agregada con Id: " + resultado;
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