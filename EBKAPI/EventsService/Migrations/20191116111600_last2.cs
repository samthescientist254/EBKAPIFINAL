using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsService.Migrations
{
    public partial class last2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_EventSessions_SessionId",
                table: "Questions");

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                table: "Questions",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_EventSessions_SessionId",
                table: "Questions",
                column: "SessionId",
                principalTable: "EventSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_EventSessions_SessionId",
                table: "Questions");

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                table: "Questions",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_EventSessions_SessionId",
                table: "Questions",
                column: "SessionId",
                principalTable: "EventSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
