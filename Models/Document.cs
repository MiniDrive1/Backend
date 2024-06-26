using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Models{
    public class Document{

        /* ------------ */
        public int Id {get; set;}

        /* ------------ */
        public int UserId {get; set;}
        public User? User {get; set;}

        /* ------------- */
        public int ParentFolderId{get; set;}

        /* -------------- */
        [Required(ErrorMessage = "The Name of the folder is required.")]
        [MinLength(1, ErrorMessage = "Name must be at least {1} characters.")]
        [MaxLength(50, ErrorMessage = "Name must be at most {1} characters.")]
        public string Name {get; set;}

        /* -------------- */
        [Required(ErrorMessage = "The Data of the folder is required.")]
        [DataType(DataType.Text)]
        public string Data {get; set;}

        /* ---------------- */
        [Required(ErrorMessage = "The date of creation is required.")]
        [DataType(DataType.Date)]
        public DateOnly CreationDate {get; set;}

        /* -------------- */
        public int FolderId {get;set;}
        
        /* ------------------ */
        [Required(ErrorMessage = "status is required.")]
        public string Status {get; set;}

        /* ---------------- */
        [JsonIgnore]
        public List<Trash>? Trash{ get; set; }
    }
}