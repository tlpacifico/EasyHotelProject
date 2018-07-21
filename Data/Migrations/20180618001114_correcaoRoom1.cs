using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class correcaoRoom1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentBookId",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckOut",
                table: "Books",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CurrentBookId",
                table: "Rooms",
                column: "CurrentBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Books_CurrentBookId",
                table: "Rooms",
                column: "CurrentBookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Books_CurrentBookId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_CurrentBookId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CurrentBookId",
                table: "Rooms");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckOut",
                table: "Books",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
