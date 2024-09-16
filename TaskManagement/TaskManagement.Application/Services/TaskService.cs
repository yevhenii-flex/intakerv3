using TaskManagement.Application.DTOs;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task AddTask(ToDoTaskDto toDoTaskDto)
    {
        var task = new ToDoTask
        {
            Name = toDoTaskDto.Name,
            Description = toDoTaskDto.Description,
            Status = toDoTaskDto.Status,
            AssignedTo = toDoTaskDto.AssignedTo
        };

        await _taskRepository.AddTaskAsync(task);
    }

    public async Task UpdateTask(ToDoTaskDto toDoTaskDto)
    {
        var task = new ToDoTask
        {
            ID = toDoTaskDto.ID,
            Name = toDoTaskDto.Name,
            Description = toDoTaskDto.Description,
            Status = toDoTaskDto.Status,
            AssignedTo = toDoTaskDto.AssignedTo
        };

        await _taskRepository.UpdateTaskAsync(task);
    }

    public async Task<ToDoTaskDto> GetTaskById(int id)
    {
        var task = await _taskRepository.GetTaskByIdAsync(id);
        var taskDto = new ToDoTaskDto
        {
            ID = task.ID,
            Name = task.Name,
            Description = task.Description,
            Status = task.Status,
            AssignedTo = task.AssignedTo
        };

        return taskDto;
    }

    public async Task<IEnumerable<ToDoTaskDto>> GetAllTasks()
    {
        var tasks = await _taskRepository.GetAllTasksAsync();
        var taskDtos = tasks.Select(task => new ToDoTaskDto
        {
            ID = task.ID,
            Name = task.Name,
            Description = task.Description,
            Status = task.Status,
            AssignedTo = task.AssignedTo
        }).ToList();

        return taskDtos;
    }
}
