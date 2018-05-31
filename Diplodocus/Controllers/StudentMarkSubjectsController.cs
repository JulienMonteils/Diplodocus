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
    public class StudentMarkSubjectsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: StudentMarkSubjects
        public async Task<ActionResult> Index()
        {
            var studentMarkSubjects = db.StudentMarkSubjects.Include(s => s.aSchoolSubjectMark);
            return View(await studentMarkSubjects.ToListAsync());
        }

        // GET: StudentMarkSubjects/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentMarkSubject studentMarkSubject = await db.StudentMarkSubjects.FindAsync(id);
            if (studentMarkSubject == null)
            {
                return HttpNotFound();
            }
            return View(studentMarkSubject);
        }

        // GET: StudentMarkSubjects/Create
        public ActionResult Create()
        {
            ViewBag.SchoolSubjectMarkIdMark = new SelectList(db.SchoolSubjectMarks, "IdMark", "IdMark");
            return View();
        }

        // POST: StudentMarkSubjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdStudentMarkSubject,Student_idUser,SchoolSubject_idSubject,SchoolSubjectMarkIdMark")] StudentMarkSubject studentMarkSubject)
        {
            if (ModelState.IsValid)
            {
                db.StudentMarkSubjects.Add(studentMarkSubject);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SchoolSubjectMarkIdMark = new SelectList(db.SchoolSubjectMarks, "IdMark", "IdMark", studentMarkSubject.SchoolSubjectMarkIdMark);
            return View(studentMarkSubject);
        }

        // GET: StudentMarkSubjects/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentMarkSubject studentMarkSubject = await db.StudentMarkSubjects.FindAsync(id);
            if (studentMarkSubject == null)
            {
                return HttpNotFound();
            }
            ViewBag.SchoolSubjectMarkIdMark = new SelectList(db.SchoolSubjectMarks, "IdMark", "IdMark", studentMarkSubject.SchoolSubjectMarkIdMark);
            return View(studentMarkSubject);
        }

        // POST: StudentMarkSubjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdStudentMarkSubject,Student_idUser,SchoolSubject_idSubject,SchoolSubjectMarkIdMark")] StudentMarkSubject studentMarkSubject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentMarkSubject).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SchoolSubjectMarkIdMark = new SelectList(db.SchoolSubjectMarks, "IdMark", "IdMark", studentMarkSubject.SchoolSubjectMarkIdMark);
            return View(studentMarkSubject);
        }

        // GET: StudentMarkSubjects/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentMarkSubject studentMarkSubject = await db.StudentMarkSubjects.FindAsync(id);
            if (studentMarkSubject == null)
            {
                return HttpNotFound();
            }
            return View(studentMarkSubject);
        }

        // POST: StudentMarkSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StudentMarkSubject studentMarkSubject = await db.StudentMarkSubjects.FindAsync(id);
            db.StudentMarkSubjects.Remove(studentMarkSubject);
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
