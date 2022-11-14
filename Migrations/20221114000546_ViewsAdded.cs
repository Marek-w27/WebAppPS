using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppPS.Migrations
{
    public partial class ViewsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE VIEW View_WeryfikacjaAll AS
            SELECT nip, NazwaPelna,DataDodania, rola,Profil 
            FROM klienci
            ");

            migrationBuilder.Sql(@"
            CREATE VIEW View_WeryfikacjaFaktorant AS
            SELECT nip,NazwaPelna,DataDodania,Rola,Profil,LimitNaUmowie,DataPodpisaniaUmowy
            FROM klienci
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            DROP VIEW View_WeryfikacjaAll
            ");

            migrationBuilder.Sql(@"
            DROP VIEW View_WeryfikacjaFaktorant
            ");
        }
    }
}
