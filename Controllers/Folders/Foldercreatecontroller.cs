using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos;
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
        public async Task<IActionResult> Post([FromBody] CreateFolderDto folderDto)
        {
            var folder = new Folder
            {
                UserId = folderDto.UserId,
                ParentFolderId = folderDto.ParentFolderId,
                Name = folderDto.Name,
                CreationDate = DateOnly.FromDateTime(DateTime.Now),
                Status = "Active"
            };

            await _folderRepository.Add(folder, folderDto);
            return Created($"api/folders/{folder.Id}", folder);
        } 
    }
}