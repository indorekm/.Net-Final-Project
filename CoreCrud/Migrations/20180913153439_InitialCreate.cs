using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreCrud.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManufacturerContext",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturerContext", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WatchContext",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Brand = table.Column<string>(nullable: true),
                    LaunchDate = table.Column<DateTime>(nullable: false),
                    IsAnalog = table.Column<bool>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Material = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: true),
                    ManufacturerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchContext", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WatchContext_ManufacturerContext_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "ManufacturerContext",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WatchContext_ManufacturerId",
                table: "WatchContext",
                column: "ManufacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WatchContext");

            migrationBuilder.DropTable(
                name: "ManufacturerContext");
        }
    }
}
