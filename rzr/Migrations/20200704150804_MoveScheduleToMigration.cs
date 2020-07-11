using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rzr.Migrations
{
    public partial class MoveScheduleToMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BlackoutTime",
                table: "Experiment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Jitter",
                table: "Experiment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "Experiment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "Repitions",
                table: "Experiment",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Experiment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Experiment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlackoutTime",
                table: "Experiment");

            migrationBuilder.DropColumn(
                name: "Jitter",
                table: "Experiment");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "Experiment");

            migrationBuilder.DropColumn(
                name: "Repitions",
                table: "Experiment");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Experiment");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Experiment");
        }
    }
}
