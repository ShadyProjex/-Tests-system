using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiServer.Migrations
{
    public partial class fixtypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "overallTimeInMunutes",
                table: "Exams",
                newName: "overallTimeInMinutes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "overallTimeInMinutes",
                table: "Exams",
                newName: "overallTimeInMunutes");
        }
    }
}
