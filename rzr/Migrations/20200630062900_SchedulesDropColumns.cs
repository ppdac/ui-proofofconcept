using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rzr.Migrations
{
    public partial class SchedulesDropColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "Reps",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Schedule");

            migrationBuilder.AlterColumn<int>(
                name: "Period",
                table: "Schedule",
                maxLength: 65535,
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "Jitter",
                table: "Schedule",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<byte>(
                name: "Repitions",
                table: "Schedule",
                maxLength: 255,
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Repitions",
                table: "Schedule");

            migrationBuilder.AlterColumn<byte>(
                name: "Period",
                table: "Schedule",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 65535);

            migrationBuilder.AlterColumn<byte>(
                name: "Jitter",
                table: "Schedule",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Schedule",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte>(
                name: "EndTime",
                table: "Schedule",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<long>(
                name: "Reps",
                table: "Schedule",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<byte>(
                name: "StartTime",
                table: "Schedule",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
