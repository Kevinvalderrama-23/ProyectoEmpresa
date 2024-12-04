using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoEmpresa.Controllers
{

    
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Información importante de la empresa.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Contactanos";

            return View();
        }
    }
}