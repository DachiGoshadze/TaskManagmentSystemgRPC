using System.ComponentModel.DataAnnotations;

namespace TasksManagmentService.Data.Entities;

public class Space
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int creatorId { get; set; }
    public List<Status> Statuses { get; set; } = new();
    public List<TaskAssignment> Tasks { get; set; } = new();
}