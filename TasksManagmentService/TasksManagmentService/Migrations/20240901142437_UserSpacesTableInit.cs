using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TasksManagmentService.Migrations
{
    public partial class UserSpacesTableInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserSpaces",
                columns: table => new
                {
                    SpaceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSpaces");
        }
    }
}
