using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsService.Migrations
{
    public partial class last3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Atendees_PosterId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Speakers_RespondentId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_EventSessions_SessionId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_PosterId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_RespondentId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_SessionId",
                table: "Questions");

            migrationBuilder.AlterColumn<Guid>(
                name: "RespondentId",
                table: "Questions",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "RespondentId",
                table: "Questions",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Questions_PosterId",
                table: "Questions",
                column: "PosterId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_RespondentId",
                table: "Questions",
                column: "RespondentId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SessionId",
                table: "Questions",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Atendees_PosterId",
                table: "Questions",
                column: "PosterId",
                principalTable: "Atendees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Speakers_RespondentId",
                table: "Questions",
                column: "RespondentId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_EventSessions_SessionId",
                table: "Questions",
                column: "SessionId",
                principalTable: "EventSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
