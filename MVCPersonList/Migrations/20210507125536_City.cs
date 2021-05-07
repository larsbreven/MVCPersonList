using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCPersonList.Migrations
{
    public partial class City : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewMayor = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CurrentMayor = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    RegistTimeNewMayor = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
