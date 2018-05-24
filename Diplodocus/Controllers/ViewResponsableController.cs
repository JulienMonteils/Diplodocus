using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplodocus.Controllers
{
    public class ViewResponsableController : Controller
    {
        // GET: ViewResponsable
        public ActionResult ViewAccueilResponsable()
        {
            return View();
        }

        public ActionResult ViewGestionFiliere()
        {
            return View();
        }

        public ActionResult ViewGestionMatière()
        {
            return View();
        }

        public ActionResult ViewGestionEnseignant()
        {
            return View();
        }

        public ActionResult ViewGestionEtudiant()
        {
            return View();
        }


    }
}