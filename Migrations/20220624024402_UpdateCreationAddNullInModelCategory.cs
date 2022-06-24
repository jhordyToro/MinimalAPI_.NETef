using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimalAPIef.Migrations
{
    public partial class UpdateCreationAddNullInModelCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("57f0795e-b5b5-416a-b6b2-5fc1193c1702"),
                column: "CreationDate",
                value: new DateTime(2022, 6, 23, 21, 44, 1, 266, DateTimeKind.Local).AddTicks(2170));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("57f0795e-b5b5-416a-b6b2-5fc1193c17ad"),
                column: "CreationDate",
                value: new DateTime(2022, 6, 23, 21, 44, 1, 266, DateTimeKind.Local).AddTicks(2147));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("57f0795e-b5b5-416a-b6b2-5fc1193c1702"),
                column: "CreationDate",
                value: new DateTime(2022, 6, 23, 21, 28, 1, 676, DateTimeKind.Local).AddTicks(9410));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("57f0795e-b5b5-416a-b6b2-5fc1193c17ad"),
                column: "CreationDate",
                value: new DateTime(2022, 6, 23, 21, 28, 1, 676, DateTimeKind.Local).AddTicks(9388));
        }
    }
}
