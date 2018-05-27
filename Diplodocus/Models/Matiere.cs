using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplodocus.Models
{
    public class Matiere
    {
        public long IdMatiere { get; set; }
        public string LibelleMatiere { get; set; }
        public long NotePalier { get; set; }
        public long SemestreMatiere { get; set; }
        public long NoteMatière { get; set; }

        /*public Matiere(int id, string libelle)
        {
            this.IdMatiere = id;
            this.LibelleMatiere = libelle;
        }

        public String getLibelleMatiere()
        {
            return LibelleMatiere;
        }

        public void SetNoteMatière(long uneNote)
        {
            NoteMatière = uneNote;
        }*/

    }
}