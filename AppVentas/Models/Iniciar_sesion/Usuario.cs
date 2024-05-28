using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppVentas.Models.Iniciar_sesion
{
    public class Usuarios
    {
        public int UsuarioId { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public int RolId { get; set; }
        public virtual Rol Rol { get; set; }
    }
}