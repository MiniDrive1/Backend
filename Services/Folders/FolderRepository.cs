using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Dtos;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Folders
{
    public class FolderRepository : IFolderRepository
    {
        private readonly BackendDbContext _context;

        public FolderRepository(BackendDbContext context)
        {
            _context = context;
        }

        public async Task Add(Folder folder, CreateFolderDto folderDTO)
        {
            // Asignar los valores del DTO al modelo Folder
            folder.UserId = folderDTO.UserId;
            folder.ParentFolderId = folderDTO.ParentFolderId;
            folder.Name = folderDTO.Name;

            // Asignar valores automáticos
            folder.CreationDate = DateOnly.FromDateTime(DateTime.Now);
            folder.Status = "Active";

            _context.Folders.Add(folder);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Folder>> GetAll()
        {
            return await _context.Folders.Include(u => u.Document).ToListAsync();
        }

        public async Task<Folder?> GetById(int id)
        {
            return await _context.Folders.Include(u => u.Document).FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<bool> CheckExistence(int id)
        {
            return await _context.Folders.AnyAsync(u => u.Id == id);
        }

        public async Task Update(int id, CreateFolderDto folderDTO){
            var existingFolder = await _context.Folders.FindAsync(id);

            // Asignar los valores del DTO al folder existente
            existingFolder.UserId = folderDTO.UserId;
            existingFolder.ParentFolderId = folderDTO.ParentFolderId;
            existingFolder.Name = folderDTO.Name;

            // Asignar valores automáticos
            existingFolder.CreationDate = DateOnly.FromDateTime(DateTime.Now);
            _context.Folders.Update(existingFolder);
            await _context.SaveChangesAsync();
        }


        public async Task ChangeStatus( StatusFolderDTO StatusFolderDTO, int id){
            var folder = _context.Folders.Find(id);
                folder.Status = StatusFolderDTO.Status;
            if (folder != null){
                if  (folder.Status == "Active"){
                    folder.Status = "Active";
                    await _context.SaveChangesAsync();
                }
                else if  (folder.Status == "Inactive"){
                    folder.Status = "Inactive";
                    await _context.SaveChangesAsync();
                }
            } 
        }

        public async Task Delete(int id)
        {
            var Folder = await _context.Folders.FindAsync(id);

            if (Folder != null)
            {
                _context.Folders.Remove(Folder);
                await _context.SaveChangesAsync();
            }
        }

        /* Función para listar todos las carpetas de un usuario en especifico */
        public async Task<IEnumerable<Folder>> GetFoldersOfOneUser(int idUser)
        {
            return await _context.Folders.Where(f => f.UserId == idUser && f.ParentFolderId == null).ToListAsync();
        }
    }
}