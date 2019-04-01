using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJackDataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    Suit = table.Column<int>(nullable: false),
                    Rank = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardMoves",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Move = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    GameId = table.Column<string>(nullable: true),
                    CardId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardMoves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardMoves_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CardMoves_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Winner = table.Column<bool>(nullable: false),
                    GameId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameUsers_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Points", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "22890db1-b202-4260-948f-e4ac42317fa3", 0, "0a528eb4-56b4-4b28-a77e-4b2090192531", null, false, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot 5" },
                    { "7a2f4530-f3bd-4190-b776-2bdb58df67c5", 0, "ce6a78be-04bb-4174-8203-27967a9f5f25", null, false, false, null, null, null, null, null, false, 0, "Bot", null, false, "Dialer" },
                    { "60044d67-88a2-4282-8332-29e042ab467c", 0, "67c1aa41-47e2-41ab-998a-7d5cb4ae3940", null, false, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot 1" },
                    { "0b16a8e6-30fb-405a-8f2b-3e383cab19fb", 0, "0b3e0929-2c29-4084-95a5-aeb1fef146fd", null, false, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot 4" },
                    { "0fcfdde2-41c5-437c-80e1-9a2d71805d7c", 0, "0b5fa3ce-5849-445c-ab83-0f630ad5df11", null, false, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot 3" },
                    { "31d26926-2f9f-4df2-a131-d0d562484c50", 0, "01ced07d-9bbc-44fc-bb91-9a7195bea3c5", null, false, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot 2" }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreationDate", "Rank", "Suit", "Value" },
                values: new object[,]
                {
                    { "629af487-b852-4db6-85b2-c63c774a46a4", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 6, 2, 6 },
                    { "f13698c2-8b34-4865-bbc1-19ae1e00f77c", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 7, 2, 7 },
                    { "73fca3e7-778b-463c-98dd-fd468120f01a", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 8, 2, 8 },
                    { "feed5340-3cea-4455-bd00-a6396ee40129", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 9, 2, 9 },
                    { "5f1717c6-d6ce-4058-b176-b4ea08a1e8fb", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 10, 2, 10 },
                    { "46133abf-5347-4aa2-8162-630b32ce9de1", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 11, 2, 10 },
                    { "7b4e8dd7-c761-43dd-b52f-7f250907acc5", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 12, 2, 10 },
                    { "aed63978-706d-4a93-8bbe-cc7bf4495862", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 13, 2, 10 },
                    { "6b061caa-c8b3-4b67-9145-aa19897378ee", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 14, 2, 11 },
                    { "de258540-b7cc-4afa-a9a9-e964ae5d84d6", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 2, 3, 2 },
                    { "ae875804-bd08-4775-a826-fdff15f428e1", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 3, 3, 3 },
                    { "777d985c-6bc2-42ce-913b-93f4cb4c1d56", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 5, 2, 5 },
                    { "958041b8-ac21-4c33-aa47-44818aa224ff", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 6, 3, 6 },
                    { "bbb9734d-80e9-429b-b3c4-d48de1cb4332", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 7, 3, 7 },
                    { "d7d56216-37ba-41cc-8f01-477eb4cb7101", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 8, 3, 8 },
                    { "b9130192-0b8b-4dcd-8498-ab1260d84733", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 9, 3, 9 },
                    { "3bb6d221-89a5-4bc3-b86b-1f78a64839a4", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 10, 3, 10 },
                    { "3c0a6307-aa0f-4547-9e6b-6b512032e47c", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 11, 3, 10 },
                    { "3d11e0a1-731b-4ae0-b1d7-56438cecdd0d", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 12, 3, 10 },
                    { "9b88941e-90f9-4ac5-95c1-d16ea514cc79", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 13, 3, 10 },
                    { "f336c82f-b499-438e-b967-6ce77083fd62", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 14, 3, 11 },
                    { "d2ff0e91-95c1-4824-9b2a-dd80a358c808", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 4, 3, 4 },
                    { "16229aa7-a319-4beb-a38e-002aec2a4d87", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 5, 3, 5 },
                    { "60f3f51d-6f06-4eda-a562-2f9d99825e7e", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 4, 2, 4 },
                    { "2cf4afcf-eb14-4835-8ca6-563615095382", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 2, 2, 2 },
                    { "1ac7cf10-2fce-4167-87b7-15a1f69e03ac", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 3, 0, 3 },
                    { "f71a175a-0808-44ad-b64b-4d69b23c262e", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 4, 0, 4 },
                    { "a530c481-d0e8-4cf9-86f6-69ec3bc06c3b", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 5, 0, 5 },
                    { "a482637c-c66b-46f0-85a7-f32b39858c82", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 6, 0, 6 },
                    { "9b72abe7-3f1d-4fa0-9ed5-5861e9e1a2f1", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 7, 0, 7 },
                    { "c5d78bb2-928e-472c-9a9c-100e36071fef", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 8, 0, 8 },
                    { "cff6d688-e21c-46a5-a81e-710fac77a198", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 9, 0, 9 },
                    { "266b61fe-b987-489a-a65d-4c2e1412c139", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 10, 0, 10 },
                    { "eb990f88-cf7f-4208-9cb2-a5cb2200a85e", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 11, 0, 10 },
                    { "bf281824-4ec4-455b-99d9-5bd01f167c13", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 12, 0, 10 },
                    { "5ff6f056-34be-4b57-8fcb-d68f474db9c0", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 13, 0, 10 },
                    { "2ed54698-dcc4-4532-9a42-429c13154287", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 14, 0, 11 },
                    { "096593ae-7ff6-4d42-8576-4d537bd3c7cd", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 2, 1, 2 },
                    { "62fee82f-3280-437b-af69-64ff9862fdbd", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 3, 1, 3 },
                    { "df08f8a5-ee29-409a-adb1-fbd5512af921", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 4, 1, 4 },
                    { "00b28b48-c9fb-4aa4-8cae-3cb776c46958", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 5, 1, 5 },
                    { "9754d037-8943-4f0f-bb02-14f1538cbcc1", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 6, 1, 6 },
                    { "adf28741-7e7b-4ffc-a69c-02a54980735a", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 7, 1, 7 },
                    { "43f2b9dd-a784-4c10-aa2c-29a00238d90b", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 8, 1, 8 },
                    { "80c6bb6a-dfa4-4506-8014-6a26fe640165", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 9, 1, 9 },
                    { "05ef0f60-88a6-48b1-9323-a0775821c86b", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 10, 1, 10 },
                    { "2efc2e1b-8f32-4962-9a85-1c1333c18259", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 11, 1, 10 },
                    { "921eaacf-b43f-458e-b186-e90c169e1d06", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 12, 1, 10 },
                    { "04e5d3d5-e357-4d01-a00b-364e9324324e", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 13, 1, 10 },
                    { "c5e0b681-ba27-4cb2-812a-37cf09060334", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 14, 1, 11 },
                    { "55d50116-6cb9-4da0-b2bc-4dd74de0bece", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 3, 2, 3 },
                    { "00fec9d7-650d-4b28-8c9f-25c13c29bb11", new DateTime(2019, 4, 1, 12, 35, 18, 911, DateTimeKind.Utc), 2, 0, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CardMoves_CardId",
                table: "CardMoves",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardMoves_GameId",
                table: "CardMoves",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameUsers_GameId",
                table: "GameUsers",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameUsers_UserId",
                table: "GameUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CardMoves");

            migrationBuilder.DropTable(
                name: "GameUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
