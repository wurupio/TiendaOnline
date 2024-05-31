using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AppVentas.Models.Productos;
using AppVentas.Models;
using Microsoft.AspNetCore.Mvc;
using AppVentas.DAL;

namespace AppVentas.Controllers
{
    public class TiendaController : Controller
    {
        private readonly DataAccessLayer _dataAccessLayer = new DataAccessLayer();

        public async Task<ActionResult> Index()
        {
            var productos = await _dataAccessLayer.MostrarProductosAsync();
            return View(productos);
        }

        [HttpPost]
        public async Task<ActionResult> Buscar(string nombre, string categoria)
        {
            var productos = await _dataAccessLayer.BuscarProductosAsync(nombre, categoria);
            return View("Index", productos);
        }

        [HttpPost]
        public async Task<ActionResult> AgregarAlCarrito(int clienteId, int productoId, int cantidad)
        {
            await _dataAccessLayer.AgregarAlCarritoAsync(clienteId, productoId, cantidad);
            return RedirectToAction("Carrito", new { clienteId });
        }

        public async Task<ActionResult> Carrito(int clienteId)
        {
            var carrito = await _dataAccessLayer.ObtenerCarritoAsync(clienteId);
            return View(carrito);
        }
    }
}
