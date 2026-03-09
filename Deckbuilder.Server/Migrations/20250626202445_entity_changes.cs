using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deckbuilder.Server.Migrations
{
    /// <inheritdoc />
    public partial class entity_changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Decks",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "format",
                table: "Decks",
                newName: "Format");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Decks",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "deckName",
                table: "Decks",
                newName: "DeckName");

            migrationBuilder.RenameColumn(
                name: "colors",
                table: "Decks",
                newName: "Colors");

            migrationBuilder.RenameColumn(
                name: "deckId",
                table: "Decks",
                newName: "DeckId");

            migrationBuilder.RenameColumn(
                name: "toughness",
                table: "Cards",
                newName: "Toughness");

            migrationBuilder.RenameColumn(
                name: "power",
                table: "Cards",
                newName: "Power");

            migrationBuilder.RenameColumn(
                name: "manaCost",
                table: "Cards",
                newName: "ManaCost");

            migrationBuilder.RenameColumn(
                name: "colorIdentity",
                table: "Cards",
                newName: "ColorIdentity");

            migrationBuilder.RenameColumn(
                name: "cardType",
                table: "Cards",
                newName: "CardType");

            migrationBuilder.RenameColumn(
                name: "cardName",
                table: "Cards",
                newName: "CardName");

            migrationBuilder.RenameColumn(
                name: "cardId",
                table: "Cards",
                newName: "CardId");

            migrationBuilder.AlterColumn<int>(
                name: "Toughness",
                table: "Cards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Power",
                table: "Cards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Decks",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Format",
                table: "Decks",
                newName: "format");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Decks",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "DeckName",
                table: "Decks",
                newName: "deckName");

            migrationBuilder.RenameColumn(
                name: "Colors",
                table: "Decks",
                newName: "colors");

            migrationBuilder.RenameColumn(
                name: "DeckId",
                table: "Decks",
                newName: "deckId");

            migrationBuilder.RenameColumn(
                name: "Toughness",
                table: "Cards",
                newName: "toughness");

            migrationBuilder.RenameColumn(
                name: "Power",
                table: "Cards",
                newName: "power");

            migrationBuilder.RenameColumn(
                name: "ManaCost",
                table: "Cards",
                newName: "manaCost");

            migrationBuilder.RenameColumn(
                name: "ColorIdentity",
                table: "Cards",
                newName: "colorIdentity");

            migrationBuilder.RenameColumn(
                name: "CardType",
                table: "Cards",
                newName: "cardType");

            migrationBuilder.RenameColumn(
                name: "CardName",
                table: "Cards",
                newName: "cardName");

            migrationBuilder.RenameColumn(
                name: "CardId",
                table: "Cards",
                newName: "cardId");

            migrationBuilder.AlterColumn<int>(
                name: "toughness",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "power",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
