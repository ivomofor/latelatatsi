using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pilot.Migrations
{
    public partial class AddRatePerHour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_FileOnDatabase_FileOnDatabaseId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Images_imageModelImageId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "FileOnDatabase");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Employees_FileOnDatabaseId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_imageModelImageId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FileOnDatabaseId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "imageModelImageId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "RatePerHour",
                table: "Employees",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RatePerHour",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "FileOnDatabaseId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "imageModelImageId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FileOnDatabase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileOnDatabase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_FileOnDatabaseId",
                table: "Employees",
                column: "FileOnDatabaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_imageModelImageId",
                table: "Employees",
                column: "imageModelImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_FileOnDatabase_FileOnDatabaseId",
                table: "Employees",
                column: "FileOnDatabaseId",
                principalTable: "FileOnDatabase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Images_imageModelImageId",
                table: "Employees",
                column: "imageModelImageId",
                principalTable: "Images",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
