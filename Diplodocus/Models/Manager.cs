using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplodocus.Models
{
    public class Manager : Teacher
    {

        public Manager(string firstName, string lastName, string address, string phoneNumber)
            : base("", "", "", "")
        // appel du constructeur de la classe CompteBancaire
        // le mot-clé "base" permet d'accéder à la classe parente
        {
        }

        protected override string ToString()
        {
            throw new NotImplementedException();
        }

        protected Boolean createFormation(string name)
        {
            Boolean formation = false;
            return formation;
        }

        protected Boolean createSubject(string name)
        {
            Boolean subject = false;
            return subject;
        }

        /*protected List <Formation> getFormation()
        {
            return List <Formation> lesFormations;
        }*/

    }
}