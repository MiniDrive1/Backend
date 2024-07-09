using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos;
using Backend.Models;

namespace Backend.Services.Folders
{
    public interface IFolderRepository
    {
        Task<IEnumerable<Folder>> GetAll();
        Task<Folder?> GetById(int id);
        Task Add(Folder folder, CreateFolderDto folderDTO);
        Task Update(int id, CreateFolderDto folderDTO);
        Task Delete(int id);
        Task<bool> CheckExistence(int id);
        Task ChangeStatus(StatusFolderDTO StatusFolderDTO, int id);

        /* Función para listar todos las carpetas de un usuario en especifico */
        Task<IEnumerable<Folder>> GetFoldersOfOneUser(int idUser);
    }
}