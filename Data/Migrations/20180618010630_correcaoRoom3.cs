using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class correcaoRoom3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rooms_CurrentBookId",
                table: "Rooms");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CurrentBookId",
                table: "Rooms",
                column: "CurrentBookId",
                unique: true,
                filter: "[CurrentBookId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rooms_CurrentBookId",
                table: "Rooms");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CurrentBookId",
                table: "Rooms",
                column: "CurrentBookId");
        }
    }
}
