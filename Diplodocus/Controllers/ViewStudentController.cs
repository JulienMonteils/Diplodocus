using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplodocus.Controllers
{
    public class ViewStudentController : Controller
    {
        // GET: ViewStudent
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAccueilEtudiant()
        {
            return View();
        }
    }
}