using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaneSpotter.EntityFramework.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Planeregistration",
                table: "sightings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Planeregistration",
                table: "sightings");
        }
    }
}
