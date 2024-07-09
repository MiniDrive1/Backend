using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentDeleteController : ControllerBase
    {
        
       private readonly IDocumentRepository _documentRepository;

        public DocumentDeleteController(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var file = await _documentRepository.GetById(id);

            if (file == null)
            {
                return NotFound();
            }

            await _documentRepository.Delete(id);
            return Ok("The file was delete successfully");

        } 
    }
}