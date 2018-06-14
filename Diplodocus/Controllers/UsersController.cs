using Diplodocus.ViewModels;
using Diplodocus.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Diplodocus.Controllers
{
    public class UsersController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // GET: Login
        public ActionResult Inscription()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Autherize(Diplodocus.ViewModels.User userModel)
        {
            using (MyContext db = new MyContext())
            {
                var userDetailsStudent = db.Students.Where(x => x.AddressMail == userModel.Email && x.Password == userModel.Password).FirstOrDefault();
                if (userDetailsStudent == null)
                {
                    var userDetailsManager = db.Managers.Where(x => x.Address == userModel.Email && x.Password == userModel.Password).FirstOrDefault();
                    if (userDetailsManager == null)
                    {
                        userModel.LoginErrorMessage = "Mauvais login ou mot de passe";
                        return View("Login", userModel);
                    }
                    else
                    {
                        // METTRE LES INFOS DU MANAGER
                        Session["ManagerId"] = userDetailsManager.IdUser;
                        Session["UserId"] = userDetailsManager.IdUser;
                        Session["ManagerFirstName"] = userDetailsManager.FirstName;
                        Session["ManagerLastName"] = userDetailsManager.LastName;
                        Session["ManagerPhoneNumber"] = userDetailsManager.PhoneNumber;
                        Session["ManagerAddressEmail"] = userDetailsManager.Address;
                        Session["ManagerPassword"] = userDetailsManager.Password;
                        Session["UserType"] = userDetailsManager.GetType();

                        return RedirectToAction("ManagerStart", "Start");
                    }
                }
                else
                {
                    // METTRE INFOS DU STUDENT
                    Session["StudentId"] = userDetailsStudent.IdUser;
                    Session["UserId"] = userDetailsStudent.IdUser;
                    Session["StudentFirstName"] = userDetailsStudent.FirstName;
                    Session["StudentLastName"] = userDetailsStudent.LastName;
                    Session["StudentPhoneNumber"] = userDetailsStudent.PhoneNumber;
                    Session["StudentAddressEmail"] = userDetailsStudent.AddressMail;
                    Session["StudentPassword"] = userDetailsStudent.Password;
                    Session["UserType"] = userDetailsStudent.GetType();

                    return RedirectToAction("StudentStart", "Start");
                }

            }
        }

        [HttpGet]
        public ActionResult Edit(Diplodocus.ViewModels.User userModel)
        {
            var userModelCo = new Diplodocus.ViewModels.User
            {
                PhoneNumber = userModel.PhoneNumber,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
            };
            return View("Gestion", userModelCo);
        }

        public async Task<ActionResult> GestionStudent(int? id)
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

        public async Task<ActionResult> GestionManager(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager manager = await db.Managers.FindAsync(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditStudent([Bind(Include = "IdUser,FirstName,LastName,AddressMail,PhoneNumber,Password")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                await db.SaveChangesAsync();
                Session["StudentId"] = student.IdUser;
                Session["UserId"] = student.IdUser;
                Session["StudentFirstName"] = student.FirstName;
                Session["StudentLastName"] = student.LastName;
                Session["StudentPhoneNumber"] = student.PhoneNumber;
                Session["StudentAddressEmail"] = student.AddressMail;
                Session["StudentPassword"] = student.Password;
                return RedirectToAction("StudentStart", "Start");
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditManager([Bind(Include = "IdUser,FirstName,LastName,Address,PhoneNumber,Password")] Manager manager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manager).State = EntityState.Modified;
                await db.SaveChangesAsync();
                Session["ManagerId"] = manager.IdUser;
                Session["UserId"] = manager.IdUser;
                Session["ManagerFirstName"] = manager.FirstName;
                Session["ManagerLastName"] = manager.LastName;
                Session["ManagerPhoneNumber"] = manager.PhoneNumber;
                Session["ManagerAddressEmail"] = manager.Address;
                Session["ManagerPassword"] = manager.Password;
                return RedirectToAction("ManagerStart", "Start");
            }
            return View(manager);
        }

        public ActionResult Logout()
        {
            int userId = (int)Session["UserId"];
            Session.Abandon();
            return RedirectToAction("Login", "Users");
        }

    }
}
