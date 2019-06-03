using Microsoft.EntityFrameworkCore.Migrations;

namespace SommerExam.Data.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SensorId",
                table: "Sensors",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SensorId",
                table: "Sensors",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 16);
        }
    }
}
