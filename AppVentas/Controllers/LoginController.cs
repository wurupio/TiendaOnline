using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppVentas.Models;

namespace AppVentas.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Iniciar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Iniciar(string usuario, string contrasena)
        {
            using (var context = new IniciarSesionDbContext())
            {
                var user = context.Usuarios.FirstOrDefault(u => u.Usuario == usuario && u.Contrasena == contrasena);

                if (user != null)
                {
                    // Usuario autenticado, realizar acciones necesarias
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Usuario no encontrado o contraseña incorrecta
                    ViewBag.ErrorMessage = "Usuario o contraseña incorrectos";
                    return View("Login");
                }
            }
        }
    }
}