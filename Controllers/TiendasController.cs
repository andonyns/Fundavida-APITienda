using System;
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
            var tienda = tiendasRepository.ObtenerTienda(id);
            return tienda;
        }

        [HttpPost]
        public string AgregarTienda([FromBody] Tienda nuevaTienda)
        {
            var resultado = tiendasRepository.AgregarTienda(nuevaTienda);
            return "Tienda Agregada con Id: " + resultado;
        }

        [HttpPut]
        public Tienda ActualizarTienda([FromBody] Tienda nuevaTienda)
        {
            var tienda = tiendasRepository.ActualizarTienda(nuevaTienda);
            return tienda;
        }

        [HttpDelete]
        public string BorrarTienda([FromQuery] int id)
        {
            Tienda tienda;
            try
            {
                tienda = tiendasRepository.BorrarTienda(id);
                return "Tienda Borrada! Nombre: " + tienda.Nombre;
            }
            catch (Exception ex)
            {
                return "No se pudo encontrar la tienda";
            }
        }


    }

}