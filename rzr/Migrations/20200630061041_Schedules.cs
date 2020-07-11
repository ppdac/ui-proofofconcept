using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rzr.Migrations
{
    public partial class Schedules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<byte>(nullable: false),
                    EndTime = table.Column<byte>(nullable: false),
                    Jitter = table.Column<byte>(nullable: false),
                    Period = table.Column<byte>(nullable: false),
                    Reps = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedule");
        }
    }
}
