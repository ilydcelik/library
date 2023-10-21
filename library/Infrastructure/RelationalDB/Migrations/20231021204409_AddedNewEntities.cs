using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace library.Migrations
{
    public partial class AddedNewEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1a300bd1-ef14-48a7-b074-dc0e7db5aa17"));

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelBookAuthor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelBookAuthor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelBookAuthor_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelBookAuthor_Books_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelBookType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelBookType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelBookType_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelBookType_BookType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "BookType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "IsUsed", "Name", "UpdatedAt" },
                values: new object[] { new Guid("1a300bd1-ef14-48a7-b074-dc0e7db5aa17"), new DateTime(2023, 10, 21, 23, 44, 8, 469, DateTimeKind.Local).AddTicks(9613), null, false, false, "Marti", null });

            migrationBuilder.InsertData(
                table: "BookType",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[] { new Guid("cb03753a-aabb-430d-8575-1cf524e2e2ea"), new DateTime(2023, 10, 21, 23, 44, 8, 470, DateTimeKind.Local).AddTicks(3068), null, false, "Kurgu", null });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[] { new Guid("a28cf5ff-4fb3-47da-a4a8-aa5751cc6ea5"), new DateTime(2023, 10, 21, 23, 44, 8, 464, DateTimeKind.Local).AddTicks(1395), null, false, "Richard Bach", null });

            migrationBuilder.InsertData(
                table: "RelBookAuthor",
                columns: new[] { "Id", "AuthorId", "BookId" },
                values: new object[] { new Guid("8abac909-6cee-4799-b467-680a814604d3"), new Guid("a28cf5ff-4fb3-47da-a4a8-aa5751cc6ea5"), new Guid("1a300bd1-ef14-48a7-b074-dc0e7db5aa17") });

            migrationBuilder.InsertData(
                table: "RelBookType",
                columns: new[] { "Id", "BookId", "TypeId" },
                values: new object[] { new Guid("8abac909-6cee-4799-b467-680a814604d3"), new Guid("1a300bd1-ef14-48a7-b074-dc0e7db5aa17"), new Guid("cb03753a-aabb-430d-8575-1cf524e2e2ea") });

            migrationBuilder.CreateIndex(
                name: "IX_RelBookAuthor_AuthorId",
                table: "RelBookAuthor",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_RelBookAuthor_BookId",
                table: "RelBookAuthor",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_RelBookType_BookId",
                table: "RelBookType",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_RelBookType_TypeId",
                table: "RelBookType",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelBookAuthor");

            migrationBuilder.DropTable(
                name: "RelBookType");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "BookType");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("a28cf5ff-4fb3-47da-a4a8-aa5751cc6ea5"));

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[] { new Guid("1a300bd1-ef14-48a7-b074-dc0e7db5aa17"), new DateTime(2023, 10, 20, 18, 24, 0, 385, DateTimeKind.Local).AddTicks(6284), null, false, "Marti", null });
        }
    }
}
