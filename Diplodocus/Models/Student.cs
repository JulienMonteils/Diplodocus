namespace Diplodocus.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class Student
    {
        [Key]
        public int IdUser { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string AddressMail { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        public int GradeIdGrade { get; set; }

        public virtual Grade Grade { get; set; }
    }



}