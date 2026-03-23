public class TaskService
{
    private readonly List<TaskDto> _tasks = new(){
    new TaskDto {Id = 1, Title = "Basic Title #1", Completed = true},
    new TaskDto {Id = 2, Title = "Basic Title #2", Completed = false},
    new TaskDto {Id = 3, Title = "Basic Title #3", Completed = false}
  };
    public List<TaskDto> GetAll()
    {
        return _tasks;
    }
    public TaskDto CreateTask(CreateTaskDto dto)
    {
        var newTask = new TaskDto
        {
            Id = _tasks.Count + 1,
            Title = dto.Title,
            Completed = false
        };
        _tasks.Add(newTask);
        return newTask;
    }
    public TaskDto? UpdateTask(int id, UpdateTaskDto dto)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            return null;
        }

        if (!string.IsNullOrWhiteSpace(dto.Title))
        {
            task.Title = dto.Title;
        }
        if (dto.Completed.HasValue)
        {
            task.Completed = dto.Completed.Value;
        }
        return task;
    }
}
