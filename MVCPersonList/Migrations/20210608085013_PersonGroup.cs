using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCPersonList.Migrations
{
    public partial class PersonGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonGroupId",
                table: "People",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_PersonGroupId",
                table: "People",
                column: "PersonGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_PersonGroups_PersonGroupId",
                table: "People",
                column: "PersonGroupId",
                principalTable: "PersonGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_PersonGroups_PersonGroupId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_PersonGroupId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PersonGroupId",
                table: "People");
        }
    }
}
