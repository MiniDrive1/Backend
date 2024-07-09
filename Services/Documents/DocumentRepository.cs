using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Dtos;
using Backend.Models;
using Microsoft.EntityFrameworkCore;


namespace Backend.Services
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly BackendDbContext _context;

        public DocumentRepository(BackendDbContext context){
            _context = context;
        }

        /* Funciòn para activar el estado de un archivo */
        public async Task<string> Active(int id, StatusDocumentDto statusDto)
        {
            var foundFile = await _context.Documents.FindAsync(id);
            
            if (foundFile == null)
            {
                throw new Exception("The file was not found!");
            }

            string message;
            if (foundFile.Status == "Inactive")
            {
                foundFile.Status = "Active";
                message = "The file is active";
            }
            else if (foundFile.Status == "Active")
            {
                message = "The file is already active!";
            }
            else
            {
                throw new Exception("The status of the file is unknown!");
            }

            await _context.SaveChangesAsync();
            return message;
        }



        /* Función asincronica para crear archivos */
        public async Task Create(Document document, CreateDocumentDto documentDTO)
        {
            // Asignar los valores del DTO al modelo Document
            document.UserId = documentDTO.UserId;
            document.Name = documentDTO.Name;
            document.Type = documentDTO.Type;
            document.FolderId = documentDTO.FolderId;

            // Asignar valores automáticos
            document.CreationDate = DateOnly.FromDateTime(DateTime.Now);
            document.Status = "Active";

            _context.Documents.Add(document);
            await _context.SaveChangesAsync();
        }

        /* Funciòn para eliminar archivos definitivamente */
        public async Task Delete(int id)
        {
            var foundFile = await _context.Documents.FindAsync(id);

            if (foundFile != null)
            {
                _context.Documents.Remove(foundFile);
                await _context.SaveChangesAsync();
            }
        }

       public async Task<string> Desactive(int id, StatusDocumentDto statusDto)
        {
            var foundFile = await _context.Documents.FindAsync(id);
            
            if (foundFile == null)
            {
                throw new Exception("The file was not found!");
            }

            string message;
            if (foundFile.Status == "Active")
            {
                foundFile.Status = "Inactive";
                message = "The file is inactive";
            }
            else if (foundFile.Status == "Inactive")
            {
                message = "The file is already inactive!";
            }
            else
            {
                throw new Exception("The status of the file is unknown!");
            }

            await _context.SaveChangesAsync();
            return message;
        }


        /* Función para listar todos los archivos */
        public async Task<IEnumerable<Document>> GetAll()
        {
            return await _context.Documents.ToListAsync();
        }

        /* Funciòn para ver detalles de un archivo en especifico */
        public async Task<Document?> GetById(int id)
        {
            return await _context.Documents.FirstOrDefaultAsync(u => u.Id == id);
        }

        /* Funciòn para actualizar un archivo */
        public async Task Update(int id, CreateDocumentDto documentDTO)
        {
            var existFile = await _context.Documents.FindAsync(id);

            // Asignar los valores del DTO al folder existente
            existFile.UserId = documentDTO.UserId;
            existFile.Name = documentDTO.Name;
            existFile.Type = documentDTO.Type;
            existFile.FolderId = documentDTO.FolderId;

            // Asignar valores automáticos
            existFile.CreationDate = DateOnly.FromDateTime(DateTime.Now);

            _context.Documents.Update(existFile);
            await _context.SaveChangesAsync();
        }

        /* Función para listar todos los archivos de una carpeta en especifico */
        public async Task<IEnumerable<Document>> GetFilesOfOneFolder(int idFolder)
        {
            return await _context.Documents.Where(d => d.FolderId == idFolder).ToListAsync();
        }
    }
}