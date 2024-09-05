using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiServer.Migrations
{
    public partial class addgradetouserexams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserExams",
                table: "UserExams");

            migrationBuilder.RenameTable(
                name: "UserExams",
                newName: "UsersExams");

            migrationBuilder.AddColumn<string>(
                name: "grade",
                table: "UsersExams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersExams",
                table: "UsersExams",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersExams",
                table: "UsersExams");

            migrationBuilder.DropColumn(
                name: "grade",
                table: "UsersExams");

            migrationBuilder.RenameTable(
                name: "UsersExams",
                newName: "UserExams");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserExams",
                table: "UserExams",
                column: "Id");
        }
    }
}
