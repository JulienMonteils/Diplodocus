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
        public string SubjectName { get; set; }
        [Required]
        public long SubjectMarkFloor { get; set; }
        [Required]
        public int Semester { get; set; }
        [Required]
        public bool Rattrapable { get; set; }
        [Required]
        public int GradeIdGrade { get; set; }
        [Required]
        public int Coef { get; set; }
        public virtual ICollection<SchoolSubjectMark> SchoolSubjectMark { get; set; }
        public virtual Grade Grade { get; set; }
    }
}