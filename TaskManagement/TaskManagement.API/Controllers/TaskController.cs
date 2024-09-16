using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Interfaces;

namespace TaskManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDoTaskDto>>> GetAllTasks()
    {
        var tasks = await _taskService.GetAllTasks();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoTaskDto>> GetTaskById(int id)
    {
        var task = await _taskService.GetTaskById(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpPost]
    public async Task<ActionResult> AddTask([FromBody] ToDoTaskDto taskDto)
    {
        await _taskService.AddTask(taskDto);
        return CreatedAtAction(nameof(GetTaskById), new { id = taskDto.ID }, taskDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateTask(int id, [FromBody] ToDoTaskDto taskDto)
    {
        if (id != taskDto.ID)
        {
            return BadRequest();
        }
        await _taskService.UpdateTask(taskDto);
        return NoContent();
    }
}