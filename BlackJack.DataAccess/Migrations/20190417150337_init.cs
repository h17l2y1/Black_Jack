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
                    Role = table.Column<string>(nullable: true),
                    GameId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_CardMoves_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "GameId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Points", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "619c90cb-936f-4219-b71c-09cb12fb28b6", 0, "9b8c273f-081b-46ec-b482-ce82625a46e0", null, false, null, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot_5" },
                    { "efd972d5-48c7-4108-a1db-68b8f2da4b9f", 0, "a045ba98-613e-4901-83ce-bbc7cd9c218b", null, false, null, false, null, null, null, null, null, false, 0, "Bot", null, false, "Dialer" },
                    { "f58367a9-838c-45d5-85b5-9a3bb06b57c7", 0, "d4bc531e-73c5-41c3-a538-ae2d29eb95ab", null, false, null, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot_1" },
                    { "d4716ed8-4317-4d14-b232-ab9b94316f87", 0, "dd9d3f00-8f8d-4621-84b5-7755a5c333cc", null, false, null, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot_4" },
                    { "355e2339-9a40-47ba-8e27-8dd10ac36c6b", 0, "6a72b196-a196-4a8d-a287-b8467076b229", null, false, null, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot_3" },
                    { "994fa2fe-5d1e-482f-a335-e3848c67af1c", 0, "270d2ff4-07b8-4d09-a307-43550a5550c2", null, false, null, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot_2" }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreationDate", "Rank", "Suit", "Value" },
                values: new object[,]
                {
                    { "22af53e4-cf15-448b-9570-ac7303a76163", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 6, 2, 6 },
                    { "c2744c4a-dd99-468a-a1ff-663a43dcfca2", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 7, 2, 7 },
                    { "10c93468-6ffe-4add-8946-ee1521d31951", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 8, 2, 8 },
                    { "24a91bf6-3394-4a10-8f4a-4fa7cf9d28e4", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 9, 2, 9 },
                    { "52b2a47d-c0dd-4034-8a6c-fbd839d9dda4", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 10, 2, 10 },
                    { "5af52aeb-cca6-4a25-a6e3-2bd57b485308", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 11, 2, 10 },
                    { "e5f54018-d490-4d8a-a067-cd3ac9c1f7b7", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 12, 2, 10 },
                    { "ed2048ff-70b5-482a-91ec-51c8c549e989", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 13, 2, 10 },
                    { "f4577691-d91c-4ea2-8117-793b9a0c2bc3", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 14, 2, 11 },
                    { "550f4e7c-275d-41d8-97b4-c3baf6785a33", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 2, 3, 2 },
                    { "78565830-4133-4660-acdc-ef7b2f174ce5", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 3, 3, 3 },
                    { "9d2e4827-6dfb-4c82-9f52-52f630441572", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 5, 2, 5 },
                    { "557ef907-7a96-494f-8d6f-8d66dff933b6", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 6, 3, 6 },
                    { "18a73630-53d3-4999-aaa2-94aac59e52d8", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 7, 3, 7 },
                    { "6154987a-7707-4a6f-9c93-120642309ffb", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 8, 3, 8 },
                    { "f31b18e6-4cbf-49b9-aeb9-4008145a0392", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 9, 3, 9 },
                    { "257f2e2a-67ee-40be-b9f7-95491ddb498f", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 10, 3, 10 },
                    { "812ee75d-4e2a-4ef2-9e68-098fce6926cb", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 11, 3, 10 },
                    { "be240326-31e2-415c-b4f3-43648cc56d2a", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 12, 3, 10 },
                    { "bf23482e-5719-45a8-9783-eac7ef13b559", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 13, 3, 10 },
                    { "78a07d9d-f1fa-423b-b4ab-33151345c56b", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 14, 3, 11 },
                    { "68987ad1-c5fb-4bad-bfab-fed9cc754b30", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 4, 3, 4 },
                    { "2095c7bb-d4a6-4ba8-b4e7-5cbdfe26d6f3", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 5, 3, 5 },
                    { "1ee092e4-d576-4637-b197-b3225db5f075", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 4, 2, 4 },
                    { "befa2119-7490-4e4f-b144-9d33680d603a", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 2, 2, 2 },
                    { "8b028707-700e-4edd-8392-c127a0a15e15", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 3, 0, 3 },
                    { "fe0f539e-3d19-4a83-adaa-09503c2cc150", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 4, 0, 4 },
                    { "f3b76664-eea1-4f96-b9d9-57b5ec36cc11", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 5, 0, 5 },
                    { "b5ba4685-0ef8-426a-9ff3-b216a3e10b91", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 6, 0, 6 },
                    { "359bb766-2dfd-443f-a85a-bf0f506cf50d", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 7, 0, 7 },
                    { "a79aa69d-4824-4658-a523-4c6b7e9474d6", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 8, 0, 8 },
                    { "65b80328-cd8a-4693-bb45-e9c36b1ad61e", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 9, 0, 9 },
                    { "354c1147-db40-454e-b1c9-d5ffb7f4c7b6", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 10, 0, 10 },
                    { "0f7d1581-8756-4168-8061-acbab9b31d62", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 11, 0, 10 },
                    { "9ec00cd5-79eb-4159-82a0-a82bb227f9da", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 12, 0, 10 },
                    { "5574737c-9667-4b5b-8390-048b3c1599f0", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 13, 0, 10 },
                    { "2a837233-6209-42ad-bfbc-857dacf6f6ea", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 14, 0, 11 },
                    { "d0ad5d49-5201-466f-91f7-7288579b7e08", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 2, 1, 2 },
                    { "57d3ba8c-224e-4186-815b-4ed2e45939ce", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 3, 1, 3 },
                    { "f66233aa-f690-460d-8e6b-17aaf0c8f5f4", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 4, 1, 4 },
                    { "a71086c8-fdb1-4147-96ac-cdd4594e0876", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 5, 1, 5 },
                    { "df6f5505-1814-479e-bacd-d84037fb4623", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 6, 1, 6 },
                    { "ec87ad10-e31f-4875-935b-83638330148a", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 7, 1, 7 },
                    { "63843953-f7f0-4a80-987c-79eccd8a7baf", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 8, 1, 8 },
                    { "c232fc71-5082-472a-b265-90b96ff5729a", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 9, 1, 9 },
                    { "2d927126-1c92-4019-8826-c0d76e5939a2", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 10, 1, 10 },
                    { "519a6ff9-01a8-42e3-8473-433f5a27c4c9", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 11, 1, 10 },
                    { "1ab36688-f1dc-4407-a925-950907599a61", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 12, 1, 10 },
                    { "3d2f5063-1e3d-4e1c-8a54-a69697305f40", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 13, 1, 10 },
                    { "83be744d-8d3c-4fc0-bd4d-fccdd3b44165", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 14, 1, 11 },
                    { "61aa7570-7994-47d0-9cca-67a5919522db", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 3, 2, 3 },
                    { "861a5de2-02f4-4811-a973-8710ea65fb7c", new DateTime(2019, 4, 17, 15, 3, 37, 523, DateTimeKind.Utc), 2, 0, 2 }
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
                name: "IX_AspNetUsers_GameId",
                table: "AspNetUsers",
                column: "GameId");

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
                name: "Cards");

            migrationBuilder.DropTable(
                name: "GameUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
