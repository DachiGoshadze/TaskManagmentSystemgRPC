using System.ComponentModel.DataAnnotations;

namespace TasksManagmentService.Data.Entities;

public class Space
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int creatorId { get; set; }
    public ICollection<Status> Statuses { get; set; }
    public ICollection<TaskAssignment> Tasks { get; set; }
}