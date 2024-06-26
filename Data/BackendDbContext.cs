using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class BackendDbContext : DbContext
    {
       public BackendDbContext(DbContextOptions<BackendDbContext> options) : base(options)
        {
        }  
    }
}