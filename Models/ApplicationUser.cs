using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.Models {
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
        }

    public string City { get; set; }

    }
}