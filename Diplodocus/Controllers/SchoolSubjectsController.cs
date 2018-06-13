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
    public class SchoolSubjectsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: SchoolSubjects
        public async Task<ActionResult> Index()
        {
            var schoolSubjects = db.SchoolSubjects.Include(s => s.Grade);
            return View(await schoolSubjects.ToListAsync());
        }

        // GET: SchoolSubjects/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolSubject schoolSubject = await db.SchoolSubjects.FindAsync(id);
            if (schoolSubject == null)
            {
                return HttpNotFound();
            }
            return View(schoolSubject);
        }

        // GET: SchoolSubjects/Create
        public ActionResult Create()
        {
            ViewBag.GradeIdGrade = new SelectList(db.Grades, "IdGrade", "gradeName");
            return View();
        }

        // POST: SchoolSubjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdSubject,SubjectName,SubjectMarkFloor,Semester,Rattrapable,GradeIdGrade,Coef")] SchoolSubject schoolSubject)
        {
            if (ModelState.IsValid)
            {
                db.SchoolSubjects.Add(schoolSubject);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.GradeIdGrade = new SelectList(db.Grades, "IdGrade", "gradeName", schoolSubject.GradeIdGrade);
            return View(schoolSubject);
        }

        // GET: SchoolSubjects/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolSubject schoolSubject = await db.SchoolSubjects.FindAsync(id);
            if (schoolSubject == null)
            {
                return HttpNotFound();
            }
            ViewBag.GradeIdGrade = new SelectList(db.Grades, "IdGrade", "gradeName", schoolSubject.GradeIdGrade);
            return View(schoolSubject);
        }

        // POST: SchoolSubjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdSubject,SubjectName,SubjectMarkFloor,Semester,Rattrapable,GradeIdGrade,Coef")] SchoolSubject schoolSubject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schoolSubject).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GradeIdGrade = new SelectList(db.Grades, "IdGrade", "gradeName", schoolSubject.GradeIdGrade);
            return View(schoolSubject);
        }

        // GET: SchoolSubjects/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolSubject schoolSubject = await db.SchoolSubjects.FindAsync(id);
            if (schoolSubject == null)
            {
                return HttpNotFound();
            }
            return View(schoolSubject);
        }

        // POST: SchoolSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SchoolSubject schoolSubject = await db.SchoolSubjects.FindAsync(id);
            db.SchoolSubjects.Remove(schoolSubject);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public ActionResult ReturnToGrades()
        {


            return RedirectToAction("Index", "Grades");
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
