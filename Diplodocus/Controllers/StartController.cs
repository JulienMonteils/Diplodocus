using Diplodocus.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Diplodocus.Controllers
{
    public class StartController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Grades
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ManagerStart()
        {
            return View();

           
        }


        public ActionResult StudentStart()
        {
            return View();

           
        }


        public ActionResult ManageStudentRedirect()
        {


            return RedirectToAction("Index", "Students");
        }


        public ActionResult ManageGradeRedirect()
        {


            return RedirectToAction("Index", "Grades");
        }

        public ActionResult ManageSubjectRedirect()
        {


            return RedirectToAction("Index", "SchoolSubjects");
        }

        public ActionResult ManageManagerRedirect()
        {


            return RedirectToAction("Index", "Managers");
        }

        public ActionResult ManageTeacherRedirect()
        {


            return RedirectToAction("Index", "Teachers");
        }



        public ActionResult AddMarkRedirect()
        {


            return RedirectToAction("Index", "SchoolSubjectMarks");
        }
        

    }
}