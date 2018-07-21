using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class accommodation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Accommodations_RoomId",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "AccommodationId",
                table: "Rooms");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_RoomId",
                table: "Accommodations",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Accommodations_RoomId",
                table: "Accommodations");

            migrationBuilder.AddColumn<int>(
                name: "AccommodationId",
                table: "Rooms",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_RoomId",
                table: "Accommodations",
                column: "RoomId",
                unique: true);
        }
    }
}
