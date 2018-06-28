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
        [Required]
        public string gradeName { get; set; }
        public virtual ICollection<Student> StudentsList { get; set; }
        public virtual ICollection<SchoolSubject> SchoolSubjectsList { get; set; }
        public Manager Manager { get; set; }
    }
}