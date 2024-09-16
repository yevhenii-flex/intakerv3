using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.DTOs;

public class ToDoTaskDto
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }
    public string AssignedTo { get; set; }
}