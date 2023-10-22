using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace library.Migrations
{
    public partial class InitialMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelBookAuthor_Book_BookId",
                table: "RelBookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_RelBookAuthor_Books_AuthorId",
                table: "RelBookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_RelBookType_Book_BookId",
                table: "RelBookType");

            migrationBuilder.DropForeignKey(
                name: "FK_RelBookType_BookType_TypeId",
                table: "RelBookType");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RelBookType",
                table: "RelBookType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RelBookAuthor",
                table: "RelBookAuthor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookType",
                table: "BookType");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("a28cf5ff-4fb3-47da-a4a8-aa5751cc6ea5"));

            migrationBuilder.RenameTable(
                name: "RelBookType",
                newName: "RelBookTypes");

            migrationBuilder.RenameTable(
                name: "RelBookAuthor",
                newName: "RelBookAuthors");

            migrationBuilder.RenameTable(
                name: "BookType",
                newName: "BookTypes");

            migrationBuilder.RenameIndex(
                name: "IX_RelBookType_TypeId",
                table: "RelBookTypes",
                newName: "IX_RelBookTypes_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_RelBookType_BookId",
                table: "RelBookTypes",
                newName: "IX_RelBookTypes_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_RelBookAuthor_BookId",
                table: "RelBookAuthors",
                newName: "IX_RelBookAuthors_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_RelBookAuthor_AuthorId",
                table: "RelBookAuthors",
                newName: "IX_RelBookAuthors_AuthorId");

            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RelBookAuthors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelBookTypes",
                table: "RelBookTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelBookAuthors",
                table: "RelBookAuthors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookTypes",
                table: "BookTypes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Authors",
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
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[] { new Guid("a28cf5ff-4fb3-47da-a4a8-aa5751cc6ea5"), new DateTime(2023, 10, 22, 7, 52, 22, 326, DateTimeKind.Local).AddTicks(6190), null, false, "Richard Bach", null });

            migrationBuilder.UpdateData(
                table: "BookTypes",
                keyColumn: "Id",
                keyValue: new Guid("cb03753a-aabb-430d-8575-1cf524e2e2ea"),
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 7, 52, 22, 332, DateTimeKind.Local).AddTicks(5383));

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "IsUsed", "Name", "UpdatedAt" },
                values: new object[] { new Guid("1a300bd1-ef14-48a7-b074-dc0e7db5aa17"), new DateTime(2023, 10, 22, 7, 52, 22, 332, DateTimeKind.Local).AddTicks(2941), null, false, false, "Marti", null });

            migrationBuilder.AddForeignKey(
                name: "FK_RelBookAuthors_Authors_AuthorId",
                table: "RelBookAuthors",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelBookAuthors_Books_BookId",
                table: "RelBookAuthors",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelBookTypes_Books_BookId",
                table: "RelBookTypes",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelBookTypes_BookTypes_TypeId",
                table: "RelBookTypes",
                column: "TypeId",
                principalTable: "BookTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelBookAuthors_Authors_AuthorId",
                table: "RelBookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_RelBookAuthors_Books_BookId",
                table: "RelBookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_RelBookTypes_Books_BookId",
                table: "RelBookTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_RelBookTypes_BookTypes_TypeId",
                table: "RelBookTypes");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RelBookTypes",
                table: "RelBookTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RelBookAuthors",
                table: "RelBookAuthors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookTypes",
                table: "BookTypes");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1a300bd1-ef14-48a7-b074-dc0e7db5aa17"));

            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RelBookAuthors");

            migrationBuilder.RenameTable(
                name: "RelBookTypes",
                newName: "RelBookType");

            migrationBuilder.RenameTable(
                name: "RelBookAuthors",
                newName: "RelBookAuthor");

            migrationBuilder.RenameTable(
                name: "BookTypes",
                newName: "BookType");

            migrationBuilder.RenameIndex(
                name: "IX_RelBookTypes_TypeId",
                table: "RelBookType",
                newName: "IX_RelBookType_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_RelBookTypes_BookId",
                table: "RelBookType",
                newName: "IX_RelBookType_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_RelBookAuthors_BookId",
                table: "RelBookAuthor",
                newName: "IX_RelBookAuthor_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_RelBookAuthors_AuthorId",
                table: "RelBookAuthor",
                newName: "IX_RelBookAuthor_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelBookType",
                table: "RelBookType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelBookAuthor",
                table: "RelBookAuthor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookType",
                table: "BookType",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "IsUsed", "Name", "UpdatedAt" },
                values: new object[] { new Guid("1a300bd1-ef14-48a7-b074-dc0e7db5aa17"), new DateTime(2023, 10, 21, 23, 44, 8, 469, DateTimeKind.Local).AddTicks(9613), null, false, false, "Marti", null });

            migrationBuilder.UpdateData(
                table: "BookType",
                keyColumn: "Id",
                keyValue: new Guid("cb03753a-aabb-430d-8575-1cf524e2e2ea"),
                column: "CreatedAt",
                value: new DateTime(2023, 10, 21, 23, 44, 8, 470, DateTimeKind.Local).AddTicks(3068));

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[] { new Guid("a28cf5ff-4fb3-47da-a4a8-aa5751cc6ea5"), new DateTime(2023, 10, 21, 23, 44, 8, 464, DateTimeKind.Local).AddTicks(1395), null, false, "Richard Bach", null });

            migrationBuilder.AddForeignKey(
                name: "FK_RelBookAuthor_Book_BookId",
                table: "RelBookAuthor",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelBookAuthor_Books_AuthorId",
                table: "RelBookAuthor",
                column: "AuthorId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelBookType_Book_BookId",
                table: "RelBookType",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelBookType_BookType_TypeId",
                table: "RelBookType",
                column: "TypeId",
                principalTable: "BookType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
