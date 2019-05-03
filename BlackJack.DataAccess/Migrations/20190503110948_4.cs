using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackJackDataAccess.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "1677d9be-2bce-4e8c-abf7-5de09cf120b7", "241c5e24-26af-403e-83dd-19cdf3ec1433" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "213e2492-206a-48ed-b15a-98c5ae37f56f", "798f5297-4469-4378-b713-830ae0870f6f" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "6231bae7-1dbc-481c-8c8b-61eb65bbb033", "61f627d5-2b67-4fe2-80ee-bac6f2d5f01c" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "96cff5f5-a5ff-4221-b092-af75f285c11d", "e28a3b29-9395-476a-b94f-20ed6261505a" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "9e44c64e-253b-4380-8614-5ea980a9a15e", "6aefdadb-cf82-43df-8c22-c0119f50eb64" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "f3187f1f-11e1-43b8-a325-e9fa55f17f1d", "82130375-0af2-4138-93a8-cab7778dc854" });

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "016cd863-d822-4b94-9f3b-641136d54147");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "0313d8ee-1bfb-407e-bb9c-b5bc2e8bce61");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "03385249-0850-4f31-8430-7cfe9776c413");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "07cf640c-8cc0-4c27-b3f3-363266884a77");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "0b76220f-d272-4451-8a86-5cc309675868");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "0d7a8dc1-48ba-4101-a717-8784504189ec");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "13211bda-9433-4359-82b6-2a1386862be9");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "183aee33-0edc-4271-8b4c-55792e1a0a95");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "220fb2fe-130b-49fa-9049-7010c176cd88");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "2734122f-bfab-46de-984b-c997f685ac9f");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "2760d586-cba1-4c9b-b7c4-37127624451f");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "2e62dc7b-f27e-43d8-83b1-5101c7298a0a");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "3b03cb17-99a3-4c29-9bd2-2f05674b51fd");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "4abbee34-a74b-4010-a9b5-de2dd789a4b3");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "4f3dc1e8-7679-4833-8718-f7a7558956dc");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "62f5f52d-2d86-497e-9894-438032b13c19");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "682e200c-ccaa-47ce-b5f9-d3648807b646");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "725e0fb2-4562-4ced-8a23-144ec764bb6c");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "73db7fc5-3962-4caa-aa7a-852b1965f50c");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "7cd71526-b453-4ffd-b210-30b98de5fb0e");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "82166159-25cb-4017-85fc-3470fcf3d0d0");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "83503fef-8c8e-47c9-af61-82310849ac0b");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "8b33c185-e886-4ca4-895c-652dca229503");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "9071879a-f4a6-49ef-9ba3-2c556723a0be");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "925f26ba-b4c3-40f8-b41b-53504c3d52c4");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "9442224b-1987-4927-aada-2265a344b301");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "9cb2c30b-a1d3-461a-9966-f5f6e0704b54");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "9d16ca36-0e50-466d-9605-3f88dbb89a12");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "9d31f8e7-4569-49d9-a606-6e09ef301d3f");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "aa4fbf3f-6e0e-4158-b09c-7c78e2dd9b29");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "acedcbf1-6715-41bb-a5fb-2ca7cea41a46");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "ad626c66-3962-4fcf-ae10-f0775b5ce12b");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "b588cc82-cab1-498f-9eb5-345216ee7c39");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "b7237f13-2a51-4a2b-8541-4c6e19072116");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "c9f3d383-517e-48ee-a642-7be71ad8fb1d");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "ca3163cd-c38a-4adc-be77-57741984874a");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "cac0313f-f4ba-44f3-99bb-cebf6baed131");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "cdc629f5-59df-43f4-adf6-0f1164bf5cda");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "cfb7b785-0fb6-4a06-a58c-3a9546b4128e");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "d0e69e4e-5906-4c4f-97e2-86a8874acb4f");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "d678eadb-3326-4d01-b67d-263281ec2f82");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "d6ccb5f7-631a-4234-aee3-820a511dfede");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "dc5ae2aa-6f0e-44df-84d3-94e845c49fdf");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "dc9ce879-da98-4730-a651-a3b7e68554a3");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "dcf11dc4-a16a-407b-a1f9-05c9d48823ac");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "ec4820a7-57d6-49a2-92b2-27782f53966a");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "ece9cfd8-eaa4-4cf1-af40-3b251257c733");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "ed6592a1-06ef-4681-b55f-f8e1cf6aef70");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "ee9822e9-889f-4ed6-9a15-5160af519855");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "f3c85447-4275-44ce-832c-8ba6a43f08bf");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "f7963ab1-d89e-4242-9810-d6e25d5097be");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "fc2afcfd-d651-4648-8f80-92c8c7ca9169");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "GameId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Points", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "61ff1e4f-c2e1-445f-a73d-202faa0a63b3", 0, "3357c1a8-2b6c-41eb-ac52-b15a051a5a13", null, false, null, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot_5" },
                    { "902b4491-3125-4582-b44b-21c40b20d119", 0, "07902417-3781-405d-9d6b-4ffd0bdfac18", null, false, null, false, null, null, null, null, null, false, 0, "Dialer", null, false, "Dialer" },
                    { "4e4ad55c-113e-4d6f-93ba-444546fc2f0e", 0, "a2399833-97c3-46fc-9819-35df997f0174", null, false, null, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot_1" },
                    { "a0a62938-90ad-4f50-ac00-3239c1922c1f", 0, "67ed0d13-48ee-489c-93a5-d8a33ced2dcc", null, false, null, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot_4" },
                    { "c79b07a7-fdb3-4be7-89b6-3c41bf784496", 0, "c8e7252c-6c27-443b-a9e4-c4a499ba2465", null, false, null, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot_3" },
                    { "5ce94ddd-e8a9-4429-bd90-4beb1b1251b8", 0, "6f4ad332-b0dc-4c3f-b6fd-fcb48b89083a", null, false, null, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot_2" }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreationDate", "Rank", "Suit", "Value" },
                values: new object[,]
                {
                    { "c5461301-7df8-4322-b746-342659e2a326", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 6, 2, 6 },
                    { "1f137cf3-7479-449a-b81a-695f9aa11d7a", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 7, 2, 7 },
                    { "0294bb7b-40a8-4abd-8503-71ddf98a9524", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 8, 2, 8 },
                    { "46ff0db0-aaa6-440a-bfcb-a5015de7ad8c", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 9, 2, 9 },
                    { "f052adec-3d8d-4cb5-85b6-8b794e5d7b1c", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 10, 2, 10 },
                    { "1db6dded-5f90-437b-a950-fa99b8fa78e7", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 11, 2, 10 },
                    { "7788f1ad-8b54-4e33-8ba4-26644f18623b", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 12, 2, 10 },
                    { "a53ab068-92be-48a0-b1ac-ac234b127dde", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 13, 2, 10 },
                    { "c077f299-50c4-4244-a038-6d8b2085f907", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 14, 2, 11 },
                    { "63e0c30d-fc93-49e0-ab8c-ac04af3f1de7", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 2, 3, 2 },
                    { "d8059eae-aa86-4fd5-8e75-5c43809477f5", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 3, 3, 3 },
                    { "ff4db707-e0b2-406b-a495-1468295dcc69", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 5, 2, 5 },
                    { "05b989ad-2255-4e3a-8cfe-a66cf001a1fb", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 6, 3, 6 },
                    { "72ed587e-6757-4458-8f69-fc2876dfab18", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 7, 3, 7 },
                    { "769aafdc-c3ff-4c25-9910-bf6c1b952464", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 8, 3, 8 },
                    { "ee180885-9d44-4500-87ca-fd28f2cb7f0c", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 9, 3, 9 },
                    { "03b3f160-3cf1-4036-9df1-864259768549", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 10, 3, 10 },
                    { "cfa1734f-3e99-4829-895b-c69e2f2d85c1", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 11, 3, 10 },
                    { "390bf1ce-eac3-4451-a5f6-acad3c6cb360", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 12, 3, 10 },
                    { "cadcef8f-75b7-4466-b5cb-822299f77f2a", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 13, 3, 10 },
                    { "106ba086-f9ba-4349-a348-1ecfe017a136", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 14, 3, 11 },
                    { "7e05b32f-b455-4ca2-b119-1db56b1b3648", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 4, 3, 4 },
                    { "69f1a812-390b-47c6-9ecf-79c7da0ae393", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 5, 3, 5 },
                    { "e81270f9-f68f-4087-bf39-c6f6954586ab", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 4, 2, 4 },
                    { "9f0fe991-d500-4dae-b5fb-9fd688d21b19", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 2, 2, 2 },
                    { "e7b0295e-c795-4bc4-936c-949e597eeaaa", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 3, 0, 3 },
                    { "7315df62-eb0e-499f-9273-ce289b6889f1", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 4, 0, 4 },
                    { "8e481833-6bfe-4d3f-ade2-e2682f486ded", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 5, 0, 5 },
                    { "842d5ebc-f5f1-4a1c-b5c1-0eefa6715e6a", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 6, 0, 6 },
                    { "5fd9da8b-131f-4185-80b6-a5da21a35706", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 7, 0, 7 },
                    { "6fbfe63d-ac9e-4313-8e60-c31ad032fecc", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 8, 0, 8 },
                    { "e8b9dfd9-83da-4a1a-b720-f11e1e0b93c9", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 9, 0, 9 },
                    { "99f48b8d-e96a-4410-830c-e6cee5036a1a", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 10, 0, 10 },
                    { "07401364-d463-4bca-9b2b-59ff6d935bdc", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 11, 0, 10 },
                    { "3685a208-039c-4dec-9c96-0cc2187a98a5", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 12, 0, 10 },
                    { "19b92e6c-1f67-4472-8e3c-da0ee9c716ce", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 13, 0, 10 },
                    { "65d28502-e792-4975-b9c3-f99e06d4f213", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 14, 0, 11 },
                    { "e3034d9c-3054-49ac-9770-81235aafec3e", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 2, 1, 2 },
                    { "d476bb4d-76f3-49a2-8052-19d55fe2288c", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 3, 1, 3 },
                    { "2356316a-13a3-46e8-8d68-b24a3dc9e7b0", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 4, 1, 4 },
                    { "487c3f45-2f35-444b-9dc5-c5137a849696", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 5, 1, 5 },
                    { "16bb2e5f-78c1-4aad-9fd7-c11a0de61a06", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 6, 1, 6 },
                    { "a5249abe-182f-475e-b168-86ccbb5d042b", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 7, 1, 7 },
                    { "6b21f171-278a-4722-b83d-a252e81a4c94", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 8, 1, 8 },
                    { "973f2d29-d048-4c0e-b640-e54d1ef06395", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 9, 1, 9 },
                    { "a62fcded-4006-460a-89b4-e7d2df31f20f", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 10, 1, 10 },
                    { "2e53c03c-9079-4e36-9843-be0d6c5b6d05", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 11, 1, 10 },
                    { "22bd67d0-560d-45b3-bccd-8157264a5b0d", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 12, 1, 10 },
                    { "3c54138d-10ba-45fd-8820-3045cc9f1442", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 13, 1, 10 },
                    { "ced1fb38-e1d3-47a3-bca9-c851beb5f9dc", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 14, 1, 11 },
                    { "36965bc9-aaec-4d5e-aa1c-7cc6324de848", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 3, 2, 3 },
                    { "a4c192d6-b0de-4423-83dc-eb63a4e06411", new DateTime(2019, 5, 3, 11, 9, 48, 347, DateTimeKind.Utc), 2, 0, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "4e4ad55c-113e-4d6f-93ba-444546fc2f0e", "a2399833-97c3-46fc-9819-35df997f0174" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "5ce94ddd-e8a9-4429-bd90-4beb1b1251b8", "6f4ad332-b0dc-4c3f-b6fd-fcb48b89083a" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "61ff1e4f-c2e1-445f-a73d-202faa0a63b3", "3357c1a8-2b6c-41eb-ac52-b15a051a5a13" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "902b4491-3125-4582-b44b-21c40b20d119", "07902417-3781-405d-9d6b-4ffd0bdfac18" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "a0a62938-90ad-4f50-ac00-3239c1922c1f", "67ed0d13-48ee-489c-93a5-d8a33ced2dcc" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "c79b07a7-fdb3-4be7-89b6-3c41bf784496", "c8e7252c-6c27-443b-a9e4-c4a499ba2465" });

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "0294bb7b-40a8-4abd-8503-71ddf98a9524");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "03b3f160-3cf1-4036-9df1-864259768549");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "05b989ad-2255-4e3a-8cfe-a66cf001a1fb");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "07401364-d463-4bca-9b2b-59ff6d935bdc");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "106ba086-f9ba-4349-a348-1ecfe017a136");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "16bb2e5f-78c1-4aad-9fd7-c11a0de61a06");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "19b92e6c-1f67-4472-8e3c-da0ee9c716ce");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "1db6dded-5f90-437b-a950-fa99b8fa78e7");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "1f137cf3-7479-449a-b81a-695f9aa11d7a");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "22bd67d0-560d-45b3-bccd-8157264a5b0d");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "2356316a-13a3-46e8-8d68-b24a3dc9e7b0");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "2e53c03c-9079-4e36-9843-be0d6c5b6d05");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "3685a208-039c-4dec-9c96-0cc2187a98a5");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "36965bc9-aaec-4d5e-aa1c-7cc6324de848");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "390bf1ce-eac3-4451-a5f6-acad3c6cb360");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "3c54138d-10ba-45fd-8820-3045cc9f1442");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "46ff0db0-aaa6-440a-bfcb-a5015de7ad8c");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "487c3f45-2f35-444b-9dc5-c5137a849696");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "5fd9da8b-131f-4185-80b6-a5da21a35706");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "63e0c30d-fc93-49e0-ab8c-ac04af3f1de7");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "65d28502-e792-4975-b9c3-f99e06d4f213");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "69f1a812-390b-47c6-9ecf-79c7da0ae393");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "6b21f171-278a-4722-b83d-a252e81a4c94");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "6fbfe63d-ac9e-4313-8e60-c31ad032fecc");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "72ed587e-6757-4458-8f69-fc2876dfab18");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "7315df62-eb0e-499f-9273-ce289b6889f1");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "769aafdc-c3ff-4c25-9910-bf6c1b952464");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "7788f1ad-8b54-4e33-8ba4-26644f18623b");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "7e05b32f-b455-4ca2-b119-1db56b1b3648");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "842d5ebc-f5f1-4a1c-b5c1-0eefa6715e6a");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "8e481833-6bfe-4d3f-ade2-e2682f486ded");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "973f2d29-d048-4c0e-b640-e54d1ef06395");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "99f48b8d-e96a-4410-830c-e6cee5036a1a");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "9f0fe991-d500-4dae-b5fb-9fd688d21b19");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "a4c192d6-b0de-4423-83dc-eb63a4e06411");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "a5249abe-182f-475e-b168-86ccbb5d042b");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "a53ab068-92be-48a0-b1ac-ac234b127dde");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "a62fcded-4006-460a-89b4-e7d2df31f20f");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "c077f299-50c4-4244-a038-6d8b2085f907");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "c5461301-7df8-4322-b746-342659e2a326");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "cadcef8f-75b7-4466-b5cb-822299f77f2a");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "ced1fb38-e1d3-47a3-bca9-c851beb5f9dc");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "cfa1734f-3e99-4829-895b-c69e2f2d85c1");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "d476bb4d-76f3-49a2-8052-19d55fe2288c");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "d8059eae-aa86-4fd5-8e75-5c43809477f5");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "e3034d9c-3054-49ac-9770-81235aafec3e");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "e7b0295e-c795-4bc4-936c-949e597eeaaa");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "e81270f9-f68f-4087-bf39-c6f6954586ab");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "e8b9dfd9-83da-4a1a-b720-f11e1e0b93c9");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "ee180885-9d44-4500-87ca-fd28f2cb7f0c");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "f052adec-3d8d-4cb5-85b6-8b794e5d7b1c");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: "ff4db707-e0b2-406b-a495-1468295dcc69");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "GameId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Points", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "f3187f1f-11e1-43b8-a325-e9fa55f17f1d", 0, "82130375-0af2-4138-93a8-cab7778dc854", null, false, null, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot_5" },
                    { "213e2492-206a-48ed-b15a-98c5ae37f56f", 0, "798f5297-4469-4378-b713-830ae0870f6f", null, false, null, false, null, null, null, null, null, false, 0, "Dialer", null, false, "Dialer" },
                    { "9e44c64e-253b-4380-8614-5ea980a9a15e", 0, "6aefdadb-cf82-43df-8c22-c0119f50eb64", null, false, null, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot_1" },
                    { "96cff5f5-a5ff-4221-b092-af75f285c11d", 0, "e28a3b29-9395-476a-b94f-20ed6261505a", null, false, null, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot_4" },
                    { "6231bae7-1dbc-481c-8c8b-61eb65bbb033", 0, "61f627d5-2b67-4fe2-80ee-bac6f2d5f01c", null, false, null, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot_3" },
                    { "1677d9be-2bce-4e8c-abf7-5de09cf120b7", 0, "241c5e24-26af-403e-83dd-19cdf3ec1433", null, false, null, false, null, null, null, null, null, false, 0, "Bot", null, false, "Bot_2" }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CreationDate", "Rank", "Suit", "Value" },
                values: new object[,]
                {
                    { "cac0313f-f4ba-44f3-99bb-cebf6baed131", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 6, 2, 6 },
                    { "c9f3d383-517e-48ee-a642-7be71ad8fb1d", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 7, 2, 7 },
                    { "925f26ba-b4c3-40f8-b41b-53504c3d52c4", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 8, 2, 8 },
                    { "d678eadb-3326-4d01-b67d-263281ec2f82", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 9, 2, 9 },
                    { "fc2afcfd-d651-4648-8f80-92c8c7ca9169", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 10, 2, 10 },
                    { "2e62dc7b-f27e-43d8-83b1-5101c7298a0a", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 11, 2, 10 },
                    { "ed6592a1-06ef-4681-b55f-f8e1cf6aef70", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 12, 2, 10 },
                    { "ca3163cd-c38a-4adc-be77-57741984874a", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 13, 2, 10 },
                    { "82166159-25cb-4017-85fc-3470fcf3d0d0", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 14, 2, 11 },
                    { "3b03cb17-99a3-4c29-9bd2-2f05674b51fd", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 2, 3, 2 },
                    { "9d31f8e7-4569-49d9-a606-6e09ef301d3f", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 3, 3, 3 },
                    { "4abbee34-a74b-4010-a9b5-de2dd789a4b3", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 5, 2, 5 },
                    { "9cb2c30b-a1d3-461a-9966-f5f6e0704b54", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 6, 3, 6 },
                    { "cdc629f5-59df-43f4-adf6-0f1164bf5cda", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 7, 3, 7 },
                    { "4f3dc1e8-7679-4833-8718-f7a7558956dc", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 8, 3, 8 },
                    { "ec4820a7-57d6-49a2-92b2-27782f53966a", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 9, 3, 9 },
                    { "9442224b-1987-4927-aada-2265a344b301", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 10, 3, 10 },
                    { "ee9822e9-889f-4ed6-9a15-5160af519855", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 11, 3, 10 },
                    { "acedcbf1-6715-41bb-a5fb-2ca7cea41a46", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 12, 3, 10 },
                    { "83503fef-8c8e-47c9-af61-82310849ac0b", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 13, 3, 10 },
                    { "62f5f52d-2d86-497e-9894-438032b13c19", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 14, 3, 11 },
                    { "f7963ab1-d89e-4242-9810-d6e25d5097be", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 4, 3, 4 },
                    { "9d16ca36-0e50-466d-9605-3f88dbb89a12", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 5, 3, 5 },
                    { "183aee33-0edc-4271-8b4c-55792e1a0a95", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 4, 2, 4 },
                    { "dc5ae2aa-6f0e-44df-84d3-94e845c49fdf", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 2, 2, 2 },
                    { "d6ccb5f7-631a-4234-aee3-820a511dfede", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 3, 0, 3 },
                    { "ece9cfd8-eaa4-4cf1-af40-3b251257c733", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 4, 0, 4 },
                    { "9071879a-f4a6-49ef-9ba3-2c556723a0be", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 5, 0, 5 },
                    { "cfb7b785-0fb6-4a06-a58c-3a9546b4128e", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 6, 0, 6 },
                    { "13211bda-9433-4359-82b6-2a1386862be9", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 7, 0, 7 },
                    { "dcf11dc4-a16a-407b-a1f9-05c9d48823ac", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 8, 0, 8 },
                    { "7cd71526-b453-4ffd-b210-30b98de5fb0e", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 9, 0, 9 },
                    { "016cd863-d822-4b94-9f3b-641136d54147", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 10, 0, 10 },
                    { "aa4fbf3f-6e0e-4158-b09c-7c78e2dd9b29", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 11, 0, 10 },
                    { "07cf640c-8cc0-4c27-b3f3-363266884a77", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 12, 0, 10 },
                    { "0d7a8dc1-48ba-4101-a717-8784504189ec", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 13, 0, 10 },
                    { "ad626c66-3962-4fcf-ae10-f0775b5ce12b", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 14, 0, 11 },
                    { "220fb2fe-130b-49fa-9049-7010c176cd88", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 2, 1, 2 },
                    { "03385249-0850-4f31-8430-7cfe9776c413", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 3, 1, 3 },
                    { "dc9ce879-da98-4730-a651-a3b7e68554a3", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 4, 1, 4 },
                    { "d0e69e4e-5906-4c4f-97e2-86a8874acb4f", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 5, 1, 5 },
                    { "0b76220f-d272-4451-8a86-5cc309675868", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 6, 1, 6 },
                    { "2760d586-cba1-4c9b-b7c4-37127624451f", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 7, 1, 7 },
                    { "b7237f13-2a51-4a2b-8541-4c6e19072116", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 8, 1, 8 },
                    { "682e200c-ccaa-47ce-b5f9-d3648807b646", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 9, 1, 9 },
                    { "f3c85447-4275-44ce-832c-8ba6a43f08bf", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 10, 1, 10 },
                    { "2734122f-bfab-46de-984b-c997f685ac9f", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 11, 1, 10 },
                    { "73db7fc5-3962-4caa-aa7a-852b1965f50c", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 12, 1, 10 },
                    { "0313d8ee-1bfb-407e-bb9c-b5bc2e8bce61", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 13, 1, 10 },
                    { "725e0fb2-4562-4ced-8a23-144ec764bb6c", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 14, 1, 11 },
                    { "8b33c185-e886-4ca4-895c-652dca229503", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 3, 2, 3 },
                    { "b588cc82-cab1-498f-9eb5-345216ee7c39", new DateTime(2019, 5, 3, 10, 4, 0, 255, DateTimeKind.Utc), 2, 0, 2 }
                });
        }
    }
}
