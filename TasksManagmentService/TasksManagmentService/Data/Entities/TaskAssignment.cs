using System.ComponentModel.DataAnnotations;

namespace TasksManagmentService.Data.Entities;

public class TaskAssignment
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int StatusId { get; set; }
    public Status Status { get; set; }
    public int SpaceId { get; set; }
}