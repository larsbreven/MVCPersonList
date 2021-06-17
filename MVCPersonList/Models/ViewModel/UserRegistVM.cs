using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPersonList.Models.ViewModel
{
    public class UserRegistVM
    {
        [Required]
        [Display(Name = "User name")]
        [StringLength(30, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string BirthDate { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50, MinimumLength = 3)]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(60, MinimumLength = 3)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}