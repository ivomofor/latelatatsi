using Microsoft.EntityFrameworkCore.Migrations;

namespace Pilot.Migrations
{
    public partial class UpdateToConfirm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskResult",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Task1 = table.Column<bool>(nullable: true),
                    Task2 = table.Column<bool>(nullable: true),
                    Task3 = table.Column<bool>(nullable: true),
                    CasualEmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskResult_CasualEmployees_CasualEmployeeId",
                        column: x => x.CasualEmployeeId,
                        principalTable: "CasualEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskResult_CasualEmployeeId",
                table: "TaskResult",
                column: "CasualEmployeeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskResult");
        }
    }
}
