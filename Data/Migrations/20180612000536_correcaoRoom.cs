using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class correcaoRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AccommodationId",
                table: "Rooms",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AccommodationId",
                table: "Rooms",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
