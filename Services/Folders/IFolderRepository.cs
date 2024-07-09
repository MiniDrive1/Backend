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
        Task Add(Folder Folder);
        Task Update(Folder Folder, int id);
        Task Delete(int id);
        Task<bool> CheckExistence(int id);
        Task ChangeStatus(StatusFolderDTO StatusFolderDTO, int id);
    }
}