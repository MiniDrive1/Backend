using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos
{
    public class CreateFolderDto
    {
        /* ---------------------- */
        public int UserId {get; set;}

        /* --------------- */
        public int? ParentFolderId { get; set; }

        /* ---------------- */
        [Required(ErrorMessage = "The Name of the folder is required.")]
        [MinLength(1, ErrorMessage = "Name must be at least {1} characters.")]
        [MaxLength(50, ErrorMessage = "Name must be at most {1} characters.")]
        public string Name {get; set;}

  
    }
}