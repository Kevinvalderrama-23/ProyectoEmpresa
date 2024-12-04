using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProyectoEmpresa.Context;
using ProyectoEmpresa.Models;
using ProyectoEmpresa.Utils;

namespace ProyectoEmpresa.Controllers
{
    public class AuthController : Controller
    {

        private ProyectoEmpresaContext db = new ProyectoEmpresaContext();


        // GET: Auth

        public ActionResult Login()
        {
            return View(); //db.Usuario.ToList()
        }


        [HttpPost]

        public ActionResult Login(string usuario, string contraseña)
        {
            //verificamos que los campos no sean nulos.
            //IsNullOrEmpty es un metodo que verifica si una cadena (string) es nulla.
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                ViewBag.Error = "Usuario y contraseña son obligatorios";
                return View();
            }

            //Encriptamos la contraseña
            string EncriptarContraseña = Encriptador.EncriptarContraseña(contraseña);

            //Buscar en la base de datos el usuario y la contraseña(encriptada)

            var UsuarioValido = db.Uss
            .FirstOrDefault(u => u.Usuario == usuario && u.Pass == EncriptarContraseña);

            //Condición para que deje ingresar el usuario si los datos son correctos
            if (UsuarioValido != null)
            {


                return RedirectToAction("Index", "Personas");
            }
            ViewBag.Error = "El usuario o la contraseña son incorrectos.";

            return View();


        }

        //GET: Auth/Registrarse
        public ActionResult Registrarse()
        {

            return View();
        }

        //POST 
        [HttpPost]
        public ActionResult Registrarse(string codigo, string usuario, string contraseña, string confirmarcontraseña, string fechacreacion)
        {
            //codigo de acceso.
            if (codigo != "2305")
            {
                ViewBag.Error = "El codigo es incorrecto";
                return View();
            }


            //Validar que los datos no sean nulos.
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña) || string.IsNullOrEmpty(confirmarcontraseña) || string.IsNullOrEmpty(fechacreacion))
            {
                ViewBag.Error = "Usuario y contraseña son obligatorios";
                return View();
            }
            //Validar si las contraseñan coinciden.
            if (contraseña != confirmarcontraseña)
            {
                ViewBag.Error = "Las contraseñas no coinciden";
                return View();
            }
            //Validar que el usuario no exista en la base de datos
            var validarusuario = db.Uss.FirstOrDefault(u => u.Usuario == usuario);

            if (validarusuario != null)
            {
                ViewBag.Error = "El usuario ya existe";
                return View();
            }

            //Encriptamos la contraseña
            string contraseñaencriptada = Encriptador.EncriptarContraseña(contraseña);

            //crear el nuevo usuario
            Uss nuevousuario = new Uss
            {
                Usuario = usuario,
                Pass = contraseñaencriptada,
                FechaCreacion = fechacreacion


            };
            db.Uss.Add(nuevousuario);
            db.SaveChanges();

            //try
            //{
            //    db.Uss.Add(nuevousuario);
            //    db.SaveChanges();
            //}
            //catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            //{
            //    foreach (var validationErrors in ex.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //            System.Diagnostics.Debug.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
            //        }
            //    }
            //    throw; // Lanza nuevamente la excepción si quieres detener la ejecución
            //}


            //redirección al login con el registro exitoso

            ViewBag.Exito = "Registro exitoso, Inicia Sesión.";
            return RedirectToAction("Login");


        }
    }

}