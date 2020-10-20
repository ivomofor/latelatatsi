using Microsoft.EntityFrameworkCore.Migrations;

namespace Pilot.Migrations
{
    public partial class AddTwoViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FileOnDatabaseId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_FileOnDatabaseId",
                table: "Employees",
                column: "FileOnDatabaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_FileOnDatabase_FileOnDatabaseId",
                table: "Employees",
                column: "FileOnDatabaseId",
                principalTable: "FileOnDatabase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_FileOnDatabase_FileOnDatabaseId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_FileOnDatabaseId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FileOnDatabaseId",
                table: "Employees");
        }
    }
}
