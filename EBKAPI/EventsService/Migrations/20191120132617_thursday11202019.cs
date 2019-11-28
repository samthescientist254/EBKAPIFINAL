using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsService.Migrations
{
    public partial class thursday11202019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sporsors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin",
                table: "Admin");

            migrationBuilder.RenameTable(
                name: "Admin",
                newName: "Admins");

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "Questions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Admins",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EventLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    UserAgent = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PasswordResetTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    TokenType = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<string>(nullable: true),
                    AdminId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordResetTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasswordResetTokens_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sponsors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EventCode = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    WebSiteLink = table.Column<string>(nullable: true),
                    CellContacts = table.Column<string>(nullable: true),
                    MoreInfo = table.Column<string>(nullable: true),
                    EventId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sponsors_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResetTokens_AdminId",
                table: "PasswordResetTokens",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Sponsors_EventId",
                table: "Sponsors",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventLogs");

            migrationBuilder.DropTable(
                name: "PasswordResetTokens");

            migrationBuilder.DropTable(
                name: "Sponsors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Questions");

            migrationBuilder.RenameTable(
                name: "Admins",
                newName: "Admin");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Admin",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin",
                table: "Admin",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Sporsors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CellContacts = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    EventCode = table.Column<string>(nullable: true),
                    EventId = table.Column<Guid>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    MoreInfo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    WebSiteLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sporsors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sporsors_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sporsors_EventId",
                table: "Sporsors",
                column: "EventId");
        }
    }
}
