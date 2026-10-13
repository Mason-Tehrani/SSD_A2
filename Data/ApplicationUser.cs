using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SSD_A1.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First Name"), Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name"), Required]
        public string LastName { get; set; }

        public string? City { get; set; }


    }

}
