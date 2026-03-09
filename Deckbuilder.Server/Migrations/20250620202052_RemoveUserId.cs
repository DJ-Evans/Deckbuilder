using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deckbuilder.Server.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Decks",
                newName: "deckId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "deckId",
                table: "Decks",
                newName: "userId");
        }
    }
}
