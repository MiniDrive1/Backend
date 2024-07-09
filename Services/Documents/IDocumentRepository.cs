using Backend.Dtos;
using Backend.Models;

namespace Backend.Services
{
    public interface IDocumentRepository
    {
        Task<IEnumerable<Document>> GetAll();
        Task<Document?> GetById(int id);
        Task Create(Document document, CreateDocumentDto documentDTO);
        Task Update(int id, CreateDocumentDto documentDTO);
        Task Delete(int id);
        Task<string> Active(int id, StatusDocumentDto statusDto);
        Task<string> Desactive(int id, StatusDocumentDto statusDto);

        /* Listar todos los archivos de una carpeta en especifico */
        Task<IEnumerable<Document>> GetFilesOfOneFolder(int idFolder);
    }
}