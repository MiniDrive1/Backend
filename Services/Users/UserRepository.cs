using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly BackendDbContext _context;

        public UserRepository(BackendDbContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.Include(u => u.Document).ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users.Include(u => u.Document).FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<bool> CheckExistence(int id)
        {
            return await _context.Users.AnyAsync(u => u.Id == id);
        }
        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}