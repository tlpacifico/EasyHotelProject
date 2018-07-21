using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class correcao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accommodations_Rooms_RoomId",
                table: "Accommodations");

            migrationBuilder.DropIndex(
                name: "IX_Accommodations_RoomId",
                table: "Accommodations");

            migrationBuilder.AddColumn<int>(
                name: "AccommodationId",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_AccommodationId",
                table: "Rooms",
                column: "AccommodationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Accommodations_AccommodationId",
                table: "Rooms",
                column: "AccommodationId",
                principalTable: "Accommodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Accommodations_AccommodationId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_AccommodationId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "AccommodationId",
                table: "Rooms");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_RoomId",
                table: "Accommodations",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accommodations_Rooms_RoomId",
                table: "Accommodations",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
