using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Diplodocus.Models;

namespace Diplodocus.Controllers
{
    public class StudentsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Students
        public async Task<ActionResult> Index()
        {

            var students = db.Students.Include(s => s.Grade);

            return View(await db.Students.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.GradeIdGrade = new SelectList(db.Grades, "IdGrade", "gradeName");
            return View();
        }
        public ActionResult ReturnToManagerStart()
        {


            return RedirectToAction("ManagerStart", "Start");
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdUser,FirstName,LastName,AddressMail,PhoneNumber,Password,GradeIdGrade")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.GradeIdGrade = new SelectList(db.Grades, "IdGrade", "gradeName", student.GradeIdGrade);
            return View(student);
        }




        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdUser,FirstName,LastName,AddressMail,PhoneNumber,Password,GradeIdGrade")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student);
        }


        [HttpGet]
        public ActionResult AddStudent(int id = 0)
        {
            User userModel = new User();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult AddStudent(Diplodocus.ViewModels.User userModel)
        {
            using (MyContext db = new MyContext())
            {
                if (db.Students.Any(x => x.AddressMail == userModel.Email))
                {
                    ViewBag.AlreadyExist = "Compte déjà existant avec cet Email";
                    // ADD ICI UN MESSAGE POUR SIGNALER QUE LE COMPTE EXISTE DEJA
                    return RedirectToAction("Inscription", "Users");
                }
                Student student = new Student
                {
                    AddressMail = userModel.Email,
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    PhoneNumber = userModel.PhoneNumber,
                    Password = userModel.Password,
                    GradeIdGrade = userModel.GradeIdGrade
                };
                db.Students.Add(student);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.SuccesMessage = "Inscription réussie";
                return RedirectToAction("Login", "Users");
            }
        }


        // GET: Students/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Student student = await db.Students.FindAsync(id);
            db.Students.Remove(student);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
