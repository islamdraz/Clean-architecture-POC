using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.StudentsPortal.Migrations
{
    public partial class addInstructorIdToInstructorPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InstructorId",
                table: "InstructorPosts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "InstructorPosts");
        }
    }
}
