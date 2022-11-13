using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppPS.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "klienci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nip = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Rola = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NazwaPelna = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NazwaSkrocona = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DataDodania = table.Column<DateTime>(type: "datetime", nullable: true),
                    Profil = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    NumerUmowy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LimitNaUmowie = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    DataPodpisaniaUmowy = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_klienci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weryfikacja",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    DataWysz = table.Column<DateTime>(type: "datetime", nullable: true),
                    WyszNip = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Weryfikacja = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "klienci_kontrahenci",
                columns: table => new
                {
                    IdKlienta = table.Column<int>(type: "int", nullable: false),
                    IdKontrahenta = table.Column<int>(type: "int", nullable: false),
                    LimitNaUmowie = table.Column<decimal>(type: "decimal(12,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__klienci___25DE50FD09E17413", x => new { x.IdKlienta, x.IdKontrahenta });
                    table.ForeignKey(
                        name: "FK__klienci_k__IdKli__267ABA7A",
                        column: x => x.IdKlienta,
                        principalTable: "klienci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__klienci_k__IdKon__276EDEB3",
                        column: x => x.IdKontrahenta,
                        principalTable: "klienci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_klienci_kontrahenci_IdKontrahenta",
                table: "klienci_kontrahenci",
                column: "IdKontrahenta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "klienci_kontrahenci");

            migrationBuilder.DropTable(
                name: "Weryfikacja");

            migrationBuilder.DropTable(
                name: "klienci");
        }
    }
}
