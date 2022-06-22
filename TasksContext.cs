using Microsoft.EntityFrameworkCore;
using minimalAPIef.Models;

namespace minimalAPIef
{
    public class TaskContext: DbContext
    {
        public DbSet<Category> Categorys {get;set;}
        public DbSet<Models.Task> Tasks {get;set;}

        public TaskContext(DbContextOptions<TaskContext> options) :base(options) {}
    }
}