using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prueba_tecnica.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult VerPais()
        {
            return View();
        }

        public ActionResult PruebaEditar()
        {
            return View();
        }

        public ActionResult CrudPais()
        {
            return View();
        }

        public ActionResult crudCiudad()
        {
            return View();
        }

        public ActionResult crudGiro()
        {
            return View();
        }


        public ActionResult Consultar()
        {
            return View();
        }
    }
}
