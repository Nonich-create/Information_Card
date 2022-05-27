using Microsoft.EntityFrameworkCore.Migrations;

namespace Information_Card.Api.Migrations
{
    public partial class _initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathPhoto",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathPhoto",
                table: "Employees");
        }
    }
}
