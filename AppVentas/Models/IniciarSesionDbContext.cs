using AppVentas.Models.Iniciar_sesion;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace AppVentas.Models
{
    public class IniciarSesionDbContext : DbContext
    {
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}