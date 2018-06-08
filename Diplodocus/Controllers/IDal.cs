using Diplodocus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplodocus.Controllers
{
    public class IDal:IDalItf
    {
        private MyContext bdd;


        public IDal()
        {


            bdd = new MyContext();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        List<SchoolSubject> RecupererSubjectsList()
        {
            return bdd.SchoolSubjects.ToList();
        }

        List<SchoolSubject> IDalItf.RecupererSubjectsList()
        {
            return bdd.SchoolSubjects.ToList();
        }
    }
}