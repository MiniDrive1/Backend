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
    public class FolderDeleteController : ControllerBase
    {
         private readonly IFolderRepository _folderRepository;

        public FolderDeleteController(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
         var folder = await _folderRepository.GetById(id);

            if (folder == null)
            {
                return NotFound();
            }
            await _folderRepository.Delete(id);
            return Ok("Se eliminó correctamente");

        } 
    }
}