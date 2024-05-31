using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppVentas.Models.Productos
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public string Talla { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
    }

}