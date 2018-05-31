namespace Diplodocus.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class StudentMarkSubject 
    {
        [Key]
        public int IdStudentMarkSubject { get; set; }
        public int Student_idUser { get; set; }
        public int SchoolSubject_idSubject { get; set; }
        public int SchoolSubjectMarkIdMark { get; set; }

        public virtual Student unStudent { get; set; }
        public virtual SchoolSubject aSchoolSubject { get; set; }
        public virtual SchoolSubjectMark aSchoolSubjectMark { get; set; }

      
    }

  
}