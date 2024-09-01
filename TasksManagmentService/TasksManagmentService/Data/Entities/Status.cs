using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TasksManagmentService.Data.Entities;

public class Status
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public bool isDefault { get; set; } = false;
    public int? SpaceId { get; set; }
}