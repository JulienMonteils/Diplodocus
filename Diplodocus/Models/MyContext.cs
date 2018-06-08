using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Diplodocus.Models
{
    public class MyContext : DbContext
    {

        public MyContext() : base("name=MyContext")
        {
        }

        public System.Data.Entity.DbSet<Diplodocus.Models.Grade> Grades { get; set; }
        public System.Data.Entity.DbSet<Diplodocus.Models.Manager> Managers { get; set; }
        public System.Data.Entity.DbSet<Diplodocus.Models.SchoolSubject> SchoolSubjects { get; set; }
        public System.Data.Entity.DbSet<Diplodocus.Models.SchoolSubjectMark> SchoolSubjectMarks { get; set; }
        public System.Data.Entity.DbSet<Diplodocus.Models.Student> Students { get; set; }
        public System.Data.Entity.DbSet<Diplodocus.Models.Teacher> Teachers { get; set; }
        public System.Data.Entity.DbSet<Diplodocus.Models.User> Users { get; set; }
    }
}
