using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJackDataAccess.Migrations
{
    public partial class newTabFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Dialers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BotRole = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dialers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dialers");

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
    }
}
