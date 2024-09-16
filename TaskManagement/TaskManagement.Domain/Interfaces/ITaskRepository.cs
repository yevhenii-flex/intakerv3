using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces;

public interface ITaskRepository
{
    Task AddTaskAsync(ToDoTask task);
    Task UpdateTaskAsync(ToDoTask task);
    Task<ToDoTask> GetTaskByIdAsync(int id);
    Task<IEnumerable<ToDoTask>> GetAllTasksAsync();
}