using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimalAPIef.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "weight" },
                values: new object[] { new Guid("e911afe8-8bf3-4308-827a-85a2c9742c02"), null, "ActivitiesPersonal", 50 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "weight" },
                values: new object[] { new Guid("e911afe8-8bf3-4308-827a-85a2c9742cd9"), null, "ActivitiesPending", 20 });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "CreationDate", "Description", "PriorityTask", "Title" },
                values: new object[] { new Guid("57f0795e-b5b5-416a-b6b2-5fc1193c1702"), new Guid("e911afe8-8bf3-4308-827a-85a2c9742c02"), new DateTime(2022, 6, 23, 21, 28, 1, 676, DateTimeKind.Local).AddTicks(9410), null, 0, "end up of view movies in netflix" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "CreationDate", "Description", "PriorityTask", "Title" },
                values: new object[] { new Guid("57f0795e-b5b5-416a-b6b2-5fc1193c17ad"), new Guid("e911afe8-8bf3-4308-827a-85a2c9742cd9"), new DateTime(2022, 6, 23, 21, 28, 1, 676, DateTimeKind.Local).AddTicks(9388), null, 1, "Utility Payment" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("57f0795e-b5b5-416a-b6b2-5fc1193c1702"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("57f0795e-b5b5-416a-b6b2-5fc1193c17ad"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("e911afe8-8bf3-4308-827a-85a2c9742c02"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("e911afe8-8bf3-4308-827a-85a2c9742cd9"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
