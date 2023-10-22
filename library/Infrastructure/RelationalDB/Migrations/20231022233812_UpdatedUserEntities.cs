using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace library.Migrations
{
    public partial class UpdatedUserEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "User",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Adres",
                table: "User",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BorrowDate",
                table: "RelUserBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "RelUserBook",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("a28cf5ff-4fb3-47da-a4a8-aa5751cc6ea5"),
                column: "CreatedAt",
                value: new DateTime(2023, 10, 23, 2, 38, 11, 669, DateTimeKind.Local).AddTicks(8230));

            migrationBuilder.UpdateData(
                table: "BookTypes",
                keyColumn: "Id",
                keyValue: new Guid("cb03753a-aabb-430d-8575-1cf524e2e2ea"),
                column: "CreatedAt",
                value: new DateTime(2023, 10, 23, 2, 38, 11, 675, DateTimeKind.Local).AddTicks(7517));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1a300bd1-ef14-48a7-b074-dc0e7db5aa17"),
                column: "CreatedAt",
                value: new DateTime(2023, 10, 23, 2, 38, 11, 675, DateTimeKind.Local).AddTicks(4318));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "BorrowDate",
                table: "RelUserBook");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "RelUserBook");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "User",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "User",
                newName: "Adres");

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
        }
    }
}
