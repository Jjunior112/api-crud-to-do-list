using Microsoft.EntityFrameworkCore;

public static class TaskRoutes
{
    public static void AddTaskRoutes(this WebApplication app)
    {
        var taskRoutes = app.MapGroup(prefix: "tasks");

        // Post 

        taskRoutes.MapPost(pattern: "", handler: async (AddTaskRequest request, AppDbContext context, CancellationToken ct) =>
      {
          var newTask = new Task(request.Title);
          await context.Tasks.AddAsync(newTask, ct);
          await context.SaveChangesAsync(ct);

          return Results.Ok(newTask);

      });

        // Get

        taskRoutes.MapGet(pattern: "", handler: async (AppDbContext context, CancellationToken ct) =>
        {

            var task = await context.Tasks.ToListAsync(ct);

            return task;

        });

        // Put Title

        taskRoutes.MapPut(pattern: "/task/{id:guid}", handler: async (Guid id, AppDbContext context, UpdateTaskRequest request, CancellationToken ct) =>
        {
            var task = await context.Tasks.SingleOrDefaultAsync(task => task.id == id, ct);

            if (task == null)
                return Results.NotFound();

            task.UpdateTask(request.Title);

            await context.SaveChangesAsync(ct);

            return Results.Ok(task);



        });

        // Put Priority

        taskRoutes.MapPut(pattern: "/priority/{id:guid}", handler: async (Guid id, AppDbContext context, UpdatePriorityRequest request, CancellationToken ct) =>
        {
            var task = await context.Tasks.SingleOrDefaultAsync(task => task.id == id, ct);

            if (task == null)
                return Results.NotFound();


            if (task.Priority != request.priority)
                task.UpdatePriority(!task.Priority);

            await context.SaveChangesAsync(ct);

            return Results.Ok(task);

        });

        // Put Complete task

        taskRoutes.MapPut(pattern:"{id:guid}", handler: async (Guid id, AppDbContext context, UpdateCompletedRequest request, CancellationToken ct)=>{
            var task = await context.Tasks.FirstOrDefaultAsync(task => task.id == id);
            if (task == null)
                return Results.NotFound();
            
            if (task.Iscompleted != request.Iscompleted)

                task.UpdateTaskCompleted(!task.Iscompleted);
                
            await context.SaveChangesAsync(ct);
            
            return Results.Ok(task);
        });

        //Delete

        taskRoutes.MapDelete(pattern: "{id:guid}", handler: async (Guid id, AppDbContext context, CancellationToken ct) =>
        {
            var task = await context.Tasks.SingleOrDefaultAsync(task => task.id == id, ct);

            if (task == null)

                return Results.NotFound();

            context.Tasks.Remove(task);

            await context.SaveChangesAsync(ct);

            return Results.NoContent();

        });







    }

}