using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsService.Migrations
{
    public partial class reg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Registered",
                table: "Membership",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Registered",
                table: "Membership");
        }
    }
}
