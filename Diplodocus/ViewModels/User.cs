using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Diplodocus.Models;

namespace Diplodocus.ViewModels
{
    public partial class User
    {
        public int UserId { get; set; }

        [DisplayName("Email")]

        public string Email { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Champs requis")]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Required(ErrorMessage = "Champs requis")]
        public string ConfirmPassword { get; set; }


        public string FirstName { get; set; }
 
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public int GradeIdGrade { get; set; }
        public String LoginErrorMessage { get; set; }
    }
}
