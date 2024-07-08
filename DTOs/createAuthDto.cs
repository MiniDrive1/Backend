using System.ComponentModel.DataAnnotations;
using Backend.Data;
using Backend.Models;

namespace Users.DTO{
    public class createAuthDto{
        /* ------------ */
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "invalid email format.")]
        [MinLength(5, ErrorMessage = "Email must be at least {1} characters.")]
        [MaxLength(125, ErrorMessage = "Email must be at most {1} characters.")]
        public string Email {get; set;}

        /* ---------------- */
        [Required(ErrorMessage = "password is required.")]
        [MinLength(3, ErrorMessage = "password must be at least {1} characters.")]
        [MaxLength(50, ErrorMessage = "password must be at most {1} characters.")]
        public string Password {get; set;}
    }
}