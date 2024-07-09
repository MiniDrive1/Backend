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
    public class DocumentController : ControllerBase
    {
        
       private readonly IDocumentRepository _documentRepository;

        public DocumentController(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        /* Listar todos los archivos */
        [HttpGet]
        public async Task<IActionResult> GetDocuments()
        {
            var files = await _documentRepository.GetAll();
            if(!files.Any()){
                return Ok(new{message = "¡There is no files registered!"});
            }
            return Ok(files);
        }

        /* Listar archivo por id */
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilesById(int id){
            var file = await _documentRepository.GetById(id);
            if(file == null){
                return Ok(new{message= "¡This file does not exist!"});
            }
            return Ok(file);
        }

        /* Endpoint para listar todos los archivos de una determinada carpeta */
        [HttpGet("{idFolder}/folder")]
        public async Task<IEnumerable<Document>> filesOfFolder(int idFolder){
            return await _documentRepository.GetFilesOfOneFolder(idFolder);
        }
        

    
    }
}