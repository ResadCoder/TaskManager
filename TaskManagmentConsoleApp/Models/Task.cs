using TaskManagmentConsoleApp.Extensions;

namespace TaskManagmentConsoleApp.Models;

public class Task
{
    private static int _taskIdCounter = 0;

    public int TaskId { get; set; }
    
    private readonly string? Description; 
    
    public readonly DateTime Deadline;
    public bool TaskStatus { get; set; }
    public Task(string? description, DateTime deadline)
    {
        TaskId = ++_taskIdCounter;
        Description = description;
        Deadline = deadline;
       TaskStatus = false;
    }

    public override string ToString()
    {
        return $"[{TaskId}]  {Description} - Deadline: {Deadline} - Status: {(TaskStatus ? "Completed" : "Pending")}";
    }
    
}