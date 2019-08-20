using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.ViewModels {

    public class RegisterViewModel {
        
        [Required]
        [EmailAddress]
        [Remote("IsEmailInUse", "Account")]
        [ValidEmailDomainAttribute(allowedDomain: "pragimtech.com", ErrorMessage = "Email domain must be pragimtech.com")]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password do not match")]
        public string ConfirmPassword { get; set; }

        public string City { get; set; }


    }

}