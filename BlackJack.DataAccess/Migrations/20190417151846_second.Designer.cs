﻿// <auto-generated />
using System;
using BlackJackDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlackJackDataAccess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20190417151846_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlackJackEntities.Entities.Card", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<int>("Rank");

                    b.Property<int>("Suit");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.ToTable("Cards");

                    b.HasData(
                        new { Id = "11837808-917b-40c9-9453-34038b5bd54a", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 2, Suit = 0, Value = 2 },
                        new { Id = "76e9278d-481a-449d-85f4-b25e00f2c0a9", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 3, Suit = 0, Value = 3 },
                        new { Id = "ace8643e-4ade-4e36-abc0-e4cb044adee0", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 4, Suit = 0, Value = 4 },
                        new { Id = "0ed44dcb-a3cb-4b37-89c4-fd7ab5293969", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 5, Suit = 0, Value = 5 },
                        new { Id = "609f3dae-ece1-49eb-b787-870e909b2d8c", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 6, Suit = 0, Value = 6 },
                        new { Id = "2e158ada-93e8-40f2-9336-56e9ab3192ad", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 7, Suit = 0, Value = 7 },
                        new { Id = "74d53c93-f6cf-4676-af88-917a5baca652", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 8, Suit = 0, Value = 8 },
                        new { Id = "6ecad8f9-293b-432c-85be-a4d8a12e489d", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 9, Suit = 0, Value = 9 },
                        new { Id = "754c198d-8958-44f9-8fec-8734a4164e55", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 10, Suit = 0, Value = 10 },
                        new { Id = "ba30edab-b38e-4db2-a331-5b82b8491a74", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 11, Suit = 0, Value = 10 },
                        new { Id = "aefb6074-463f-48b1-9660-1d24c0fb3371", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 12, Suit = 0, Value = 10 },
                        new { Id = "bc50673c-39b0-4727-a6a7-70e36aa8f8be", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 13, Suit = 0, Value = 10 },
                        new { Id = "90317616-3edf-41a5-9f0b-e3e4f337b4c2", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 14, Suit = 0, Value = 11 },
                        new { Id = "0aa63c8a-823e-4c24-b45e-98c546f014cb", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 2, Suit = 1, Value = 2 },
                        new { Id = "d21123f4-0aa8-4e4d-b0cd-69acc76354ea", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 3, Suit = 1, Value = 3 },
                        new { Id = "9e91ede7-c269-4fa6-84cd-dee9667b9978", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 4, Suit = 1, Value = 4 },
                        new { Id = "f612eda6-dd44-49dd-b3c9-92ca0c0da2ee", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 5, Suit = 1, Value = 5 },
                        new { Id = "4dba2c14-453a-4b9a-bc70-94b9137b7b97", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 6, Suit = 1, Value = 6 },
                        new { Id = "d1f9a686-1451-4518-8976-d6a9514532ef", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 7, Suit = 1, Value = 7 },
                        new { Id = "8098ff64-e11e-4027-bc63-8c1f431a7afb", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 8, Suit = 1, Value = 8 },
                        new { Id = "19dde54c-0a58-4160-89a5-6512fb9b8ebf", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 9, Suit = 1, Value = 9 },
                        new { Id = "d34ab0dd-a28e-4206-84a5-aa3a0cde10be", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 10, Suit = 1, Value = 10 },
                        new { Id = "4e893bf1-1c04-4c6d-96d8-82b5c2bb3a99", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 11, Suit = 1, Value = 10 },
                        new { Id = "5817dba3-ceb3-4875-b788-428a24419d60", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 12, Suit = 1, Value = 10 },
                        new { Id = "3b50039a-fe8b-40ea-a92a-b3e3085f7326", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 13, Suit = 1, Value = 10 },
                        new { Id = "f3552cb7-c473-4f17-8bef-cc87f591c8d2", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 14, Suit = 1, Value = 11 },
                        new { Id = "ee5f7ebd-14f3-4fa0-9a4b-c4733d498f40", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 2, Suit = 2, Value = 2 },
                        new { Id = "7788782b-2fd1-4ee5-a617-ba27bff168a9", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 3, Suit = 2, Value = 3 },
                        new { Id = "c14be461-ae68-49db-8ad1-990f4e143d85", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 4, Suit = 2, Value = 4 },
                        new { Id = "089b2c52-e3c8-486f-bd09-a8f15a19b674", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 5, Suit = 2, Value = 5 },
                        new { Id = "ce225975-372c-44e5-b8a3-e427d678010f", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 6, Suit = 2, Value = 6 },
                        new { Id = "72f0efd2-8093-4df5-8319-bd24cae5da63", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 7, Suit = 2, Value = 7 },
                        new { Id = "86b13227-b0ed-4ef6-9c3f-0fcc2aa638a8", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 8, Suit = 2, Value = 8 },
                        new { Id = "ff233d98-b120-4417-b4ed-37e8ac1237cc", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 9, Suit = 2, Value = 9 },
                        new { Id = "a515b5b6-82c1-4894-94f6-404332c2446b", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 10, Suit = 2, Value = 10 },
                        new { Id = "811f5e90-99ae-4238-990f-7dbf732707dd", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 11, Suit = 2, Value = 10 },
                        new { Id = "0341600c-cc4a-4e9c-88bb-5e17c8233c9f", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 12, Suit = 2, Value = 10 },
                        new { Id = "9ebfa3a3-e89a-4d39-921c-cd9e36571ea0", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 13, Suit = 2, Value = 10 },
                        new { Id = "029214fe-a2ba-4eed-a2d9-d623f89ce850", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 14, Suit = 2, Value = 11 },
                        new { Id = "10d114cf-74f4-4077-8d82-f42344af95fa", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 2, Suit = 3, Value = 2 },
                        new { Id = "cdde89e1-66a8-43b5-9fad-4ce2d1028954", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 3, Suit = 3, Value = 3 },
                        new { Id = "15d66bcb-2e7c-43ac-b934-f360bd72ed4e", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 4, Suit = 3, Value = 4 },
                        new { Id = "e277c9e0-322a-42cc-ad9e-d8edd428c38d", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 5, Suit = 3, Value = 5 },
                        new { Id = "559a6b29-8261-4982-91d2-c6ae4df2476c", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 6, Suit = 3, Value = 6 },
                        new { Id = "346e3cc0-aa50-4a0c-a3a5-5a813541452e", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 7, Suit = 3, Value = 7 },
                        new { Id = "1c8638b3-1c6b-490b-aa73-b966acd1b070", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 8, Suit = 3, Value = 8 },
                        new { Id = "7a702c4e-5582-48c2-98ae-efdc76c58e84", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 9, Suit = 3, Value = 9 },
                        new { Id = "bf95eeb9-1185-4380-b9ab-26400172918f", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 10, Suit = 3, Value = 10 },
                        new { Id = "b23cb967-0ed7-4491-9323-82cc876c9cde", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 11, Suit = 3, Value = 10 },
                        new { Id = "8f575bc3-5c3b-4f54-a9a4-78d70ece79bd", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 12, Suit = 3, Value = 10 },
                        new { Id = "77f231ee-e46d-40ef-9008-a3d3dacf5c88", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 13, Suit = 3, Value = 10 },
                        new { Id = "0af28795-60ce-4738-a011-6f7430a8e345", CreationDate = new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), Rank = 14, Suit = 3, Value = 11 }
                    );
                });

            modelBuilder.Entity("BlackJackEntities.Entities.CardMove", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CardId");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("GameId");

                    b.Property<int>("Move");

                    b.Property<string>("Name");

                    b.Property<string>("PlayerId");

                    b.Property<string>("Role");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("CardMoves");
                });

            modelBuilder.Entity("BlackJackEntities.Entities.Game", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("BlackJackEntities.Entities.GameUsers", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("GameId");

                    b.Property<string>("UserId");

                    b.Property<bool>("Winner");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("GameUsers");
                });

            modelBuilder.Entity("BlackJackEntities.Entities.Player", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("GameId");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int>("Points");

                    b.Property<string>("Role");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new { Id = "426ac2bb-fed8-4d4f-9f07-c03ee09d4801", AccessFailedCount = 0, ConcurrencyStamp = "666c0c08-2686-4371-a704-e28cba9c6ae4", EmailConfirmed = false, LockoutEnabled = false, PhoneNumberConfirmed = false, Points = 0, Role = "Bot", TwoFactorEnabled = false, UserName = "Dialer" },
                        new { Id = "7327568f-9afa-4ead-b241-c03838a0bd6c", AccessFailedCount = 0, ConcurrencyStamp = "555344c1-f6ec-4492-a730-940fbd18d35b", EmailConfirmed = false, LockoutEnabled = false, PhoneNumberConfirmed = false, Points = 0, Role = "Bot", TwoFactorEnabled = false, UserName = "Bot_1" },
                        new { Id = "17e19ad6-15bc-4534-9a46-22b95c81a9bd", AccessFailedCount = 0, ConcurrencyStamp = "64be6a28-cdae-4e81-b492-1c02ec1048ad", EmailConfirmed = false, LockoutEnabled = false, PhoneNumberConfirmed = false, Points = 0, Role = "Bot", TwoFactorEnabled = false, UserName = "Bot_2" },
                        new { Id = "b75b0004-fb54-4091-bb29-3a4ff65a418f", AccessFailedCount = 0, ConcurrencyStamp = "34d6c53e-10ad-4674-858d-980d6cb82de7", EmailConfirmed = false, LockoutEnabled = false, PhoneNumberConfirmed = false, Points = 0, Role = "Bot", TwoFactorEnabled = false, UserName = "Bot_3" },
                        new { Id = "84c8f5ee-5e47-4f87-b949-9f572e0f1529", AccessFailedCount = 0, ConcurrencyStamp = "57bb9e0b-882f-4f8a-9605-1e1bd44e360f", EmailConfirmed = false, LockoutEnabled = false, PhoneNumberConfirmed = false, Points = 0, Role = "Bot", TwoFactorEnabled = false, UserName = "Bot_4" },
                        new { Id = "6755137b-f5f1-4347-8b8e-659839a10c2a", AccessFailedCount = 0, ConcurrencyStamp = "1d91b8b6-be3c-4240-a2bc-cb0c2a91aeef", EmailConfirmed = false, LockoutEnabled = false, PhoneNumberConfirmed = false, Points = 0, Role = "Bot", TwoFactorEnabled = false, UserName = "Bot_5" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BlackJackEntities.Entities.CardMove", b =>
                {
                    b.HasOne("BlackJackEntities.Entities.Game")
                        .WithMany("CardMoves")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("BlackJackEntities.Entities.GameUsers", b =>
                {
                    b.HasOne("BlackJackEntities.Entities.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId");

                    b.HasOne("BlackJackEntities.Entities.Player", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BlackJackEntities.Entities.Player", b =>
                {
                    b.HasOne("BlackJackEntities.Entities.Game")
                        .WithMany("Users")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BlackJackEntities.Entities.Player")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BlackJackEntities.Entities.Player")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlackJackEntities.Entities.Player")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BlackJackEntities.Entities.Player")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}