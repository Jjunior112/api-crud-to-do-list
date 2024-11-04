using Microsoft.EntityFrameworkCore;

public static class TaskRoutes
{
    public static void AddTaskRoutes(this WebApplication app)
    {
        var taskRoutes = app.MapGroup(prefix: "tasks");

        // Post 

        taskRoutes.MapPost(pattern: "", handler: async (AddTaskRequest request, AppDbContext context) =>
      {
              var newTask = new Task(request.Title);
              await context.Tasks.AddAsync(newTask);
              await context.SaveChangesAsync();

              return Results.Ok(newTask);
          
      });

        // Get

        taskRoutes.MapGet(pattern: "", handler: async (AppDbContext context) =>
        {

            var task = await context.Tasks.ToListAsync();

            return task;

        });

        

    }

}