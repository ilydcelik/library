using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace library.Migrations
{
    public partial class NewUserEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RelBookAuthors");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelUserBook",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Userd = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelUserBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelUserBook_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelUserBook_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("a28cf5ff-4fb3-47da-a4a8-aa5751cc6ea5"),
                column: "CreatedAt",
                value: new DateTime(2023, 10, 23, 2, 31, 10, 460, DateTimeKind.Local).AddTicks(9916));

            migrationBuilder.UpdateData(
                table: "BookTypes",
                keyColumn: "Id",
                keyValue: new Guid("cb03753a-aabb-430d-8575-1cf524e2e2ea"),
                column: "CreatedAt",
                value: new DateTime(2023, 10, 23, 2, 31, 10, 467, DateTimeKind.Local).AddTicks(4));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1a300bd1-ef14-48a7-b074-dc0e7db5aa17"),
                column: "CreatedAt",
                value: new DateTime(2023, 10, 23, 2, 31, 10, 466, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.CreateIndex(
                name: "IX_RelUserBook_BookId",
                table: "RelUserBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_RelUserBook_UserId",
                table: "RelUserBook",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelUserBook");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RelBookAuthors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("a28cf5ff-4fb3-47da-a4a8-aa5751cc6ea5"),
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 7, 52, 22, 326, DateTimeKind.Local).AddTicks(6190));

            migrationBuilder.UpdateData(
                table: "BookTypes",
                keyColumn: "Id",
                keyValue: new Guid("cb03753a-aabb-430d-8575-1cf524e2e2ea"),
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 7, 52, 22, 332, DateTimeKind.Local).AddTicks(5383));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1a300bd1-ef14-48a7-b074-dc0e7db5aa17"),
                column: "CreatedAt",
                value: new DateTime(2023, 10, 22, 7, 52, 22, 332, DateTimeKind.Local).AddTicks(2941));
        }
    }
}
