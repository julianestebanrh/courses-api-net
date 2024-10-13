using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MasterNet.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPublicIdToPhotographyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56122853-5f34-4788-b5f5-da50a7d7921a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdd6c149-35a5-413f-9c7e-bbba8f1e95eb");

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("32c68914-403f-4674-8ea5-e4bd8955fa79"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("3cf102fa-6078-4070-a414-e5c155edbbd6"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("58ddf938-1537-446a-b1bc-eb74aae61a5f"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("5cacea8e-9122-46fd-9371-e959a71b57f6"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("6923ea34-96df-4be4-bef5-10e35d9eb625"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("92bfb7cc-7cfd-4c53-b0ed-fa54066f18d2"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("a741be99-13e1-4ab3-9872-427c64a89b50"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("c538f574-4085-4d42-8685-4d01e89e6892"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("fd3c9984-bc74-4570-a290-b7ddf07d31bc"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("25e05355-05d1-4c09-bac1-d790e1cd525d"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("2dfb48e9-e12c-4dde-8bee-e89558ac105e"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("97c265f8-b103-4ad5-a99d-1dc62326be79"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("98159134-a052-40dd-97dd-0ea11177a427"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("b0198212-471c-4e92-8a1a-9a16dfd3ee96"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("c9688457-eb30-492b-9429-c5d68fc81ba7"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("cb960cae-d104-42b4-a8a1-166ef0208b36"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("d8c59844-fbf8-4407-8d6d-95de53968477"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("f47aa02a-0a72-4ef2-b709-a24f707fa4b6"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("fa7073fa-a4ae-4543-b930-0a879816da66"));

            migrationBuilder.DeleteData(
                table: "prices",
                keyColumn: "Id",
                keyValue: new Guid("05f70543-50af-455f-bbe9-32f5aacea7cf"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "photographies",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "photographies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleId",
                value: "0d0b7eed-f632-404a-ab1d-03d7404529d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleId",
                value: "0d0b7eed-f632-404a-ab1d-03d7404529d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoleId",
                value: "0d0b7eed-f632-404a-ab1d-03d7404529d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4,
                column: "RoleId",
                value: "0d0b7eed-f632-404a-ab1d-03d7404529d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5,
                column: "RoleId",
                value: "0d0b7eed-f632-404a-ab1d-03d7404529d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6,
                column: "RoleId",
                value: "0d0b7eed-f632-404a-ab1d-03d7404529d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7,
                column: "RoleId",
                value: "0d0b7eed-f632-404a-ab1d-03d7404529d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8,
                column: "RoleId",
                value: "0d0b7eed-f632-404a-ab1d-03d7404529d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9,
                column: "RoleId",
                value: "0d0b7eed-f632-404a-ab1d-03d7404529d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10,
                column: "RoleId",
                value: "0d0b7eed-f632-404a-ab1d-03d7404529d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11,
                column: "RoleId",
                value: "222ef28c-b46e-4915-984c-0c1733690a4f");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12,
                column: "RoleId",
                value: "222ef28c-b46e-4915-984c-0c1733690a4f");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13,
                column: "RoleId",
                value: "222ef28c-b46e-4915-984c-0c1733690a4f");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14,
                column: "RoleId",
                value: "222ef28c-b46e-4915-984c-0c1733690a4f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d0b7eed-f632-404a-ab1d-03d7404529d5", null, "ADMIN", "ADMIN" },
                    { "222ef28c-b46e-4915-984c-0c1733690a4f", null, "CLIENT", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "Id", "Description", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { new Guid("019f0c3c-b57e-4a0d-9d3e-1e8ce37c614f"), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", new DateTime(2024, 5, 26, 16, 47, 8, 367, DateTimeKind.Local).AddTicks(680), "Handcrafted Concrete Sausages" },
                    { new Guid("2eae9249-cedf-4755-b566-e84670f5cec0"), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(2024, 5, 26, 16, 47, 8, 367, DateTimeKind.Local).AddTicks(816), "Sleek Rubber Chicken" },
                    { new Guid("4f18579c-2676-4841-b870-e5c4ceac44d8"), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new DateTime(2024, 5, 26, 16, 47, 8, 367, DateTimeKind.Local).AddTicks(869), "Tasty Concrete Pants" },
                    { new Guid("56c33824-8943-4cc3-91c4-e5f32d43d9bd"), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(2024, 5, 26, 16, 47, 8, 367, DateTimeKind.Local).AddTicks(585), "Awesome Frozen Tuna" },
                    { new Guid("70f496d8-0ac8-4283-a49e-c8513724d046"), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", new DateTime(2024, 5, 26, 16, 47, 8, 367, DateTimeKind.Local).AddTicks(790), "Awesome Wooden Soap" },
                    { new Guid("75f79db8-463e-4324-8dea-111b3b33165f"), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", new DateTime(2024, 5, 26, 16, 47, 8, 367, DateTimeKind.Local).AddTicks(643), "Refined Fresh Mouse" },
                    { new Guid("76e79089-e80a-4bc9-9d3a-4f34217b54d4"), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", new DateTime(2024, 5, 26, 16, 47, 8, 367, DateTimeKind.Local).AddTicks(738), "Handmade Granite Bike" },
                    { new Guid("77834ca3-6ea0-4297-ac93-c6045d59f535"), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", new DateTime(2024, 5, 26, 16, 47, 8, 367, DateTimeKind.Local).AddTicks(707), "Sleek Concrete Sausages" },
                    { new Guid("b767eb62-5a67-4730-b3e2-d644efa9f94b"), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(2024, 5, 26, 16, 47, 8, 367, DateTimeKind.Local).AddTicks(844), "Rustic Concrete Chips" }
                });

            migrationBuilder.InsertData(
                table: "instructors",
                columns: new[] { "Id", "Degree", "Names", "Surnames" },
                values: new object[,]
                {
                    { new Guid("145e5234-3c55-48c3-b2f7-36049b8c5bb3"), "Product Paradigm Supervisor", "Royal", "Jacobi" },
                    { new Guid("2400ab9d-5d66-4f9e-8617-8ddbb9f60c17"), "Senior Division Technician", "Rosario", "Hintz" },
                    { new Guid("4b916b2d-ee5c-4eab-892d-45755e70243f"), "Lead Data Consultant", "Milton", "Cummerata" },
                    { new Guid("5b20bf3e-2ffb-4907-ba1e-e55a52ccb967"), "Future Implementation Liaison", "Dulce", "Cummerata" },
                    { new Guid("6b384928-36ff-41b9-a02b-471937f478e5"), "District Functionality Manager", "Francis", "Wintheiser" },
                    { new Guid("6e310f34-849d-45cd-8918-ed43cb15474b"), "Direct Program Technician", "Ervin", "Zboncak" },
                    { new Guid("a374f114-0c05-4031-bdd3-5bb1da0f61a8"), "Internal Brand Manager", "Ruby", "Harber" },
                    { new Guid("c0c73065-abab-475e-85f5-a0b9fac12ae7"), "Lead Quality Officer", "Kaleigh", "Murphy" },
                    { new Guid("c2013b6c-0563-4195-b52f-78e6aad7e13e"), "National Configuration Administrator", "Alize", "Schinner" },
                    { new Guid("facf9a25-4b89-49d7-92b3-da1caa63970d"), "Global Interactions Developer", "Alena", "Heller" }
                });

            migrationBuilder.InsertData(
                table: "prices",
                columns: new[] { "Id", "Amount", "Name", "Promotion" },
                values: new object[] { new Guid("86961ece-ebab-4878-a00f-9c54c58489d9"), 10.0m, "Regular Price", 8.0m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d0b7eed-f632-404a-ab1d-03d7404529d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "222ef28c-b46e-4915-984c-0c1733690a4f");

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("019f0c3c-b57e-4a0d-9d3e-1e8ce37c614f"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("2eae9249-cedf-4755-b566-e84670f5cec0"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("4f18579c-2676-4841-b870-e5c4ceac44d8"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("56c33824-8943-4cc3-91c4-e5f32d43d9bd"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("70f496d8-0ac8-4283-a49e-c8513724d046"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("75f79db8-463e-4324-8dea-111b3b33165f"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("76e79089-e80a-4bc9-9d3a-4f34217b54d4"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("77834ca3-6ea0-4297-ac93-c6045d59f535"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("b767eb62-5a67-4730-b3e2-d644efa9f94b"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("145e5234-3c55-48c3-b2f7-36049b8c5bb3"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("2400ab9d-5d66-4f9e-8617-8ddbb9f60c17"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("4b916b2d-ee5c-4eab-892d-45755e70243f"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("5b20bf3e-2ffb-4907-ba1e-e55a52ccb967"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("6b384928-36ff-41b9-a02b-471937f478e5"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("6e310f34-849d-45cd-8918-ed43cb15474b"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("a374f114-0c05-4031-bdd3-5bb1da0f61a8"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("c0c73065-abab-475e-85f5-a0b9fac12ae7"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("c2013b6c-0563-4195-b52f-78e6aad7e13e"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("facf9a25-4b89-49d7-92b3-da1caa63970d"));

            migrationBuilder.DeleteData(
                table: "prices",
                keyColumn: "Id",
                keyValue: new Guid("86961ece-ebab-4878-a00f-9c54c58489d9"));

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "photographies");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "photographies",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleId",
                value: "56122853-5f34-4788-b5f5-da50a7d7921a");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleId",
                value: "56122853-5f34-4788-b5f5-da50a7d7921a");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoleId",
                value: "56122853-5f34-4788-b5f5-da50a7d7921a");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4,
                column: "RoleId",
                value: "56122853-5f34-4788-b5f5-da50a7d7921a");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5,
                column: "RoleId",
                value: "56122853-5f34-4788-b5f5-da50a7d7921a");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6,
                column: "RoleId",
                value: "56122853-5f34-4788-b5f5-da50a7d7921a");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7,
                column: "RoleId",
                value: "56122853-5f34-4788-b5f5-da50a7d7921a");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8,
                column: "RoleId",
                value: "56122853-5f34-4788-b5f5-da50a7d7921a");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9,
                column: "RoleId",
                value: "56122853-5f34-4788-b5f5-da50a7d7921a");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10,
                column: "RoleId",
                value: "56122853-5f34-4788-b5f5-da50a7d7921a");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11,
                column: "RoleId",
                value: "bdd6c149-35a5-413f-9c7e-bbba8f1e95eb");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12,
                column: "RoleId",
                value: "bdd6c149-35a5-413f-9c7e-bbba8f1e95eb");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13,
                column: "RoleId",
                value: "bdd6c149-35a5-413f-9c7e-bbba8f1e95eb");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14,
                column: "RoleId",
                value: "bdd6c149-35a5-413f-9c7e-bbba8f1e95eb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "56122853-5f34-4788-b5f5-da50a7d7921a", null, "ADMIN", "ADMIN" },
                    { "bdd6c149-35a5-413f-9c7e-bbba8f1e95eb", null, "CLIENT", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "Id", "Description", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { new Guid("32c68914-403f-4674-8ea5-e4bd8955fa79"), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", new DateTime(2024, 5, 25, 0, 6, 10, 473, DateTimeKind.Local).AddTicks(8807), "Tasty Rubber Bike" },
                    { new Guid("3cf102fa-6078-4070-a414-e5c155edbbd6"), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(2024, 5, 25, 0, 6, 10, 473, DateTimeKind.Local).AddTicks(9691), "Intelligent Steel Computer" },
                    { new Guid("58ddf938-1537-446a-b1bc-eb74aae61a5f"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(2024, 5, 25, 0, 6, 10, 473, DateTimeKind.Local).AddTicks(8714), "Intelligent Plastic Pants" },
                    { new Guid("5cacea8e-9122-46fd-9371-e959a71b57f6"), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(2024, 5, 25, 0, 6, 10, 473, DateTimeKind.Local).AddTicks(9236), "Unbranded Plastic Shirt" },
                    { new Guid("6923ea34-96df-4be4-bef5-10e35d9eb625"), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(2024, 5, 25, 0, 6, 10, 473, DateTimeKind.Local).AddTicks(8680), "Licensed Soft Shoes" },
                    { new Guid("92bfb7cc-7cfd-4c53-b0ed-fa54066f18d2"), "The Football Is Good For Training And Recreational Purposes", new DateTime(2024, 5, 25, 0, 6, 10, 473, DateTimeKind.Local).AddTicks(9623), "Handmade Concrete Bacon" },
                    { new Guid("a741be99-13e1-4ab3-9872-427c64a89b50"), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new DateTime(2024, 5, 25, 0, 6, 10, 473, DateTimeKind.Local).AddTicks(8601), "Practical Wooden Fish" },
                    { new Guid("c538f574-4085-4d42-8685-4d01e89e6892"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(2024, 5, 25, 0, 6, 10, 473, DateTimeKind.Local).AddTicks(9509), "Incredible Wooden Ball" },
                    { new Guid("fd3c9984-bc74-4570-a290-b7ddf07d31bc"), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", new DateTime(2024, 5, 25, 0, 6, 10, 473, DateTimeKind.Local).AddTicks(9569), "Gorgeous Fresh Sausages" }
                });

            migrationBuilder.InsertData(
                table: "instructors",
                columns: new[] { "Id", "Degree", "Names", "Surnames" },
                values: new object[,]
                {
                    { new Guid("25e05355-05d1-4c09-bac1-d790e1cd525d"), "Corporate Implementation Coordinator", "Mckayla", "Hirthe" },
                    { new Guid("2dfb48e9-e12c-4dde-8bee-e89558ac105e"), "Central Solutions Facilitator", "Norval", "Zboncak" },
                    { new Guid("97c265f8-b103-4ad5-a99d-1dc62326be79"), "District Solutions Specialist", "Holly", "Bradtke" },
                    { new Guid("98159134-a052-40dd-97dd-0ea11177a427"), "Lead Communications Executive", "Sasha", "Hayes" },
                    { new Guid("b0198212-471c-4e92-8a1a-9a16dfd3ee96"), "Direct Integration Representative", "Celia", "Littel" },
                    { new Guid("c9688457-eb30-492b-9429-c5d68fc81ba7"), "National Security Facilitator", "Cassidy", "Gusikowski" },
                    { new Guid("cb960cae-d104-42b4-a8a1-166ef0208b36"), "Human Operations Supervisor", "Lauretta", "Bahringer" },
                    { new Guid("d8c59844-fbf8-4407-8d6d-95de53968477"), "Global Identity Supervisor", "Olin", "Yost" },
                    { new Guid("f47aa02a-0a72-4ef2-b709-a24f707fa4b6"), "Human Identity Consultant", "Johan", "Cormier" },
                    { new Guid("fa7073fa-a4ae-4543-b930-0a879816da66"), "Central Solutions Administrator", "Elnora", "MacGyver" }
                });

            migrationBuilder.InsertData(
                table: "prices",
                columns: new[] { "Id", "Amount", "Name", "Promotion" },
                values: new object[] { new Guid("05f70543-50af-455f-bbe9-32f5aacea7cf"), 10.0m, "Regular Price", 8.0m });
        }
    }
}
