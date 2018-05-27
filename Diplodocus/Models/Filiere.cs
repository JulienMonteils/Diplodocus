using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplodocus.Models
{
    public class Filiere
    {
        public int IdFiliere { get; set; }
        public string LibelleFiliere { get; set; }
        public List<Matiere> MesMatieres {get; set; }

        /*public Filiere(int id, string libelle, string libele, List<Matiere> desMatieres)
        {
            this.IdFiliere = id;
            this.LibelleFiliere = libelle;
            this.MesMatieres = desMatieres;
        }

        public void AjouterMatiere(int id, String libelle) => MesMatieres.Add(new Matiere { IdMatiere = id, LibelleMatiere = libelle });
        public void AjouterMatiere(Matiere uneMatiere)
        {
            if (uneMatiere == null)
            {
                throw new ArgumentNullException(nameof(uneMatiere));
            }

            MesMatieres.Add(uneMatiere);
        }

        public long SimulerResultatAnnee(List<long> NotesPourSimulation)
        {
            long resultat = 0;

            foreach(long note in NotesPourSimulation)
            {
                resultat = resultat + note;
            }
            resultat = resultat / NotesPourSimulation.Count;
            return resultat;
        }

        public String commenterResultat(long note,long notePalier)
        {
            String commentaire = "";
            if(note < notePalier)
            {
                commentaire = "Rattrapage nécéssaire";
            }
            return commentaire;
        }

        public Matiere ChercherMatiereParLibelle(String libelle)
        {
            int i = 0;
            Matiere trouvee = null;
           
            while(i<MesMatieres.Count && !MesMatieres[i].LibelleMatiere.Equals(libelle))
            {
                i++;  
            }
            if (i < MesMatieres.Count)
            {
                trouvee = MesMatieres[i];
            }
            return trouvee;
        }*/
    }
}