namespace Mission08.Models;

public interface ITasksRepository
{
    List<TaskItem> Tasks { get; }
    List<Category> Categories { get; }

    void AddTask(TaskItem task);
    void UpdateTask(TaskItem task);
    void DeleteTask(TaskItem task);
}