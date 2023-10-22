using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace library.Migrations
{
    public partial class UpdatedUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
