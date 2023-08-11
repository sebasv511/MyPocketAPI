using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPocketAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pocket",
                columns: table => new
                {
                    PocketId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pocket", x => x.PocketId);
                    table.ForeignKey(
                        name: "FK_Pocket_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PocketDetail",
                columns: table => new
                {
                    PocketDetailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    year = table.Column<int>(type: "int", nullable: false),
                    PocketId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PocketDetail", x => x.PocketDetailId);
                    table.ForeignKey(
                        name: "FK_PocketDetail_Pocket_PocketId",
                        column: x => x.PocketId,
                        principalTable: "Pocket",
                        principalColumn: "PocketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Month",
                columns: table => new
                {
                    MonthId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthNumber = table.Column<int>(type: "int", nullable: false),
                    PocketDetailId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Month", x => x.MonthId);
                    table.ForeignKey(
                        name: "FK_Month_PocketDetail_PocketDetailId",
                        column: x => x.PocketDetailId,
                        principalTable: "PocketDetail",
                        principalColumn: "PocketDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonthDetail",
                columns: table => new
                {
                    MonthDetailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Period = table.Column<int>(type: "int", nullable: false),
                    MonthId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthDetail", x => x.MonthDetailId);
                    table.ForeignKey(
                        name: "FK_MonthDetail_Month_MonthId",
                        column: x => x.MonthId,
                        principalTable: "Month",
                        principalColumn: "MonthId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movement",
                columns: table => new
                {
                    MovementId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Concept = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "money", nullable: false),
                    Payday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaydayLimit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    MonthDetailId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movement", x => x.MovementId);
                    table.ForeignKey(
                        name: "FK_Movement_MonthDetail_MonthDetailId",
                        column: x => x.MonthDetailId,
                        principalTable: "MonthDetail",
                        principalColumn: "MonthDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Month_PocketDetailId",
                table: "Month",
                column: "PocketDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthDetail_MonthId",
                table: "MonthDetail",
                column: "MonthId");

            migrationBuilder.CreateIndex(
                name: "IX_Movement_MonthDetailId",
                table: "Movement",
                column: "MonthDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Pocket_UserId",
                table: "Pocket",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PocketDetail_PocketId",
                table: "PocketDetail",
                column: "PocketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movement");

            migrationBuilder.DropTable(
                name: "MonthDetail");

            migrationBuilder.DropTable(
                name: "Month");

            migrationBuilder.DropTable(
                name: "PocketDetail");

            migrationBuilder.DropTable(
                name: "Pocket");
        }
    }
}
