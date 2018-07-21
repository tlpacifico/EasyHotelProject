using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class accommodation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DayRoom",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcommodationId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    GuestsQty = table.Column<int>(nullable: false),
                    DayRoomDate = table.Column<DateTime>(nullable: false),
                    DayRoomPrice = table.Column<decimal>(nullable: false),
                    PaymentFlag = table.Column<bool>(nullable: false),
                    AccommodationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayRoom_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayRoom_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuestAccommotations",
                columns: table => new
                {
                    GuestId = table.Column<int>(nullable: false),
                    AccommodationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestAccommotations", x => new { x.AccommodationId, x.GuestId });
                    table.ForeignKey(
                        name: "FK_GuestAccommotations_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestAccommotations_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayRoom_AccommodationId",
                table: "DayRoom",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_DayRoom_RoomId",
                table: "DayRoom",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestAccommotations_GuestId",
                table: "GuestAccommotations",
                column: "GuestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayRoom");

            migrationBuilder.DropTable(
                name: "GuestAccommotations");
        }
    }
}
