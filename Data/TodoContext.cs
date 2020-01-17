using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) 
            : base(options)
        {
        }

        public DbSet<TodoItem> Todo { get; set; }

        public Task<int> SaveChangesAsync()
        {
            this.SyncEntitiesStatePreCommit();
            return base.SaveChangesAsync();
        }
    }
}
