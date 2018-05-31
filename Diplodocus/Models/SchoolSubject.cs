namespace Diplodocus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class SchoolSubject
    {
        [Key]
        public int IdSubject { get; set; }
        [Required]
        public string subjectName { get; set; }
        public int GradeIdGrade { get; set; }
        public virtual ICollection<StudentMarkSubject> aStudentMarkSubjects { get; set; }
        public virtual Grade aGrade { get; set; }
    }
}