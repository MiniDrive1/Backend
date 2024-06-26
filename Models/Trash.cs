using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Models{
    public class Trash{

        /* --------- */
        public int Id { get; set; }

        /* ----------- */
        public int? FolderId { get; set; }

        public Folder Folder {get; set;}

        /* ------------ */
        public int? DocumentId { get; set; }

        public Document Document {get; set;}

        /* ----------- */
        [Required(ErrorMessage = "The Name of the folder is required.")]
        [MinLength(1, ErrorMessage = "Name must be at least {1} characters.")]
        [MaxLength(50, ErrorMessage = "Name must be at most {1} characters.")]
        public string Name {get; set;}

        /* ----------- */
        [Required(ErrorMessage = "The date of elimination is required.")]
        [DataType(DataType.Date)]
        public DateOnly EliminationDate {get; set;}

        /* ----------- */
        [Required(ErrorMessage = "status is required.")]
        public string Status {get; set;}
        
    }
}