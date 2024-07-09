using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos
{
    public class StatusFolderDTO
    {
       public int Id {get; set;}

        [Required(ErrorMessage = "status is required.")]
       public string Status {get; set;}
  
    }
}