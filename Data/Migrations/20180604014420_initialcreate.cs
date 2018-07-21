using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(maxLength: 120, nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    Uf = table.Column<string>(maxLength: 2, nullable: false),
                    Cidade = table.Column<string>(maxLength: 20, nullable: false),
                    Prefixo = table.Column<string>(maxLength: 10, nullable: false),
                    Logradouro = table.Column<string>(maxLength: 40, nullable: false),
                    Bairro = table.Column<string>(maxLength: 20, nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Cep = table.Column<string>(maxLength: 8, nullable: false),
                    Fone = table.Column<string>(maxLength: 12, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: true),
                    DsComplemento = table.Column<string>(nullable: true),
                    DtNascimento = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guests");
        }
    }
}
