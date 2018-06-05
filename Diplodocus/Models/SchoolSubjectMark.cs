namespace Diplodocus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class SchoolSubjectMark
    {

        [Key]
        public int IdMark { get; set; }
        public Nullable<int> Mark { get; set; }
        public Nullable<int> MarkPalier { get; set; }
        public virtual ICollection<StudentMarkSubject> AStudentMarkSubjects { get; set; }
    }

}