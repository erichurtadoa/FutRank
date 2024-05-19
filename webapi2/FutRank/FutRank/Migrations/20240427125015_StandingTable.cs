using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutRank.Migrations
{
    /// <inheritdoc />
    public partial class StandingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Standings",
                columns: table => new
                {
                    LeagueId = table.Column<int>(type: "int", nullable: false),
                    Season = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    Description =table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standings", x => new { x.LeagueId, x.Season, x.ClubId });
                    table.ForeignKey(
                        name: "FK_Standings_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Standings_Leagues_LeagueId_Season",
                        columns: x => new { x.LeagueId, x.Season },
                        principalTable: "Leagues",
                        principalColumns: new[] { "Id", "SeasonYear" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Standings_ClubId",
                table: "Standings",
                column: "ClubId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Standings");
        }
    }
}
