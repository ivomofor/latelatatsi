using Microsoft.EntityFrameworkCore.Migrations;

namespace Pilot.Migrations
{
    public partial class NewImgv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "imageModelImageId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_imageModelImageId",
                table: "Employees",
                column: "imageModelImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Images_imageModelImageId",
                table: "Employees",
                column: "imageModelImageId",
                principalTable: "Images",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Images_imageModelImageId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_imageModelImageId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "imageModelImageId",
                table: "Employees");
        }
    }
}
