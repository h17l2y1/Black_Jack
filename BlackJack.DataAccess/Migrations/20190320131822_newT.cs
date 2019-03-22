using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJackDataAccess.Migrations
{
    public partial class newT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CardId",
                table: "CardMoves",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardMoves_CardId",
                table: "CardMoves",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardMoves_Cards_CardId",
                table: "CardMoves",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardMoves_Cards_CardId",
                table: "CardMoves");

            migrationBuilder.DropIndex(
                name: "IX_CardMoves_CardId",
                table: "CardMoves");

            migrationBuilder.AlterColumn<string>(
                name: "CardId",
                table: "CardMoves",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
