using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TasksManagmentService.Migrations
{
    public partial class UserSpacesTableInit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserSpaces",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSpaces",
                table: "UserSpaces",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSpaces",
                table: "UserSpaces");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserSpaces");
        }
    }
}
