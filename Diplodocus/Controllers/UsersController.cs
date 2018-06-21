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
using System.Text.RegularExpressions;

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

        // GET: Inscription
        public ActionResult Inscription()
        {
            ViewBag.GradeIdGrade = new SelectList(db.Grades, "IdGrade", "gradeName");
            return View();
        }

        // GET: Contact
        public ActionResult Contact()
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
                        var userDetailsTeacher = db.Teachers.Where(x => x.Address == userModel.Email && x.Password == userModel.Password).FirstOrDefault();
                        if (userDetailsTeacher == null)
                        {
                            userModel.LoginErrorMessage = "Mauvais login ou mot de passe";
                            return View("Login", userModel);
                        }
                        else
                        {
                            // METTRE LES INFOS DU TEACHER
                            Session["TeacherId"] = userDetailsTeacher.IdUser;
                            Session["UserId"] = userDetailsTeacher.IdUser;
                            Session["TeacherFirstName"] = userDetailsTeacher.FirstName;
                            Session["TeacherLastName"] = userDetailsTeacher.LastName;
                            Session["TeacherPhoneNumber"] = userDetailsTeacher.PhoneNumber;
                            Session["TeacherAddressEmail"] = userDetailsTeacher.Address;
                            Session["TeacherPassword"] = userDetailsTeacher.Password;
                            Session["UserType"] = userDetailsTeacher.GetType();

                            return RedirectToAction("TeacherStart", "Start");
                        }

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
                    Session["GradeId"] = userDetailsStudent.GradeIdGrade;

                    return RedirectToAction("StudentStart", "Start");
                }

            }
        }

        [HttpPost]
        public ActionResult AddStudent(Diplodocus.ViewModels.User userModel)
        {
            using (MyContext db = new MyContext())
            {
                // CHECK EXIST
                if (db.Students.Any(x => x.AddressMail == userModel.Email) || db.Teachers.Any(x => x.Address == userModel.Email) || db.Managers.Any(x => x.Address == userModel.Email))
                {
                    ViewBag.LoginErrorMessage = "problème email already use";
                    return RedirectToAction("Inscription", "Users");
                }
                // CHEK EMAIL
                if (!IsValidEmail(userModel.Email))
                {
                    ViewBag.LoginErrorMessage = "problème email invalid";
                    return RedirectToAction("Inscription", "Users");
                }
                // CHECK PASSWORD
                if (userModel.Password != userModel.ConfirmPassword)
                {
                    ViewBag.LoginErrorMessage = "problème mdp";
                    return RedirectToAction("Inscription", "Users");
                }
                // CHECK FORM COMPLETE
                if (userModel.Password == null || userModel.FirstName == null || userModel.LastName == null || userModel.Email == null || userModel.PhoneNumber == null)
                {
                    ViewBag.LoginErrorMessage = "problème champs";
                    return RedirectToAction("Inscription", "Users");
                }
                //CHECK PHONENUMBER
                /*if (!IsPhoneNumber(userModel.PhoneNumber))
                {
                    ViewBag.LoginErrorMessage = "problème email invalid";
                    return RedirectToAction("Inscription", "Users", userModel);
                }*/
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
                ViewBag.GradeIdGrade = new SelectList(db.Grades, "IdGrade", "gradeName", student.GradeIdGrade);
                return RedirectToAction("Login", "Users");
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
                Email = userModel.Email
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
            ViewBag.GradeIdGrade = new SelectList(db.Grades, "IdGrade", "gradeName", student.GradeIdGrade);
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

        public async Task<ActionResult> GestionTeacher(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = await db.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditStudent([Bind(Include = "IdUser,FirstName,LastName,AddressMail,PhoneNumber,Password,GradeIdGrade")] Student student)
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
                ViewBag.GradeIdGrade = new SelectList(db.Grades, "IdGrade", "gradeName", student.GradeIdGrade);
                Session["GradeId"] = student.GradeIdGrade;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditTeacher([Bind(Include = "IdUser,FirstName,LastName,Address,PhoneNumber,Password")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher).State = EntityState.Modified;
                await db.SaveChangesAsync();
                Session["TeacherId"] = teacher.IdUser;
                Session["UserId"] = teacher.IdUser;
                Session["TeacherFirstName"] = teacher.FirstName;
                Session["TeacherLastName"] = teacher.LastName;
                Session["TeacherPhoneNumber"] = teacher.PhoneNumber;
                Session["TeacherAddressEmail"] = teacher.Address;
                Session["TeacherPassword"] = teacher.Password;
                return RedirectToAction("TeacherStart", "Start");
            }
            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewGrade([Bind(Include = "IdUser,FirstName,LastName,AddressMail,PhoneNumber,Password,GradeIdGrade")] int idGrade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(new Student
                {
                    AddressMail = Session["StudentAddressEmail"].ToString(),
                    FirstName = Session["StudentFirstName"].ToString(),
                    LastName = Session["StudentLastName"].ToString(),
                    PhoneNumber = Session["StudentPhoneNumber"].ToString(),
                    Password = Session["StudentPassword"].ToString(),
                    GradeIdGrade = idGrade
                }

                ).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Login", "Users");
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPassword([Bind(Include = "IdUser,FirstName,LastName,AddressMail,PhoneNumber,Password,GradeIdGrade")]Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(new Student
                {
                    Password = student.Password
                }

                ).State = EntityState.Modified;
                // MDP CHANGER
                await db.SaveChangesAsync();
                return RedirectToAction("Login", "Users");
            }
            else
            {
                // MDP NON CHANGER
                return RedirectToAction("Login", "Users");
            }
        }

        public ActionResult Logout()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Users");
            }
            int userId = (int)Session["UserId"];
            Session.Abandon();
            return RedirectToAction("Login", "Users");
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^(\+[0-9]{9})$").Success;
        }

    }
}
