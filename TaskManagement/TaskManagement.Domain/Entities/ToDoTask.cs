using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Entities;

public class ToDoTask
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }
    public string AssignedTo { get; set; }
}