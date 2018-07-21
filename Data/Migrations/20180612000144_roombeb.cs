using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class roombeb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Beds_BedId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_BedId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "BedId",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "NumberBeds",
                table: "RoomBeds",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberBeds",
                table: "RoomBeds");

            migrationBuilder.AddColumn<int>(
                name: "BedId",
                table: "Rooms",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BedId",
                table: "Rooms",
                column: "BedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Beds_BedId",
                table: "Rooms",
                column: "BedId",
                principalTable: "Beds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
