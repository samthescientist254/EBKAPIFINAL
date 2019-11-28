using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsService.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhotoUrl = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SessionId = table.Column<string>(nullable: true),
                    AtendeeId = table.Column<string>(nullable: true),
                    MyNotes = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    OrganisationName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: true),
                    EbkRegNumber = table.Column<string>(nullable: false),
                    Gender = table.Column<int>(nullable: true),
                    EbkStatus = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Membership_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventDays",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    EventId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventDays_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Day = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SpeakerId = table.Column<Guid>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: true),
                    EndTime = table.Column<TimeSpan>(nullable: true),
                    Venue = table.Column<string>(nullable: true),
                    EventCode = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    EventId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventSessions_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EventId = table.Column<Guid>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    FileLink = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    OriginCompany = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    MoreInfo = table.Column<string>(nullable: true),
                    EventCode = table.Column<string>(nullable: false),
                    EventId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Speakers_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sporsors",
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
                    table.PrimaryKey("PK_Sporsors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sporsors_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Atendees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    EbKRegNumber = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    EventId = table.Column<Guid>(nullable: true),
                    MembersId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendees_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Atendees_Membership_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Membership",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TimeSent = table.Column<DateTime>(nullable: true),
                    DeleteForMe = table.Column<bool>(nullable: true),
                    DeleteForYou = table.Column<bool>(nullable: true),
                    DeleteForAll = table.Column<bool>(nullable: true),
                    Sent = table.Column<bool>(nullable: true),
                    MemberId = table.Column<string>(nullable: true),
                    MembersId = table.Column<Guid>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Membership_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Membership",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    QuestionBody = table.Column<string>(nullable: true),
                    PostingDate = table.Column<DateTime>(nullable: true),
                    ResponseDate = table.Column<DateTime>(nullable: true),
                    ResponseBody = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    PosterId = table.Column<Guid>(nullable: true),
                    RespondentId = table.Column<Guid>(nullable: true),
                    SessionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Atendees_PosterId",
                        column: x => x.PosterId,
                        principalTable: "Atendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questions_Speakers_RespondentId",
                        column: x => x.RespondentId,
                        principalTable: "Speakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questions_EventSessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "EventSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendees_EventId",
                table: "Atendees",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendees_MembersId",
                table: "Atendees",
                column: "MembersId");

            migrationBuilder.CreateIndex(
                name: "IX_EventDays_EventId",
                table: "EventDays",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSessions_EventId",
                table: "EventSessions",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_CountryId",
                table: "Membership",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MembersId",
                table: "Messages",
                column: "MembersId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Resources_EventId",
                table: "Resources",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Speakers_EventId",
                table: "Speakers",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Sporsors_EventId",
                table: "Sporsors",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "EventDays");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Sporsors");

            migrationBuilder.DropTable(
                name: "Atendees");

            migrationBuilder.DropTable(
                name: "Speakers");

            migrationBuilder.DropTable(
                name: "EventSessions");

            migrationBuilder.DropTable(
                name: "Membership");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
