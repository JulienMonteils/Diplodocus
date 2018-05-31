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
    public class SchoolSubjectMarksController : Controller
    {
        private MyContext db = new MyContext();

        // GET: SchoolSubjectMarks
        public async Task<ActionResult> Index()
        {
            return View(await db.SchoolSubjectMarks.ToListAsync());
        }

        // GET: SchoolSubjectMarks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolSubjectMark schoolSubjectMark = await db.SchoolSubjectMarks.FindAsync(id);
            if (schoolSubjectMark == null)
            {
                return HttpNotFound();
            }
            return View(schoolSubjectMark);
        }

        // GET: SchoolSubjectMarks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolSubjectMarks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdMark,mark")] SchoolSubjectMark schoolSubjectMark)
        {
            if (ModelState.IsValid)
            {
                db.SchoolSubjectMarks.Add(schoolSubjectMark);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(schoolSubjectMark);
        }

        // GET: SchoolSubjectMarks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolSubjectMark schoolSubjectMark = await db.SchoolSubjectMarks.FindAsync(id);
            if (schoolSubjectMark == null)
            {
                return HttpNotFound();
            }
            return View(schoolSubjectMark);
        }

        // POST: SchoolSubjectMarks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdMark,mark")] SchoolSubjectMark schoolSubjectMark)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schoolSubjectMark).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(schoolSubjectMark);
        }

        // GET: SchoolSubjectMarks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolSubjectMark schoolSubjectMark = await db.SchoolSubjectMarks.FindAsync(id);
            if (schoolSubjectMark == null)
            {
                return HttpNotFound();
            }
            return View(schoolSubjectMark);
        }

        // POST: SchoolSubjectMarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SchoolSubjectMark schoolSubjectMark = await db.SchoolSubjectMarks.FindAsync(id);
            db.SchoolSubjectMarks.Remove(schoolSubjectMark);
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
