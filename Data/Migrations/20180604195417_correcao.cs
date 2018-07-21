using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class correcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beds_Accommodations_AccommodationId",
                table: "Beds");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBed_Beds_BedId",
                table: "RoomBed");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBed_Rooms_RoomId",
                table: "RoomBed");

            migrationBuilder.DropIndex(
                name: "IX_Beds_AccommodationId",
                table: "Beds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomBed",
                table: "RoomBed");

            migrationBuilder.DropColumn(
                name: "AccommodationId",
                table: "Beds");

            migrationBuilder.RenameTable(
                name: "RoomBed",
                newName: "RoomBeds");

            migrationBuilder.RenameIndex(
                name: "IX_RoomBed_BedId",
                table: "RoomBeds",
                newName: "IX_RoomBeds_BedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomBeds",
                table: "RoomBeds",
                columns: new[] { "RoomId", "BedId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBeds_Beds_BedId",
                table: "RoomBeds",
                column: "BedId",
                principalTable: "Beds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBeds_Rooms_RoomId",
                table: "RoomBeds",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomBeds_Beds_BedId",
                table: "RoomBeds");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBeds_Rooms_RoomId",
                table: "RoomBeds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomBeds",
                table: "RoomBeds");

            migrationBuilder.RenameTable(
                name: "RoomBeds",
                newName: "RoomBed");

            migrationBuilder.RenameIndex(
                name: "IX_RoomBeds_BedId",
                table: "RoomBed",
                newName: "IX_RoomBed_BedId");

            migrationBuilder.AddColumn<int>(
                name: "AccommodationId",
                table: "Beds",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomBed",
                table: "RoomBed",
                columns: new[] { "RoomId", "BedId" });

            migrationBuilder.CreateIndex(
                name: "IX_Beds_AccommodationId",
                table: "Beds",
                column: "AccommodationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beds_Accommodations_AccommodationId",
                table: "Beds",
                column: "AccommodationId",
                principalTable: "Accommodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBed_Beds_BedId",
                table: "RoomBed",
                column: "BedId",
                principalTable: "Beds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBed_Rooms_RoomId",
                table: "RoomBed",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
