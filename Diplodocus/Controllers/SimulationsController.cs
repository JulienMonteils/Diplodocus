﻿using Diplodocus.Models;
using Diplodocus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplodocus.Controllers
{
    public class SimulationsController : Controller
    {
        private MyContext db = new MyContext();
        // GET: Simulations
        public ActionResult Index(int id)
        {
            var viewModel = new SimulationFormViewModel
            {
                Student = db.Students.SingleOrDefault(c => c.IdUser == id),
                Grade = db.Grades.SingleOrDefault(c => c.StudentsList.FirstOrDefault(s => s.IdUser == id).IdUser == id),
                SchoolSubjects = db.Grades.SingleOrDefault(c => c.IdGrade == db.Grades.FirstOrDefault(d => d.StudentsList.FirstOrDefault(s => s.IdUser == id).IdUser == id).IdGrade).SchoolSubjectsList.ToList(),
                SchoolSubjectMarks = new List<SchoolSubjectMark>(),
                TestNotes = new Dictionary<SchoolSubject, int>(),
                Notes = new List<int>()

            };

            // Pour chaque matières qu'on a récupéré dans la filière dans laquelle on est :
            foreach (var SchoolSubjects in viewModel.SchoolSubjects)
            {
                //Il faut faire un test sur l'existance d'une liste ou non

                foreach (var schoolSubjectMark in SchoolSubjects.SchoolSubjectMark)
                {
                    if (schoolSubjectMark.Student.IdUser == viewModel.Student.IdUser)
                    {
                        if (!(schoolSubjectMark.Mark == null))
                        {
                            viewModel.SchoolSubjectMarks.Add(schoolSubjectMark);
                            viewModel.TestNotes.Add(SchoolSubjects, schoolSubjectMark.Mark.Value);
                            viewModel.Notes.Add(schoolSubjectMark.Mark.Value);
                        }
                        else
                        {
                            viewModel.SchoolSubjectMarks.Add(new SchoolSubjectMark { Mark = 0, Student = viewModel.Student });
                            viewModel.TestNotes.Add(SchoolSubjects, 0);
                            viewModel.Notes.Add(0);
                        }

                    }
                }

            }

            //Attribution des notes pour chacune des matières de l'élève


            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ResultatSimulation(SimulationFormViewModel viewModel)
        {

            // ---




            // --- 
            var moyenne = viewModel.Notes.Average();
            var matiereS1 = new List<SchoolSubject>();
            var matiereS2 = new List<SchoolSubject>();
            var lesSujets = db.Grades.SingleOrDefault(c => c.IdGrade == viewModel.Grade.IdGrade).SchoolSubjectsList;
            var lesSujetsSynchro = new List<SchoolSubject>();
            foreach (var subject in lesSujets)
            {
                if (subject.Semester == 1)
                {
                    lesSujetsSynchro.Add(subject);
                }
            }
            foreach (var subject in lesSujets)
            {
                if (subject.Semester == 2)
                {
                    lesSujetsSynchro.Add(subject);
                }
            }

            foreach (var subject in lesSujetsSynchro)
            {
                if (subject.Semester == 1)
                {
                    matiereS1.Add(subject);
                }
                else
                {
                    if (subject.Semester == 2)
                    {
                        matiereS2.Add(subject);
                    }
                }
            }

            var lesNotes = new Dictionary<SchoolSubject, int>();
            var i = 0;
            foreach (var subject in lesSujetsSynchro)
            {
                lesNotes.Add(subject, viewModel.Notes[i]);
                i = i + 1;
            }



            var notesMoyenneS1 = new List<int>();
            var notesMoyenneS2 = new List<int>();


            foreach (KeyValuePair<SchoolSubject, int> couple in lesNotes)
            {
                if (couple.Key.Semester == 1)
                {
                    notesMoyenneS1.Add(couple.Value);
                }
                else
                {
                    if (couple.Key.Semester == 2)
                    {
                        notesMoyenneS2.Add(couple.Value);
                    }
                }
            }

            var moyenneS1 = notesMoyenneS1.Average();
            var moyenneS2 = notesMoyenneS2.Average();



            var viewModelResultat = new SimulationResultViewModel
            {
                Student = db.Students.SingleOrDefault(c => c.IdUser == viewModel.Student.IdUser),
                Grade = db.Grades.SingleOrDefault(c => c.IdGrade == viewModel.Grade.IdGrade),
                Moyenne = moyenne,
                MoyenneS1 = moyenneS1,
                MoyenneS2 = moyenneS2,
                LesNotes = lesNotes,
                Subjects = lesSujets,
                matieresRattrapage = new List<SchoolSubject>()
                //RattrapageVM = new RattrapageViewModel(),

            };

            //On tente d'enregistrer les resultat :
            int idtest;
            foreach (KeyValuePair<SchoolSubject, int> couple in lesNotes)
            {
                if (VerifSiNoteExisteDeja(couple.Key, viewModelResultat.Student))
                {
                    idtest = getSchoolSubjectMarkBySubjectId(couple.Key, viewModelResultat.Student);
                    db.SchoolSubjectMarks.SingleOrDefault(c => c.IdMark == idtest).Mark = couple.Value;
                    //db.SchoolSubjects.SingleOrDefault(c => c.IdSubject == couple.Key.IdSubject).SchoolSubjectMarks.Add(new SchoolSubjectMark { Mark = couple.Value, Student = viewModelResultat.Student });
                }
                else
                {
                    db.SchoolSubjects.SingleOrDefault(c => c.IdSubject == couple.Key.IdSubject).SchoolSubjectMark.Add(new SchoolSubjectMark { Mark = couple.Value, Student = viewModelResultat.Student });
                }

            }

            db.SaveChanges();

            //viewModelResultat.RattrapageVM.MatiereRattrapables = new Dictionary<Subject, int>();

            return View(viewModelResultat);
        }

        public ActionResult RetourHome(int id)
        {
            return RedirectToAction("StudentStart", "Start", new { id = id });
        }

        public bool VerifSiNoteExisteDeja(SchoolSubject uneMatiere, Student unStudent)
        {
            bool drap = false;



            foreach (var subjectMark in uneMatiere.SchoolSubjectMark)
            {
                if (subjectMark.Student.Equals(unStudent))
                {
                    drap = true;
                }
            }

            return drap;
        }

        public int getSchoolSubjectMarkBySubjectId(SchoolSubject uneMatiere, Student unStudent)
        {
            int SSMid = 0;
            foreach (var subjectMark in uneMatiere.SchoolSubjectMark)
            {
                if (subjectMark.Student.Equals(unStudent))
                {
                    SSMid = subjectMark.IdMark;
                }
            }

            return SSMid;
        }

        //Rattrapages -----
        public ActionResult IndexRattrapage(int id)
        {
            var viewModel = new SimulationFormViewModel
            {
                Student = db.Students.SingleOrDefault(c => c.IdUser == id),
                Grade = db.Grades.SingleOrDefault(c => c.StudentsList.FirstOrDefault(s => s.IdUser == id).IdUser == id),
                SchoolSubjects = db.Grades.SingleOrDefault(c => c.IdGrade == db.Grades.FirstOrDefault(d => d.StudentsList.FirstOrDefault(s => s.IdUser == id).IdUser == id).IdGrade).SchoolSubjectsList.ToList(),
                SchoolSubjectMarks = new List<SchoolSubjectMark>(),
                TestNotes = new Dictionary<SchoolSubject, int>(),
                Notes = new List<int>(),
                MatieresRattrapage = new List<SchoolSubject>()

            };

            // Pour chaque matières qu'on a récupéré dans la filière dans laquelle on est :
            foreach (var SchoolSubjects in viewModel.SchoolSubjects)
            {
                //Il faut faire un test sur l'existance d'une liste ou non

                foreach (var schoolSubjectMark in SchoolSubjects.SchoolSubjectMark)
                {
                    if (schoolSubjectMark.Student.IdUser == viewModel.Student.IdUser)
                    {
                        if (!(schoolSubjectMark.Mark == null))
                        {
                            viewModel.SchoolSubjectMarks.Add(schoolSubjectMark);
                            viewModel.TestNotes.Add(SchoolSubjects, schoolSubjectMark.Mark.Value);
                            viewModel.Notes.Add(schoolSubjectMark.Mark.Value);
                        }
                        else
                        {
                            viewModel.SchoolSubjectMarks.Add(new SchoolSubjectMark { Mark = 0, Student = viewModel.Student });
                            viewModel.TestNotes.Add(SchoolSubjects, 0);
                            viewModel.Notes.Add(0);
                        }

                    }
                }

            }

            //Attribution des notes pour chacune des matières de l'élève


            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ResultatRattrapage(SimulationFormViewModel viewModel)
        {

            // ---




            // --- 
            var moyenne = viewModel.Notes.Average();
            var matiereS1 = new List<SchoolSubject>();
            var matiereS2 = new List<SchoolSubject>();
            var lesSujets = db.Grades.SingleOrDefault(c => c.IdGrade == viewModel.Grade.IdGrade).SchoolSubjectsList;
            var lesSujetsSynchro = new List<SchoolSubject>();
            foreach (var subject in lesSujets)
            {
                if (subject.Semester == 1)
                {
                    lesSujetsSynchro.Add(subject);
                }
            }
            foreach (var subject in lesSujets)
            {
                if (subject.Semester == 2)
                {
                    lesSujetsSynchro.Add(subject);
                }
            }

            foreach (var subject in lesSujetsSynchro)
            {
                if (subject.Semester == 1)
                {
                    matiereS1.Add(subject);
                }
                else
                {
                    if (subject.Semester == 2)
                    {
                        matiereS2.Add(subject);
                    }
                }
            }

            var lesNotes = new Dictionary<SchoolSubject, int>();
            var i = 0;
            foreach (var subject in lesSujetsSynchro)
            {
                lesNotes.Add(subject, viewModel.Notes[i]);
                i = i + 1;
            }



            var notesMoyenneS1 = new List<int>();
            var notesMoyenneS2 = new List<int>();


            foreach (KeyValuePair<SchoolSubject, int> couple in lesNotes)
            {
                if (couple.Key.Semester == 1)
                {
                    notesMoyenneS1.Add(couple.Value);
                }
                else
                {
                    if (couple.Key.Semester == 2)
                    {
                        notesMoyenneS2.Add(couple.Value);
                    }
                }
            }

            var moyenneS1 = notesMoyenneS1.Average();
            var moyenneS2 = notesMoyenneS2.Average();



            var viewModelResultat = new SimulationResultViewModel
            {
                Student = db.Students.SingleOrDefault(c => c.IdUser == viewModel.Student.IdUser),
                Grade = db.Grades.SingleOrDefault(c => c.IdGrade == viewModel.Grade.IdGrade),
                Moyenne = moyenne,
                MoyenneS1 = moyenneS1,
                MoyenneS2 = moyenneS2,
                LesNotes = lesNotes,
                Subjects = lesSujets,
                matieresRattrapage = new List<SchoolSubject>()
                //RattrapageVM = new RattrapageViewModel(),

            };

            //On tente d'enregistrer les resultat :
            int idtest;
            foreach (KeyValuePair<SchoolSubject, int> couple in lesNotes)
            {
                if (VerifSiNoteExisteDeja(couple.Key, viewModelResultat.Student))
                {
                    idtest = getSchoolSubjectMarkBySubjectId(couple.Key, viewModelResultat.Student);
                    db.SchoolSubjectMarks.SingleOrDefault(c => c.IdMark == idtest).Mark = couple.Value;
                    //db.SchoolSubjects.SingleOrDefault(c => c.IdSubject == couple.Key.IdSubject).SchoolSubjectMarks.Add(new SchoolSubjectMark { Mark = couple.Value, Student = viewModelResultat.Student });
                }
                else
                {
                    db.SchoolSubjects.SingleOrDefault(c => c.IdSubject == couple.Key.IdSubject).SchoolSubjectMark.Add(new SchoolSubjectMark { Mark = couple.Value, Student = viewModelResultat.Student });
                }

            }

            db.SaveChanges();

            //viewModelResultat.RattrapageVM.MatiereRattrapables = new Dictionary<Subject, int>();

            return View(viewModelResultat);
        }

    }
}