using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutRank.Migrations
{
    /// <inheritdoc />
    public partial class AddFavouriteClubOnUserInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateSignUp",
                table: "UsersInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FavouriteClubId",
                table: "UsersInfo",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "FixtureTime",
                table: "UsersInfo",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UsersInfo",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_FavouriteClubId",
                table: "UsersInfo",
                column: "FavouriteClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInfo_Clubs_FavouriteClubId",
                table: "UsersInfo",
                column: "FavouriteClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersInfo_Clubs_FavouriteClubId",
                table: "UsersInfo");

            migrationBuilder.DropIndex(
                name: "IX_UsersInfo_FavouriteClubId",
                table: "UsersInfo");

            migrationBuilder.DropColumn(
                name: "DateSignUp",
                table: "UsersInfo");

            migrationBuilder.DropColumn(
                name: "FavouriteClubId",
                table: "UsersInfo");

            migrationBuilder.DropColumn(
                name: "FixtureTime",
                table: "UsersInfo");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "UsersInfo");
        }
    }
}
