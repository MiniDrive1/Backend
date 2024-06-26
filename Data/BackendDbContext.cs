using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class BackendDbContext : DbContext
    {
       public BackendDbContext(DbContextOptions<BackendDbContext> options) : base(options)
        {
        }  

        public DbSet< User> Users { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Trash> Trashs { get; set; }


    }
}