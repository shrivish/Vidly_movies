using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    /// <inheritdoc />
    public partial class DBContextChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenresId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenresId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "GenresId",
                table: "Movies");*/

            /*migrationBuilder.DropColumn(
                name: "NumberInStocks",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "NumbersAvailable",
                table: "Movies");*/

            /*migrationBuilder.RenameColumn(
                name: "ReleasedDate",
                table: "Movies",
                newName: "ReleaseDate");

            migrationBuilder.AddColumn<int>(
                name: "NumberAvailable",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberInStock",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");*/

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenreId",
                table: "Movies",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenresId",
                table: "Movies",
                column: "GenresId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
