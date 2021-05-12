using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCPersonList.Migrations
{
    public partial class Cityver1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentMayor",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "RegistTimeNewMayor",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "NewMayor",
                table: "Cities",
                newName: "CityName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CityName",
                table: "Cities",
                newName: "NewMayor");

            migrationBuilder.AddColumn<string>(
                name: "CurrentMayor",
                table: "Cities",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistTimeNewMayor",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
