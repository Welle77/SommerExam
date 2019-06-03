using Microsoft.EntityFrameworkCore.Migrations;

namespace SommerExam.Data.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdOfSpecificLocation",
                table: "Locations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdOfSpecificLocation",
                table: "Locations",
                nullable: false,
                defaultValue: 0);
        }
    }
}
