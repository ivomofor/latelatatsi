using Microsoft.EntityFrameworkCore.Migrations;

namespace Pilot.Migrations
{
    public partial class RemoveTaskRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskResults");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CasualEmployeeId = table.Column<int>(type: "int", nullable: false),
                    Task1 = table.Column<bool>(type: "bit", nullable: true),
                    Task2 = table.Column<bool>(type: "bit", nullable: true),
                    Task3 = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskResults_CasualEmployees_CasualEmployeeId",
                        column: x => x.CasualEmployeeId,
                        principalTable: "CasualEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskResults_CasualEmployeeId",
                table: "TaskResults",
                column: "CasualEmployeeId",
                unique: true);
        }
    }
}
