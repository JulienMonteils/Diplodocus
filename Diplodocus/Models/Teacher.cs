using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplodocus.Models
{
    public class Teacher : User
    {

        public Teacher(string firstName, string lastName, string address, string phoneNumber)
            : base("", "", "", "")
        // appel du constructeur de la classe CompteBancaire
        // le mot-clé "base" permet d'accéder à la classe parente
        {
        }

        protected override string ToString()
        {
            throw new NotImplementedException();
        }

    }
}