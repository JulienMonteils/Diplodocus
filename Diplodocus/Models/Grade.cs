namespace Diplodocus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class Grade
    {
        [Key]
        public int IdGrade { get; set; }
        public string gradeName { get; set; }
        public virtual ICollection<Student> studentsList { get; set; }
        public virtual ICollection<SchoolSubject> schoolSubjectsList { get; set; }
    }
}