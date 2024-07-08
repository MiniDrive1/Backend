using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services.Folders;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Folders
{
    [ApiController]
    [Route("api/[controller]")]
    public class Foldercreatecontroller : ControllerBase
    {
      private readonly IFolderRepository _folderRepository;

        public Foldercreatecontroller(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }  
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Folder folder)
        {
            await _folderRepository.Add(folder);
        
            return Created($"api/users/{folder.Id}", folder);
        } 
    }
}