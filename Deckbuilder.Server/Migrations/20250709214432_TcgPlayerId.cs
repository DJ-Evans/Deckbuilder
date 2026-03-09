using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deckbuilder.Server.Migrations
{
    /// <inheritdoc />
    public partial class TcgPlayerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TcgPlayerId",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TcgPlayerId",
                table: "Cards");
        }
    }
}
