using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiServer.Migrations
{
    public partial class changeoveralltimetoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "overallTime",
                table: "Exams");

            migrationBuilder.AddColumn<int>(
                name: "overallTimeInMunutes",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "overallTimeInMunutes",
                table: "Exams");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "overallTime",
                table: "Exams",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
