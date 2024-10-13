using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MasterNet.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: true),
                    Career = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "instructors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Names = table.Column<string>(type: "TEXT", nullable: true),
                    Surnames = table.Column<string>(type: "TEXT", nullable: true),
                    Degree = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "prices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR", maxLength: 250, nullable: true),
                    Amount = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    Promotion = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "photographies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photographies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_photographies_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Student = table.Column<string>(type: "TEXT", nullable: true),
                    Commentary = table.Column<string>(type: "TEXT", nullable: true),
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ratings_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "course_instructor",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    InstructorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_instructor", x => new { x.InstructorId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_course_instructor_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_course_instructor_instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "courses_prices",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PriceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses_prices", x => new { x.PriceId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_courses_prices_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_courses_prices_prices_PriceId",
                        column: x => x.PriceId,
                        principalTable: "prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "POLICIES", "COURSE_READ", "56122853-5f34-4788-b5f5-da50a7d7921a" },
                    { 2, "POLICIES", "COURSE_UPDATE", "56122853-5f34-4788-b5f5-da50a7d7921a" },
                    { 3, "POLICIES", "COURSE_CREATE", "56122853-5f34-4788-b5f5-da50a7d7921a" },
                    { 4, "POLICIES", "COURSE_DELETE", "56122853-5f34-4788-b5f5-da50a7d7921a" },
                    { 5, "POLICIES", "INSTRUCTOR_CREATE", "56122853-5f34-4788-b5f5-da50a7d7921a" },
                    { 6, "POLICIES", "INSTRUCTOR_READ", "56122853-5f34-4788-b5f5-da50a7d7921a" },
                    { 7, "POLICIES", "INSTRUCTOR_UPDATE", "56122853-5f34-4788-b5f5-da50a7d7921a" },
                    { 8, "POLICIES", "COMMENT_READ", "56122853-5f34-4788-b5f5-da50a7d7921a" },
                    { 9, "POLICIES", "COMMENT_DELETE", "56122853-5f34-4788-b5f5-da50a7d7921a" },
                    { 10, "POLICIES", "COMMENT_CREATE", "56122853-5f34-4788-b5f5-da50a7d7921a" },
                    { 11, "POLICIES", "COURSE_READ", "bdd6c149-35a5-413f-9c7e-bbba8f1e95eb" },
                    { 12, "POLICIES", "INSTRUCTOR_READ", "bdd6c149-35a5-413f-9c7e-bbba8f1e95eb" },
                    { 13, "POLICIES", "COMMENT_READ", "bdd6c149-35a5-413f-9c7e-bbba8f1e95eb" },
                    { 14, "POLICIES", "COMMENT_CREATE", "bdd6c149-35a5-413f-9c7e-bbba8f1e95eb" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_course_instructor_CourseId",
                table: "course_instructor",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_courses_prices_CourseId",
                table: "courses_prices",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_photographies_CourseId",
                table: "photographies",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_CourseId",
                table: "ratings",
                column: "CourseId");
        }

        /// <inheritdoc />
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
                name: "course_instructor");

            migrationBuilder.DropTable(
                name: "courses_prices");

            migrationBuilder.DropTable(
                name: "photographies");

            migrationBuilder.DropTable(
                name: "ratings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "instructors");

            migrationBuilder.DropTable(
                name: "prices");

            migrationBuilder.DropTable(
                name: "courses");
        }
    }
}
