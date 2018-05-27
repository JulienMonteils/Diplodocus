using Diplodocus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplodocus.Controllers
{
    public class MatiereController : Controller
    {
        // GET: Matiere
        public ActionResult Index()
        {
           

            var Anglais = new Matiere
            {
                IdMatiere = 1,
                LibelleMatiere = "Anglais",
                NotePalier = 7
            };
            var Math = new Matiere
            {
                IdMatiere = 2,
                LibelleMatiere = "Math",
                NotePalier = 7
            };
            var Histoire = new Matiere
            {
                IdMatiere = 3,
                LibelleMatiere = "Histoire",
                NotePalier = 7
            };
            var Projet = new Matiere
            {
                IdMatiere = 4,
                LibelleMatiere = "Projet informatique",
                NotePalier = 10
            };

            var mesMatiere = new List<Matiere>();
            mesMatiere.Add(Anglais);
            mesMatiere.Add(Math);
            mesMatiere.Add(Histoire);
            

            var L3 = new Filiere
            {

            };
            return View(mesMatiere);
        }
    }
}