using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsService.Migrations
{
    public partial class last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Atendees_PosterId",
                table: "Questions");

            migrationBuilder.AlterColumn<Guid>(
                name: "PosterId",
                table: "Questions",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Atendees_PosterId",
                table: "Questions",
                column: "PosterId",
                principalTable: "Atendees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Atendees_PosterId",
                table: "Questions");

            migrationBuilder.AlterColumn<Guid>(
                name: "PosterId",
                table: "Questions",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Atendees_PosterId",
                table: "Questions",
                column: "PosterId",
                principalTable: "Atendees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
