using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppVentas.Models
{
    public class Carrito
    {
        public int CarritoId { get; set; }
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public int Cantidad { get; set; }
    }
}