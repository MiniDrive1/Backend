using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Backend.Dtos;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Documentcreatecontroller : ControllerBase
    {
        
       private readonly IDocumentRepository _documentRepository;

        public Documentcreatecontroller(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFile([FromBody] CreateDocumentDto documentDTO)
        {
            try
            {
                // Crear una nueva instancia de Document
                var document = new Document();
                
                // Llamar al método Create del repositorio
                await _documentRepository.Create(document, documentDTO);
                return Ok("The file was created successfully.");

            }
            catch (System.Exception)
            {   
                return BadRequest("¡The file could not be created!");
            }
        } 
    }
}