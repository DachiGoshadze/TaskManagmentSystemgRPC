using Microsoft.EntityFrameworkCore;

namespace TasksManagmentService.Data.Entities
{
    public class UserSpaces
    {
        public int Id { get; set; }
        public int SpaceId { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; } = "member";
    }
}
