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
        public long SubjectMarkFloor { get; set; }
        public int Semester { get; set; }
        public bool Rattrapable { get; set; }
        public int GradeIdGrade { get; set; }

        public virtual ICollection<SchoolSubjectMark> SchoolSubjectMark { get; set; }
        public virtual Grade Grade { get; set; }
    }
}