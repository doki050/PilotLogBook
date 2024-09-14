using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Departure = table.Column<string>(type: "TEXT", nullable: false),
                    DepartureTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    Arrival = table.Column<string>(type: "TEXT", nullable: false),
                    ArrivalTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    AirplaneType = table.Column<string>(type: "TEXT", nullable: false),
                    CallSign = table.Column<string>(type: "TEXT", nullable: false),
                    TotalFlightTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    PilotName = table.Column<string>(type: "TEXT", nullable: false),
                    VfrTakeoff = table.Column<int>(type: "INTEGER", nullable: false),
                    VfrLanding = table.Column<int>(type: "INTEGER", nullable: false),
                    NightTakeoff = table.Column<int>(type: "INTEGER", nullable: false),
                    NightLanding = table.Column<int>(type: "INTEGER", nullable: false),
                    PicTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    DualTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    InstructorTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogBooks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogBooks");
        }
    }
}
