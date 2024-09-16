using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Interfaces;

public interface ITaskService
{
    Task AddTask(ToDoTaskDto toDoTaskDto);
    Task UpdateTask(ToDoTaskDto toDoTaskDto);
    Task<ToDoTaskDto> GetTaskById(int id);
    Task<IEnumerable<ToDoTaskDto>> GetAllTasks();
}