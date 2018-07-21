using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class renamecollumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayRoom_Accommodations_AccommodationId",
                table: "DayRoom");

            migrationBuilder.DropTable(
                name: "GuestAccommotations");

            migrationBuilder.DropTable(
                name: "Accommodations");

            migrationBuilder.DropIndex(
                name: "IX_DayRoom_AccommodationId",
                table: "DayRoom");

            migrationBuilder.DropColumn(
                name: "AccommodationId",
                table: "DayRoom");

            migrationBuilder.RenameColumn(
                name: "AcommodationId",
                table: "DayRoom",
                newName: "BookId");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckIn = table.Column<DateTime>(nullable: false),
                    CheckOut = table.Column<DateTime>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    GuestNumber = table.Column<int>(nullable: false),
                    RoomRate = table.Column<decimal>(nullable: false),
                    TotalBill = table.Column<decimal>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuestBooks",
                columns: table => new
                {
                    GuestId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestBooks", x => new { x.BookId, x.GuestId });
                    table.ForeignKey(
                        name: "FK_GuestBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestBooks_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayRoom_BookId",
                table: "DayRoom",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_RoomId",
                table: "Books",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestBooks_GuestId",
                table: "GuestBooks",
                column: "GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayRoom_Books_BookId",
                table: "DayRoom",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayRoom_Books_BookId",
                table: "DayRoom");

            migrationBuilder.DropTable(
                name: "GuestBooks");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropIndex(
                name: "IX_DayRoom_BookId",
                table: "DayRoom");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "DayRoom",
                newName: "AcommodationId");

            migrationBuilder.AddColumn<int>(
                name: "AccommodationId",
                table: "DayRoom",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Accommodations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckIn = table.Column<DateTime>(nullable: false),
                    CheckOut = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    GuestNumber = table.Column<int>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    RoomRate = table.Column<decimal>(nullable: false),
                    TotalBill = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accommodations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuestAccommotations",
                columns: table => new
                {
                    AccommodationId = table.Column<int>(nullable: false),
                    GuestId = table.Column<int>(nullable: false)
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
                name: "IX_Accommodations_RoomId",
                table: "Accommodations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestAccommotations_GuestId",
                table: "GuestAccommotations",
                column: "GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayRoom_Accommodations_AccommodationId",
                table: "DayRoom",
                column: "AccommodationId",
                principalTable: "Accommodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
