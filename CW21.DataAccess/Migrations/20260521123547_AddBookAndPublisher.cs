using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CW21.Presentation.Migrations
{
    /// <inheritdoc />
    public partial class AddBookAndPublisher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthYear = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(400)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m),
                    PublishYear = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    PublisherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BirthDate", "BirthYear", "Country", "FullName" },
                values: new object[,]
                {
                    { 1, new DateTime(1952, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "USA", "Robert C. Martin" },
                    { 2, new DateTime(1976, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UK", "Jon Skeet" },
                    { 3, new DateTime(1986, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "USA", "James Clear" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Programming and software engineering books", "Programming" },
                    { 2, "Personal growth books", "Self Development" },
                    { 3, "Focus and productivity books", "Productivity" }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "City", "CreatedAt", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "mosko", new DateTime(2000, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dastayofski", "9125846565" },
                    { 2, "tehran", new DateTime(2000, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mohamad", "9125846565" },
                    { 3, "shiraz", new DateTime(2000, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "akbari", "9125846565" },
                    { 4, "tehran", new DateTime(2000, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "roham", "9125846565" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CreatedAt", "Price", "PublishYear", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 700m, 2008, null, "Clean Code" },
                    { 2, 2, 1, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 850m, 2019, null, "C# In Depth" },
                    { 3, 3, 2, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 450m, 2018, 1, "Atomic Habits" },
                    { 4, 1, 1, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 900m, 1999, 3, "The Pragmatic Programmer" },
                    { 5, 3, 3, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m, 2016, 2, "Deep Work" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CreatedAt", "Price", "PublishYear", "PublisherId", "Stock", "Title" },
                values: new object[,]
                {
                    { 6, 3, 3, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 550m, 1500, 4, 5, "maktab" },
                    { 7, 3, 3, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 600m, 15000, 1, 6, "maktab2" },
                    { 8, 3, 3, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 700m, 2000, 1, 7, "maktab3" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CreatedAt", "Price", "PublishYear", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 9, 3, 3, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 750m, 2010, 2, "maktab4" },
                    { 10, 3, 3, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 760m, 2025, 1, "maktab5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publisher_Name",
                table: "Publisher",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Publisher");
        }
    }
}
