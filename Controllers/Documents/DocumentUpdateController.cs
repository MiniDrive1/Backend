using Backend.Dtos;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Backend.Dtos;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentUpdateController : ControllerBase
    {
        
       private readonly IDocumentRepository _documentRepository;

        public DocumentUpdateController(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        /* Endpoint para actualizar archivos */
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFile(int id, [FromBody] CreateDocumentDto documentDTO)
        {
           
                try
                {
                    await _documentRepository.Update(id, documentDTO);
                    return Ok(new { message = "The file was updated successfully." });
                }
                catch (Exception ex)
                {
                    return BadRequest(new { message = ex.Message });
                }
            
        }


        /* Endpoint para activar o restablecer el estado de una archivo */
        [HttpPut("{id}/activestatus")]    
        public async Task<IActionResult> ActiveStatus(int id, [FromBody]  StatusDocumentDto statusDto)
        {
            var message = await _documentRepository.Active(id, statusDto);
            return Ok(new { Message = message });
        }


        /* Endpoint para desactivar o restablecer el estado de una archivo */
        [HttpPut("{id}/inactivetatus")]    
        public async Task<IActionResult> InactiveStatus(int id, [FromBody]  StatusDocumentDto statusDto)
        {
            var message = await _documentRepository.Desactive(id, statusDto);
            return Ok(new { Message = message });
        } 

    }
}
