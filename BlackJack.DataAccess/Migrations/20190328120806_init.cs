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
                    { "77dea9f7-e997-421e-be8a-2c675073bbac", 0, "94cc5fa2-4a80-475a-9443-9ddc3ca06564", null, false, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot 5" },
                    { "a6583e4d-2eb4-4d81-9313-f44d33d95ef9", 0, "5e52b378-5d00-47af-a419-cb84d8d137e1", null, false, false, null, null, null, null, null, false, 0, "Bot", null, false, "Dialer" },
                    { "4423858f-94dd-4ee6-a118-c7325ccaebbb", 0, "bf642d04-15af-4ce3-a831-368254b978ee", null, false, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot 1" },
                    { "fbf24687-8407-4221-aca5-1b5d9f15dd14", 0, "77c2eb8d-d6c0-4c0c-b6e6-e1b7d9083f44", null, false, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot 4" },
                    { "8c29aad4-4d98-4123-a8f6-9361af069589", 0, "b99338f7-5db1-4418-b20a-0dedcc8bf23d", null, false, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot 3" },
                    { "abd81ce6-627b-447e-88ad-ce510a287532", 0, "357b18e5-1b0c-48b7-bbd1-71091b43f080", null, false, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot 2" }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreationDate", "Rank", "Suit", "Value" },
                values: new object[,]
                {
                    { "5723fc1c-25b1-4c6b-ae9a-789392b2c8e8", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 6, 2, 6 },
                    { "5aec853d-6718-45ab-b9ec-3478b874ab78", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 7, 2, 7 },
                    { "df5b643d-f592-43b7-a192-1a735a6b7bcd", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 8, 2, 8 },
                    { "0707e3f4-6993-46d1-aae5-0691c43dff47", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 9, 2, 9 },
                    { "78d6e5a9-256e-4233-9ea8-8a74f15521d9", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 10, 2, 10 },
                    { "b3a485a7-0d8b-4244-aca0-ea52a0be808a", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 11, 2, 10 },
                    { "ba0b3c63-1b3c-4e90-abad-69ccead82071", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 12, 2, 10 },
                    { "7cd7eedd-96c9-4fd9-9f5b-a5e6d64c18d5", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 13, 2, 10 },
                    { "63af849f-d399-4b45-8e0c-341d596908ea", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 14, 2, 11 },
                    { "a9dc3608-7cb1-4948-93c9-fef7ce4cd4a2", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 2, 3, 2 },
                    { "0bbf7e6e-fee6-4b8b-8c3f-3fca3c8e5cb1", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 3, 3, 3 },
                    { "a6860635-1f89-4c53-b7fd-b9a3f262cb26", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 5, 2, 5 },
                    { "31a9689f-b343-44e9-9cf5-37852c92612f", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 6, 3, 6 },
                    { "19cce115-56dd-4e41-83fd-41abcd85e79a", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 7, 3, 7 },
                    { "bf4b2fb4-fbba-4752-b6b2-f2018949d144", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 8, 3, 8 },
                    { "fbbcca32-4f14-437e-be3e-a4a92c939662", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 9, 3, 9 },
                    { "fe61f97f-8ea8-4db3-bba8-9956ec39f231", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 10, 3, 10 },
                    { "6dcecd2f-9bc8-4e69-be8f-28ab3198a47d", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 11, 3, 10 },
                    { "089c8111-040b-401a-aba3-11deff68b6ed", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 12, 3, 10 },
                    { "4107e1f5-4447-480a-bb7c-7cdab65f303f", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 13, 3, 10 },
                    { "3e602150-572a-4a6f-bf53-25e1bfadf4db", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 14, 3, 11 },
                    { "4d520593-9ea1-42ea-a791-1e279f6a0119", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 4, 3, 4 },
                    { "a960bdfb-52d0-4f3a-8dff-94ef2a26c740", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 5, 3, 5 },
                    { "77284f6a-9bcf-4b1c-8d58-58cc9a60fecc", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 4, 2, 4 },
                    { "555fb5a4-75c0-4bf9-9d8b-515d90d24c73", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 2, 2, 2 },
                    { "92e942ea-8708-4960-90d1-4dc82e0655b7", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 3, 0, 3 },
                    { "1d46fdba-9d7b-47ba-ab07-bb68c88a5b45", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 4, 0, 4 },
                    { "e0d09831-baae-4c75-abf0-26ca8b5d0b80", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 5, 0, 5 },
                    { "1e3d2275-867b-4e82-a4b8-88f0679269ca", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 6, 0, 6 },
                    { "703c1003-5c43-4b03-8494-2933050ab525", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 7, 0, 7 },
                    { "724a528e-eafb-4043-b42d-a36d77a43d77", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 8, 0, 8 },
                    { "462218a1-e585-44ce-bc5f-3e72a0762d12", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 9, 0, 9 },
                    { "87bc428d-a26d-4c1c-a035-6d06067a9db2", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 10, 0, 10 },
                    { "eb7b9b8b-97ad-4cfa-b063-f8e131e877d3", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 11, 0, 10 },
                    { "0a40d61f-cd92-4deb-ba26-715ba48aa1d0", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 12, 0, 10 },
                    { "2645111f-9c2c-49ac-a216-3d07a3468821", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 13, 0, 10 },
                    { "06e4e35e-fec0-49f2-896a-ed8fa08363eb", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 14, 0, 11 },
                    { "8d8bc5d6-b49e-436e-b65a-4d594c71aa20", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 2, 1, 2 },
                    { "516361d4-b327-4eff-8d1b-ff857e6dea7e", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 3, 1, 3 },
                    { "38724cc3-8800-4313-a834-cfa7c211ea01", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 4, 1, 4 },
                    { "0a3bb7cf-ac21-47a3-933e-7cfb80f7d5a1", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 5, 1, 5 },
                    { "0f8dcab7-6130-4e0e-a8e9-39fed1564267", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 6, 1, 6 },
                    { "b3418895-f446-4f77-b649-6b1b295102a6", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 7, 1, 7 },
                    { "34f8e200-496b-4fdf-aa14-cf91196117ed", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 8, 1, 8 },
                    { "c6a9358d-c646-47f7-bcd3-72d196e6ef82", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 9, 1, 9 },
                    { "decd5d5c-1061-4adf-bc4b-43cd27a86e01", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 10, 1, 10 },
                    { "73be72d5-27e2-4ae8-82b6-ce8df86c8fc4", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 11, 1, 10 },
                    { "85f29436-d18e-456a-a5bb-bab851c00cd8", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 12, 1, 10 },
                    { "ea9b9672-d0e4-4093-b771-d1abbe1736f1", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 13, 1, 10 },
                    { "4921d9bb-657c-483b-8a3b-2464814682a6", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 14, 1, 11 },
                    { "5e5835c7-7348-4fce-9f7f-33ef30a1b474", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 3, 2, 3 },
                    { "4ab6477d-fdc8-4074-b144-51c7107e1035", new DateTime(2019, 3, 28, 12, 8, 6, 535, DateTimeKind.Utc), 2, 0, 2 }
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
