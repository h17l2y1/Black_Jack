using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJackDataAccess.Migrations
{
    public partial class addDialerTavle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bots",
                table: "Bots");

            migrationBuilder.RenameTable(
                name: "Bots",
                newName: "Bot");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bot",
                table: "Bot",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bot",
                table: "Bot");

            migrationBuilder.RenameTable(
                name: "Bot",
                newName: "Bots");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bots",
                table: "Bots",
                column: "Id");
        }
    }
}
