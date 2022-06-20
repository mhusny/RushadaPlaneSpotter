using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaneSpotter.EntityFramework.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Planeregistration",
                table: "sightings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Planeregistration",
                table: "sightings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
