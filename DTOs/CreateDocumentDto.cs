using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos
{
    public class CreateDocumentDto
    {
        /* ------------ */
        public int Id {get; set;}

        /* ------------ */
        public int UserId {get; set;}

        /* -------------- */
        [Required(ErrorMessage = "The Name of the document is required.")]
        [MinLength(1, ErrorMessage = "Name must be at least {1} characters.")]
        [MaxLength(50, ErrorMessage = "Name must be at most {1} characters.")]
        public string Name {get; set;}

        /* -------------- */
        [Required(ErrorMessage = "The type of the document is required.")]
        [MinLength(1, ErrorMessage = "Name must be at least {1} characters.")]
        [MaxLength(20, ErrorMessage = "Name must be at most {1} characters.")]
        public string Type {get; set;}

        /* -------------- */
        public int? FolderId {get;set;}

  
    }
}