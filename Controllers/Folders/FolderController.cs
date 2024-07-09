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
    public class FolderController : ControllerBase
    {
        
       private readonly IFolderRepository _folderRepository;

        public FolderController(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Folder>> GetUsers()
        {
            return await _folderRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Folder>> GetUser(int id)
        {
            var user = await _folderRepository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        } 
    }
}