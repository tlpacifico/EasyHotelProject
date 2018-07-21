using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class FlCheckOut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FlCheckOut",
                table: "Books",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlCheckOut",
                table: "Books");
        }
    }
}
