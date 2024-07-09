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

    public class FolderUpdateController : ControllerBase
    {
        private readonly IFolderRepository _folderRepository;

        public FolderUpdateController(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFolder(int id, [FromBody]  CreateFolderDto folderDto)
        {
            var folderFound = await _folderRepository.CheckExistence(id);
            if (folderFound == false)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    await _folderRepository.Update(id, folderDto);
                    return Ok(new { message = "folder updated successfully" });
                }
                catch (Exception ex)
                {
                    return BadRequest(new { message = ex.Message });
                }
            }
        }

        [HttpPut("{id}/Update-status")]    
        public async Task<IActionResult> Status(int id, [FromBody] StatusFolderDTO folder1)
        {
            try
            {
                var folder = await _folderRepository.GetById(id);
                if (folder == null)
                {
                    return NotFound(new { message = "folder not found" });
                }
                await _folderRepository.ChangeStatus(folder1, id);
                return Ok(new { message = "updated status" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        } 

        /* Función para listar todos las carpetas de un usuario en especifico */
        [HttpGet("{idUser}/user")]
        public async Task<IEnumerable<Folder>> foldersOfUser(int idUser){
            return await _folderRepository.GetFoldersOfOneUser(idUser);
        }
    }
}
