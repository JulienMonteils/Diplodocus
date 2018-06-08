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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressMail { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }

    }



}