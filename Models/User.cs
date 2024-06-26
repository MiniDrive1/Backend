using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Models{
    public class User{

        /* _--------- */
        public int Id {get; set;}

        /* ------------- */
        [Required(ErrorMessage = "The name is required")]
        [MinLength(2, ErrorMessage = "Name must be at least {1} characters.")]
        [MaxLength(80, ErrorMessage = "Name must be at most {1} characters.")]
        public string Name {get; set;}

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

        /* ---------------- */
        [JsonIgnore]
        public List<Folder>? Folder { get; set; }

        /* -------------- */
        [JsonIgnore]
        public List<Document>? Document { get; set; }
        
    }
        
}
