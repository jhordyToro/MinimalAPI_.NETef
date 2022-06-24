// we Import the bookstore necesary to be able to use EntityFramework
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minimalAPIef;
using minimalAPIef.Models;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddDbContext<TaskContext>(p => p.UseInMemoryDatabase("TaskDB")); // => esta linea construye la base de datos en memoria
builder.Services.AddSqlServer<TaskContext>(builder.Configuration.GetConnectionString("cnTask")); // => esta linea construye la base de datos en SQLserver. el string de conection se encuentra en "appsettings.csproj"  

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

// This app.MaoGet help us to build all the conection and create of the DateBase with some parameters of exit for to know the status from code     
app.MapGet("/dbconection", async ([FromServices] TaskContext dbContext) =>
{
    dbContext.Database.EnsureCreated();   
    return Results.Ok("Database in memory: " + dbContext.Database.IsInMemory());
});



app.MapGet("/api/tasks", async ([FromServices] TaskContext dbContext) =>
{
    return Results.Ok(dbContext.Tasks.Include(p=> p.Category));
    // return Results.Ok(dbContext.Categorys.Include(p=> p.Tasks).Where(p=> p.weight == 50));
});

app.MapPost("/api/tasks", async ([FromServices] TaskContext dbContext, [FromBody] minimalAPIef.Models.Task task) =>
{
    task.TaskId = Guid.NewGuid();
    task.CreationDate = DateTime.Now;
    await dbContext.AddAsync(task);
    // await dbContext.Tasks.AddAsync(task);
    
    await dbContext.SaveChangesAsync();

    return Results.Ok();

});

app.MapPut("/api/tasks/{id}", async ([FromServices] TaskContext dbContext, [FromBody] minimalAPIef.Models.Task task,[FromRoute] Guid id) =>
{
    var taskNow = dbContext.Tasks.Find(id);
    if (taskNow != null){
        taskNow.CategoryId = task.CategoryId;
        taskNow.Title = task.Title;
        taskNow.PriorityTask = task.PriorityTask;
        taskNow.Description = task.Description;

        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    

    return Results.NotFound();

});

app.MapPut("/api/category/{id}", async ([FromServices] TaskContext dbContext, [FromBody] Category category,[FromRoute] Guid id) =>
{
    var categoryNow = dbContext.Categorys.Find(id);
    if (categoryNow != null){
        categoryNow.Name = category.Name;
        categoryNow.weight = category.weight;

        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    

    return Results.NotFound();

});

app.MapDelete("/api/tasks/{id}", async ([FromServices] TaskContext dbContext,[FromRoute] Guid id) =>
{
    var taskNow = dbContext.Tasks.Find(id);

    if(taskNow!=null){
        dbContext.Remove(taskNow);
        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }
    return Results.NotFound();
});


app.Run();
