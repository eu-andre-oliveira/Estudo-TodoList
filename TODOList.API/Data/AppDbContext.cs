using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOList.API.Models;

namespace TODOList.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoListModel> TodoLists { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared");
        }
    }
}
