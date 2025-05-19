using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PowerPressSettingsManager.Migrations
{
    /// <inheritdoc />
    public partial class MakeOneToOneReleationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PressSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PartNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ClampingHight = table.Column<float>(type: "REAL", nullable: false),
                    RunningHight = table.Column<float>(type: "REAL", nullable: false),
                    RecommendedRunningSpeed = table.Column<int>(type: "INTEGER", nullable: false),
                    MagnetBeltSpeed = table.Column<int>(type: "INTEGER", nullable: false),
                    LastTimeRun = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PressSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoulSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaterialGrade = table.Column<int>(type: "INTEGER", nullable: false),
                    FeedLenght = table.Column<int>(type: "INTEGER", nullable: false),
                    RunSide = table.Column<bool>(type: "INTEGER", nullable: false),
                    ProgressionOrTransfer = table.Column<bool>(type: "INTEGER", nullable: false),
                    LeftHight = table.Column<decimal>(type: "TEXT", nullable: false),
                    RightHight = table.Column<decimal>(type: "TEXT", nullable: false),
                    RecommendedSpeedFeeder = table.Column<int>(type: "INTEGER", nullable: false),
                    PressSettingId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoulSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoulSettings_PressSettings_PressSettingId",
                        column: x => x.PressSettingId,
                        principalTable: "PressSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoulSettings_PressSettingId",
                table: "CoulSettings",
                column: "PressSettingId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoulSettings");

            migrationBuilder.DropTable(
                name: "PressSettings");
        }
    }
}
