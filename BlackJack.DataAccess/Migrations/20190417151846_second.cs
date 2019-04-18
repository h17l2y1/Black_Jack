using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJackDataAccess.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "355e2339-9a40-47ba-8e27-8dd10ac36c6b", "6a72b196-a196-4a8d-a287-b8467076b229" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "619c90cb-936f-4219-b71c-09cb12fb28b6", "9b8c273f-081b-46ec-b482-ce82625a46e0" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "994fa2fe-5d1e-482f-a335-e3848c67af1c", "270d2ff4-07b8-4d09-a307-43550a5550c2" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "d4716ed8-4317-4d14-b232-ab9b94316f87", "dd9d3f00-8f8d-4621-84b5-7755a5c333cc" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "efd972d5-48c7-4108-a1db-68b8f2da4b9f", "a045ba98-613e-4901-83ce-bbc7cd9c218b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "f58367a9-838c-45d5-85b5-9a3bb06b57c7", "d4bc531e-73c5-41c3-a538-ae2d29eb95ab" });

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "0f7d1581-8756-4168-8061-acbab9b31d62");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "10c93468-6ffe-4add-8946-ee1521d31951");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "18a73630-53d3-4999-aaa2-94aac59e52d8");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "1ab36688-f1dc-4407-a925-950907599a61");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "1ee092e4-d576-4637-b197-b3225db5f075");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "2095c7bb-d4a6-4ba8-b4e7-5cbdfe26d6f3");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "22af53e4-cf15-448b-9570-ac7303a76163");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "24a91bf6-3394-4a10-8f4a-4fa7cf9d28e4");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "257f2e2a-67ee-40be-b9f7-95491ddb498f");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "2a837233-6209-42ad-bfbc-857dacf6f6ea");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "2d927126-1c92-4019-8826-c0d76e5939a2");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "354c1147-db40-454e-b1c9-d5ffb7f4c7b6");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "359bb766-2dfd-443f-a85a-bf0f506cf50d");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "3d2f5063-1e3d-4e1c-8a54-a69697305f40");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "519a6ff9-01a8-42e3-8473-433f5a27c4c9");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "52b2a47d-c0dd-4034-8a6c-fbd839d9dda4");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "550f4e7c-275d-41d8-97b4-c3baf6785a33");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "5574737c-9667-4b5b-8390-048b3c1599f0");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "557ef907-7a96-494f-8d6f-8d66dff933b6");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "57d3ba8c-224e-4186-815b-4ed2e45939ce");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "5af52aeb-cca6-4a25-a6e3-2bd57b485308");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "6154987a-7707-4a6f-9c93-120642309ffb");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "61aa7570-7994-47d0-9cca-67a5919522db");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "63843953-f7f0-4a80-987c-79eccd8a7baf");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "65b80328-cd8a-4693-bb45-e9c36b1ad61e");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "68987ad1-c5fb-4bad-bfab-fed9cc754b30");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "78565830-4133-4660-acdc-ef7b2f174ce5");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "78a07d9d-f1fa-423b-b4ab-33151345c56b");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "812ee75d-4e2a-4ef2-9e68-098fce6926cb");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "83be744d-8d3c-4fc0-bd4d-fccdd3b44165");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "861a5de2-02f4-4811-a973-8710ea65fb7c");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "8b028707-700e-4edd-8392-c127a0a15e15");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "9d2e4827-6dfb-4c82-9f52-52f630441572");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "9ec00cd5-79eb-4159-82a0-a82bb227f9da");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "a71086c8-fdb1-4147-96ac-cdd4594e0876");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "a79aa69d-4824-4658-a523-4c6b7e9474d6");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "b5ba4685-0ef8-426a-9ff3-b216a3e10b91");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "be240326-31e2-415c-b4f3-43648cc56d2a");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "befa2119-7490-4e4f-b144-9d33680d603a");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "bf23482e-5719-45a8-9783-eac7ef13b559");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "c232fc71-5082-472a-b265-90b96ff5729a");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "c2744c4a-dd99-468a-a1ff-663a43dcfca2");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "d0ad5d49-5201-466f-91f7-7288579b7e08");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "df6f5505-1814-479e-bacd-d84037fb4623");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "e5f54018-d490-4d8a-a067-cd3ac9c1f7b7");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "ec87ad10-e31f-4875-935b-83638330148a");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "ed2048ff-70b5-482a-91ec-51c8c549e989");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "f31b18e6-4cbf-49b9-aeb9-4008145a0392");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "f3b76664-eea1-4f96-b9d9-57b5ec36cc11");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "f4577691-d91c-4ea2-8117-793b9a0c2bc3");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "f66233aa-f690-460d-8e6b-17aaf0c8f5f4");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "fe0f539e-3d19-4a83-adaa-09503c2cc150");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "GameId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Points", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6755137b-f5f1-4347-8b8e-659839a10c2a", 0, "1d91b8b6-be3c-4240-a2bc-cb0c2a91aeef", null, false, null, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot_5" },
                    { "426ac2bb-fed8-4d4f-9f07-c03ee09d4801", 0, "666c0c08-2686-4371-a704-e28cba9c6ae4", null, false, null, false, null, null, null, null, null, false, 0, "Bot", null, false, "Dialer" },
                    { "7327568f-9afa-4ead-b241-c03838a0bd6c", 0, "555344c1-f6ec-4492-a730-940fbd18d35b", null, false, null, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot_1" },
                    { "84c8f5ee-5e47-4f87-b949-9f572e0f1529", 0, "57bb9e0b-882f-4f8a-9605-1e1bd44e360f", null, false, null, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot_4" },
                    { "b75b0004-fb54-4091-bb29-3a4ff65a418f", 0, "34d6c53e-10ad-4674-858d-980d6cb82de7", null, false, null, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot_3" },
                    { "17e19ad6-15bc-4534-9a46-22b95c81a9bd", 0, "64be6a28-cdae-4e81-b492-1c02ec1048ad", null, false, null, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot_2" }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreationDate", "Rank", "Suit", "Value" },
                values: new object[,]
                {
                    { "ce225975-372c-44e5-b8a3-e427d678010f", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 6, 2, 6 },
                    { "72f0efd2-8093-4df5-8319-bd24cae5da63", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 7, 2, 7 },
                    { "86b13227-b0ed-4ef6-9c3f-0fcc2aa638a8", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 8, 2, 8 },
                    { "ff233d98-b120-4417-b4ed-37e8ac1237cc", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 9, 2, 9 },
                    { "a515b5b6-82c1-4894-94f6-404332c2446b", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 10, 2, 10 },
                    { "811f5e90-99ae-4238-990f-7dbf732707dd", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 11, 2, 10 },
                    { "0341600c-cc4a-4e9c-88bb-5e17c8233c9f", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 12, 2, 10 },
                    { "9ebfa3a3-e89a-4d39-921c-cd9e36571ea0", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 13, 2, 10 },
                    { "029214fe-a2ba-4eed-a2d9-d623f89ce850", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 14, 2, 11 },
                    { "10d114cf-74f4-4077-8d82-f42344af95fa", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 2, 3, 2 },
                    { "cdde89e1-66a8-43b5-9fad-4ce2d1028954", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 3, 3, 3 },
                    { "089b2c52-e3c8-486f-bd09-a8f15a19b674", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 5, 2, 5 },
                    { "559a6b29-8261-4982-91d2-c6ae4df2476c", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 6, 3, 6 },
                    { "346e3cc0-aa50-4a0c-a3a5-5a813541452e", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 7, 3, 7 },
                    { "1c8638b3-1c6b-490b-aa73-b966acd1b070", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 8, 3, 8 },
                    { "7a702c4e-5582-48c2-98ae-efdc76c58e84", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 9, 3, 9 },
                    { "bf95eeb9-1185-4380-b9ab-26400172918f", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 10, 3, 10 },
                    { "b23cb967-0ed7-4491-9323-82cc876c9cde", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 11, 3, 10 },
                    { "8f575bc3-5c3b-4f54-a9a4-78d70ece79bd", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 12, 3, 10 },
                    { "77f231ee-e46d-40ef-9008-a3d3dacf5c88", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 13, 3, 10 },
                    { "0af28795-60ce-4738-a011-6f7430a8e345", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 14, 3, 11 },
                    { "15d66bcb-2e7c-43ac-b934-f360bd72ed4e", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 4, 3, 4 },
                    { "e277c9e0-322a-42cc-ad9e-d8edd428c38d", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 5, 3, 5 },
                    { "c14be461-ae68-49db-8ad1-990f4e143d85", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 4, 2, 4 },
                    { "ee5f7ebd-14f3-4fa0-9a4b-c4733d498f40", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 2, 2, 2 },
                    { "76e9278d-481a-449d-85f4-b25e00f2c0a9", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 3, 0, 3 },
                    { "ace8643e-4ade-4e36-abc0-e4cb044adee0", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 4, 0, 4 },
                    { "0ed44dcb-a3cb-4b37-89c4-fd7ab5293969", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 5, 0, 5 },
                    { "609f3dae-ece1-49eb-b787-870e909b2d8c", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 6, 0, 6 },
                    { "2e158ada-93e8-40f2-9336-56e9ab3192ad", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 7, 0, 7 },
                    { "74d53c93-f6cf-4676-af88-917a5baca652", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 8, 0, 8 },
                    { "6ecad8f9-293b-432c-85be-a4d8a12e489d", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 9, 0, 9 },
                    { "754c198d-8958-44f9-8fec-8734a4164e55", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 10, 0, 10 },
                    { "ba30edab-b38e-4db2-a331-5b82b8491a74", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 11, 0, 10 },
                    { "aefb6074-463f-48b1-9660-1d24c0fb3371", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 12, 0, 10 },
                    { "bc50673c-39b0-4727-a6a7-70e36aa8f8be", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 13, 0, 10 },
                    { "90317616-3edf-41a5-9f0b-e3e4f337b4c2", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 14, 0, 11 },
                    { "0aa63c8a-823e-4c24-b45e-98c546f014cb", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 2, 1, 2 },
                    { "d21123f4-0aa8-4e4d-b0cd-69acc76354ea", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 3, 1, 3 },
                    { "9e91ede7-c269-4fa6-84cd-dee9667b9978", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 4, 1, 4 },
                    { "f612eda6-dd44-49dd-b3c9-92ca0c0da2ee", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 5, 1, 5 },
                    { "4dba2c14-453a-4b9a-bc70-94b9137b7b97", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 6, 1, 6 },
                    { "d1f9a686-1451-4518-8976-d6a9514532ef", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 7, 1, 7 },
                    { "8098ff64-e11e-4027-bc63-8c1f431a7afb", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 8, 1, 8 },
                    { "19dde54c-0a58-4160-89a5-6512fb9b8ebf", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 9, 1, 9 },
                    { "d34ab0dd-a28e-4206-84a5-aa3a0cde10be", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 10, 1, 10 },
                    { "4e893bf1-1c04-4c6d-96d8-82b5c2bb3a99", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 11, 1, 10 },
                    { "5817dba3-ceb3-4875-b788-428a24419d60", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 12, 1, 10 },
                    { "3b50039a-fe8b-40ea-a92a-b3e3085f7326", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 13, 1, 10 },
                    { "f3552cb7-c473-4f17-8bef-cc87f591c8d2", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 14, 1, 11 },
                    { "7788782b-2fd1-4ee5-a617-ba27bff168a9", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 3, 2, 3 },
                    { "11837808-917b-40c9-9453-34038b5bd54a", new DateTime(2019, 4, 17, 15, 18, 45, 793, DateTimeKind.Utc), 2, 0, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "17e19ad6-15bc-4534-9a46-22b95c81a9bd", "64be6a28-cdae-4e81-b492-1c02ec1048ad" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "426ac2bb-fed8-4d4f-9f07-c03ee09d4801", "666c0c08-2686-4371-a704-e28cba9c6ae4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "6755137b-f5f1-4347-8b8e-659839a10c2a", "1d91b8b6-be3c-4240-a2bc-cb0c2a91aeef" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "7327568f-9afa-4ead-b241-c03838a0bd6c", "555344c1-f6ec-4492-a730-940fbd18d35b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "84c8f5ee-5e47-4f87-b949-9f572e0f1529", "57bb9e0b-882f-4f8a-9605-1e1bd44e360f" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "b75b0004-fb54-4091-bb29-3a4ff65a418f", "34d6c53e-10ad-4674-858d-980d6cb82de7" });

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "029214fe-a2ba-4eed-a2d9-d623f89ce850");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "0341600c-cc4a-4e9c-88bb-5e17c8233c9f");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "089b2c52-e3c8-486f-bd09-a8f15a19b674");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "0aa63c8a-823e-4c24-b45e-98c546f014cb");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "0af28795-60ce-4738-a011-6f7430a8e345");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "0ed44dcb-a3cb-4b37-89c4-fd7ab5293969");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "10d114cf-74f4-4077-8d82-f42344af95fa");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "11837808-917b-40c9-9453-34038b5bd54a");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "15d66bcb-2e7c-43ac-b934-f360bd72ed4e");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "19dde54c-0a58-4160-89a5-6512fb9b8ebf");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "1c8638b3-1c6b-490b-aa73-b966acd1b070");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "2e158ada-93e8-40f2-9336-56e9ab3192ad");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "346e3cc0-aa50-4a0c-a3a5-5a813541452e");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "3b50039a-fe8b-40ea-a92a-b3e3085f7326");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "4dba2c14-453a-4b9a-bc70-94b9137b7b97");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "4e893bf1-1c04-4c6d-96d8-82b5c2bb3a99");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "559a6b29-8261-4982-91d2-c6ae4df2476c");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "5817dba3-ceb3-4875-b788-428a24419d60");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "609f3dae-ece1-49eb-b787-870e909b2d8c");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "6ecad8f9-293b-432c-85be-a4d8a12e489d");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "72f0efd2-8093-4df5-8319-bd24cae5da63");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "74d53c93-f6cf-4676-af88-917a5baca652");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "754c198d-8958-44f9-8fec-8734a4164e55");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "76e9278d-481a-449d-85f4-b25e00f2c0a9");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "7788782b-2fd1-4ee5-a617-ba27bff168a9");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "77f231ee-e46d-40ef-9008-a3d3dacf5c88");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "7a702c4e-5582-48c2-98ae-efdc76c58e84");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "8098ff64-e11e-4027-bc63-8c1f431a7afb");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "811f5e90-99ae-4238-990f-7dbf732707dd");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "86b13227-b0ed-4ef6-9c3f-0fcc2aa638a8");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "8f575bc3-5c3b-4f54-a9a4-78d70ece79bd");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "90317616-3edf-41a5-9f0b-e3e4f337b4c2");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "9e91ede7-c269-4fa6-84cd-dee9667b9978");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "9ebfa3a3-e89a-4d39-921c-cd9e36571ea0");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "a515b5b6-82c1-4894-94f6-404332c2446b");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "ace8643e-4ade-4e36-abc0-e4cb044adee0");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "aefb6074-463f-48b1-9660-1d24c0fb3371");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "b23cb967-0ed7-4491-9323-82cc876c9cde");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "ba30edab-b38e-4db2-a331-5b82b8491a74");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "bc50673c-39b0-4727-a6a7-70e36aa8f8be");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "bf95eeb9-1185-4380-b9ab-26400172918f");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "c14be461-ae68-49db-8ad1-990f4e143d85");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "cdde89e1-66a8-43b5-9fad-4ce2d1028954");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "ce225975-372c-44e5-b8a3-e427d678010f");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "d1f9a686-1451-4518-8976-d6a9514532ef");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "d21123f4-0aa8-4e4d-b0cd-69acc76354ea");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "d34ab0dd-a28e-4206-84a5-aa3a0cde10be");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "e277c9e0-322a-42cc-ad9e-d8edd428c38d");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "ee5f7ebd-14f3-4fa0-9a4b-c4733d498f40");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "f3552cb7-c473-4f17-8bef-cc87f591c8d2");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "f612eda6-dd44-49dd-b3c9-92ca0c0da2ee");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "ff233d98-b120-4417-b4ed-37e8ac1237cc");

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
        }
    }
}
