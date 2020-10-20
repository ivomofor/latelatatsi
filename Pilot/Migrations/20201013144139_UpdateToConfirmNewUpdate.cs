using Microsoft.EntityFrameworkCore.Migrations;

namespace Pilot.Migrations
{
    public partial class UpdateToConfirmNewUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskResult_CasualEmployees_CasualEmployeeId",
                table: "TaskResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskResult",
                table: "TaskResult");

            migrationBuilder.RenameTable(
                name: "TaskResult",
                newName: "TaskResults");

            migrationBuilder.RenameIndex(
                name: "IX_TaskResult_CasualEmployeeId",
                table: "TaskResults",
                newName: "IX_TaskResults_CasualEmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskResults",
                table: "TaskResults",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskResults_CasualEmployees_CasualEmployeeId",
                table: "TaskResults",
                column: "CasualEmployeeId",
                principalTable: "CasualEmployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskResults_CasualEmployees_CasualEmployeeId",
                table: "TaskResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskResults",
                table: "TaskResults");

            migrationBuilder.RenameTable(
                name: "TaskResults",
                newName: "TaskResult");

            migrationBuilder.RenameIndex(
                name: "IX_TaskResults_CasualEmployeeId",
                table: "TaskResult",
                newName: "IX_TaskResult_CasualEmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskResult",
                table: "TaskResult",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskResult_CasualEmployees_CasualEmployeeId",
                table: "TaskResult",
                column: "CasualEmployeeId",
                principalTable: "CasualEmployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
