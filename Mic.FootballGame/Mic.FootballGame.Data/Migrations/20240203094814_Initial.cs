using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mic.FootballGame.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FootballSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Schedule = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Address_Number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address_AddressLine = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Address_Locality = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address_Zipcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MinPlayer = table.Column<int>(type: "int", nullable: false),
                    MaxPlayer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballSessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TechnicalScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FootballSessionPlayer",
                columns: table => new
                {
                    FootballSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballSessionPlayer", x => new { x.FootballSessionId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_FootballSessionPlayer_FootballSessions_FootballSessionId",
                        column: x => x.FootballSessionId,
                        principalTable: "FootballSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FootballSessionPlayer_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FootballSessionPlayer_PlayersId",
                table: "FootballSessionPlayer",
                column: "PlayersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FootballSessionPlayer");

            migrationBuilder.DropTable(
                name: "FootballSessions");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
