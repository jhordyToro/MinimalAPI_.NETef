using Microsoft.EntityFrameworkCore;
using minimalAPIef.Models;

namespace minimalAPIef
{
    public class TaskContext: DbContext
    {
        public DbSet<Category> Categorys {get;set;}
        public DbSet<Models.Task> Tasks {get;set;}

        public TaskContext(DbContextOptions<TaskContext> options) :base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Category> categoryInit = new List<Category>();
            
            categoryInit.Add(new Category() {CategoryId = Guid.Parse("e911afe8-8bf3-4308-827a-85a2c9742cd9"), Name =  "ActivitiesPending", weight = 20,});
            categoryInit.Add(new Category() {CategoryId = Guid.Parse("e911afe8-8bf3-4308-827a-85a2c9742c02"), Name =  "ActivitiesPersonal", weight = 50,});

            modelBuilder.Entity<Category>(category=>
            {
               category.ToTable("Category");
               category.HasKey(p=> p.CategoryId);
               category.Property(p=> p.Name).IsRequired().HasMaxLength(150);
               category.Property(p=> p.Description); //.IsRequired(false)

               category.Property(p=> p.weight);

               category.HasData(categoryInit);
            });

            List<Models.Task> taskInit = new List<Models.Task>();

            taskInit.Add(new Models.Task() {TaskId = Guid.Parse("57f0795e-b5b5-416a-b6b2-5fc1193c17ad"), CategoryId = Guid.Parse("e911afe8-8bf3-4308-827a-85a2c9742cd9"), PriorityTask = Priority.Half, Title="Utility Payment", CreationDate = DateTime.Now});
            taskInit.Add(new Models.Task() {TaskId = Guid.Parse("57f0795e-b5b5-416a-b6b2-5fc1193c1702"), CategoryId = Guid.Parse("e911afe8-8bf3-4308-827a-85a2c9742c02"), PriorityTask = Priority.low, Title="end up of view movies in netflix", CreationDate = DateTime.Now});

            modelBuilder.Entity<Models.Task>(task=>
            {
                task.ToTable("Task");
                task.HasKey(p=> p.TaskId);
                task.HasOne(p=> p.Category).WithMany(p=> p.Tasks).HasForeignKey(p=> p.CategoryId);
                
                task.Property(p=> p.Title).IsRequired().HasMaxLength(200);
                task.Property(p=> p.Description); //.IsRequired(false)
                task.Property(p=> p.PriorityTask);
                task.Property(p=> p.CreationDate);
                
                task.Ignore(p=> p.Summary);

                task.HasData(taskInit);
            });
        }
    }
}