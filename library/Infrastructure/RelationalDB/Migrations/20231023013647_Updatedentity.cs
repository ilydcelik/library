using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace library.Migrations
{
    public partial class Updatedentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelUserBook_Books_BookId",
                table: "RelUserBook");

            migrationBuilder.DropForeignKey(
                name: "FK_RelUserBook_User_UserId",
                table: "RelUserBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RelUserBook",
                table: "RelUserBook");

            migrationBuilder.DropColumn(
                name: "Userd",
                table: "RelUserBook");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "RelUserBook",
                newName: "RelUserBooks");

            migrationBuilder.RenameIndex(
                name: "IX_RelUserBook_UserId",
                table: "RelUserBooks",
                newName: "IX_RelUserBooks_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RelUserBook_BookId",
                table: "RelUserBooks",
                newName: "IX_RelUserBooks_BookId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "RelUserBooks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelUserBooks",
                table: "RelUserBooks",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("a28cf5ff-4fb3-47da-a4a8-aa5751cc6ea5"),
                column: "CreatedAt",
                value: new DateTime(2023, 10, 23, 4, 36, 47, 119, DateTimeKind.Local).AddTicks(4515));

            migrationBuilder.UpdateData(
                table: "BookTypes",
                keyColumn: "Id",
                keyValue: new Guid("cb03753a-aabb-430d-8575-1cf524e2e2ea"),
                column: "CreatedAt",
                value: new DateTime(2023, 10, 23, 4, 36, 47, 125, DateTimeKind.Local).AddTicks(5516));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1a300bd1-ef14-48a7-b074-dc0e7db5aa17"),
                column: "CreatedAt",
                value: new DateTime(2023, 10, 23, 4, 36, 47, 125, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "FirstName", "IsDeleted", "LastName", "UpdatedAt", "Username" },
                values: new object[] { new Guid("3d5dd8ca-be9c-4072-be9f-934720decd25"), new DateTime(2023, 10, 23, 4, 36, 47, 125, DateTimeKind.Local).AddTicks(6874), null, "ilayda", false, "celik", null, "ilayda.celik'" });

            migrationBuilder.InsertData(
                table: "RelUserBooks",
                columns: new[] { "Id", "BookId", "BorrowDate", "ReturnDate", "UserId" },
                values: new object[] { new Guid("b37616fe-bf73-49f6-b703-efb34409d3e7"), new Guid("1a300bd1-ef14-48a7-b074-dc0e7db5aa17"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3d5dd8ca-be9c-4072-be9f-934720decd25") });

            migrationBuilder.AddForeignKey(
                name: "FK_RelUserBooks_Books_BookId",
                table: "RelUserBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelUserBooks_Users_UserId",
                table: "RelUserBooks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelUserBooks_Books_BookId",
                table: "RelUserBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_RelUserBooks_Users_UserId",
                table: "RelUserBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RelUserBooks",
                table: "RelUserBooks");

            migrationBuilder.DeleteData(
                table: "RelUserBooks",
                keyColumn: "Id",
                keyValue: new Guid("b37616fe-bf73-49f6-b703-efb34409d3e7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3d5dd8ca-be9c-4072-be9f-934720decd25"));

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "RelUserBooks",
                newName: "RelUserBook");

            migrationBuilder.RenameIndex(
                name: "IX_RelUserBooks_UserId",
                table: "RelUserBook",
                newName: "IX_RelUserBook_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RelUserBooks_BookId",
                table: "RelUserBook",
                newName: "IX_RelUserBook_BookId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "RelUserBook",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "Userd",
                table: "RelUserBook",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelUserBook",
                table: "RelUserBook",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("a28cf5ff-4fb3-47da-a4a8-aa5751cc6ea5"),
                column: "CreatedAt",
                value: new DateTime(2023, 10, 23, 2, 42, 50, 138, DateTimeKind.Local).AddTicks(6906));

            migrationBuilder.UpdateData(
                table: "BookTypes",
                keyColumn: "Id",
                keyValue: new Guid("cb03753a-aabb-430d-8575-1cf524e2e2ea"),
                column: "CreatedAt",
                value: new DateTime(2023, 10, 23, 2, 42, 50, 144, DateTimeKind.Local).AddTicks(7898));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1a300bd1-ef14-48a7-b074-dc0e7db5aa17"),
                column: "CreatedAt",
                value: new DateTime(2023, 10, 23, 2, 42, 50, 144, DateTimeKind.Local).AddTicks(4671));

            migrationBuilder.AddForeignKey(
                name: "FK_RelUserBook_Books_BookId",
                table: "RelUserBook",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelUserBook_User_UserId",
                table: "RelUserBook",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
