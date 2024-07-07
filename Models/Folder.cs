using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Models{
    public class Folder{

        /* --------------- */
        public int Id {get; set;}

        /* ---------------------- */
        public int UserId {get; set;}
        public User? User {get; set;}

        /* --------------- */
        public int? ParentFolderId { get; set; }
        public Folder? ParentFolder { get; set; } // Esto es importante para la navegación de EF Core
        public ICollection<Folder>? SubFolders { get; set; } // Relación inversa


        /* ---------------- */
        [Required(ErrorMessage = "The Name of the folder is required.")]
        [MinLength(1, ErrorMessage = "Name must be at least {1} characters.")]
        [MaxLength(50, ErrorMessage = "Name must be at most {1} characters.")]
        public string Name {get; set;}

        /* --------------- */
        [Required(ErrorMessage = "The date of creation is required.")]
        [DataType(DataType.Date)]
        public DateOnly CreationDate {get; set;}

        /* ------------- */
        [Required(ErrorMessage = "status is required.")]
        public string Status {get; set;}

                /* ---------------- */
        [JsonIgnore]
        public List<Document>? Document { get; set; }

    }
}