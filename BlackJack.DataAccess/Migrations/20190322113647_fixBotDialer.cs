using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJackDataAccess.Migrations
{
    public partial class fixBotDialer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Bots");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Bots");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Bots");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Bots");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Bots");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Bots");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Bots");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Bots");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Bots");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Bots");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Bots");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Bots");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Bots");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Bots");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Bots",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Bots");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Bots",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Bots",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Bots",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Bots",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Bots",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Bots",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Bots",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Bots",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Bots",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Bots",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Bots",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Bots",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Bots",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Bots",
                nullable: true);
        }
    }
}
