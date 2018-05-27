using Diplodocus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplodocus.Controllers
{
    public class FiliereController : Controller
    {
        [Route("simuler/{libelle}")]
        // GET: Filiere
        public ActionResult AfficherFiliere(String libelle)
        {

            var Anglais = new Matiere
            {
                IdMatiere = 1,
                LibelleMatiere = "Anglais",
                NotePalier = 7,
                SemestreMatiere = 1
            };
            var Math = new Matiere
            {
                IdMatiere = 2,
                LibelleMatiere = "Math",
                NotePalier = 7,
                SemestreMatiere = 1
            };
            var Histoire = new Matiere
            {
                IdMatiere = 3,
                LibelleMatiere = "Histoire",
                NotePalier = 7,
                SemestreMatiere = 2,
            };
            var Projet = new Matiere
            {
                IdMatiere = 4,
                LibelleMatiere = "Projet informatique",
                NotePalier = 10,
                SemestreMatiere = 2               
            };

            var mesMatiere = new List<Matiere>();
           
            mesMatiere.Add(Anglais);
            mesMatiere.Add(Math);
            mesMatiere.Add(Histoire);
            mesMatiere.Add(Projet);
 

            var filiere = new Filiere
            {
                IdFiliere = 1,
                LibelleFiliere = libelle,
                MesMatieres = mesMatiere, // Requete qui récupère les matières lié à la filière séléctionnée
            };
            return View(model: filiere);
        }

        public ActionResult ResultatAnnee()
        {
            return View();

        }

        [HttpPost]
        public long SimulerResultatAnnee(List<long> NotesPourSimulation)
        {
            long resultat = 0;

            foreach (long note in NotesPourSimulation)
            {
                resultat = resultat + note;
            }
            resultat = resultat / NotesPourSimulation.Count;
            return resultat;
        }

    }
}