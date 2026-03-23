using Microsoft.AspNetCore.Builder;

public static class TaskEndpoints
{
    public static void MapTaskEndpoints(this WebApplication app)
    {
        //GET TASKS ENDPOINT
        app.MapGet("/tasks", (TaskService service) =>
        {
            return service.GetAll();
        });
        //POST TASKS ENDPOINT
        app.MapPost("/tasks", (CreateTaskDto dto, TaskService service) =>
        {
            var task = service.CreateTask(dto);

            return Results.Created($"/tasks/{task.Id}", task);
        });
        //PUT(UPDATE) TASK BY ID ENDPOINT
        app.MapPut("/tasks/{id}", (int id, UpdateTaskDto dto, TaskService service) =>
        {
            var updatedTask = service.UpdateTask(id, dto);

            return updatedTask is not null
            ? Results.Ok(updatedTask)
            : Results.NotFound();
        });
        app.MapDelete("/tasks/{id}", (int id, TaskService service) =>
        {
            var deletedTask = service.DeleteTask(id);

            return deletedTask is not null
              ? Results.NoContent()
              : Results.NotFound(new { message = "Task not found)" });
        });
    }


}
