using Microsoft.EntityFrameworkCore.Migrations;

namespace SommerExam.Data.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Sensors");

            migrationBuilder.AlterColumn<string>(
                name: "SensorId",
                table: "Sensors",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 16);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SensorId",
                table: "Sensors",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Sensors",
                nullable: false,
                defaultValue: "");
        }
    }
}
