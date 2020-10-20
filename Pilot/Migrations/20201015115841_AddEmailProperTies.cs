using Microsoft.EntityFrameworkCore.Migrations;

namespace Pilot.Migrations
{
    public partial class AddEmailProperTies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CasualEmployees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "CasualEmployees");
        }
    }
}
