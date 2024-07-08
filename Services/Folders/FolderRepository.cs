using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
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

        public async Task Add(Folder folder)
        {
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
        public async Task Update(Folder Folder, int id){
         _context.Folders.Update(Folder);
        await _context.SaveChangesAsync();

        }
        public async Task ChangeStatus( Folder folder1, int id){
        var folder = _context.Folders.Find(id);
        if (folder == null){
            if  (folder.Status == "Activo"){
                folder.Status = "Inactivo";
                await _context.SaveChangesAsync();
            }
            else{
                folder.Status = "Activo";
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
    }
}