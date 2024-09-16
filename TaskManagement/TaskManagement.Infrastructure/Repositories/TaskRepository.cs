using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Data;

namespace TaskManagement.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly TaskDbContext _context;

    public TaskRepository(TaskDbContext context)
    {
        _context = context;
    }

    public async Task AddTaskAsync(ToDoTask task)
    {
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTaskAsync(ToDoTask task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
    }

    public async Task<ToDoTask> GetTaskByIdAsync(int id)
    {
        return await _context.Tasks.FirstOrDefaultAsync(t => t.ID == id);
    }

    public async Task<IEnumerable<ToDoTask>> GetAllTasksAsync()
    {
        return await _context.Tasks.ToListAsync();
    }
}