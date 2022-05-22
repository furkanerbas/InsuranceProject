using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsureApp.DataAccess.Migrations
{
    public partial class identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arac",
                columns: table => new
                {
                    Arac_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Arac_turu = table.Column<string>(nullable: true),
                    Plaka = table.Column<string>(nullable: true),
                    Ruhsat_no = table.Column<string>(nullable: true),
                    Police_no = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arac", x => x.Arac_id);
                });

            migrationBuilder.CreateTable(
                name: "Konut_Diger",
                columns: table => new
                {
                    Konut_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adres = table.Column<string>(nullable: true),
                    Police_no = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konut_Diger", x => x.Konut_id);
                });

            migrationBuilder.CreateTable(
                name: "Musteri",
                columns: table => new
                {
                    Musteri_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tc_No = table.Column<long>(nullable: false),
                    Isim = table.Column<string>(nullable: false),
                    Soyisim = table.Column<string>(nullable: false),
                    Tel_no = table.Column<long>(nullable: false),
                    Adres = table.Column<string>(nullable: false),
                    Ozel_not = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteri", x => x.Musteri_id);
                });

            migrationBuilder.CreateTable(
                name: "Odemeler",
                columns: table => new
                {
                    Odeme_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Police_no = table.Column<int>(nullable: false),
                    Musteri_id = table.Column<int>(nullable: false),
                    Odenen_tutar = table.Column<int>(nullable: false),
                    Odeme_tarihi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odemeler", x => x.Odeme_id);
                });

            migrationBuilder.CreateTable(
                name: "Police",
                columns: table => new
                {
                    Police_no = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Musteri_id = table.Column<int>(nullable: false),
                    Policetur_id = table.Column<int>(nullable: false),
                    Baslangic_tarihi = table.Column<DateTime>(nullable: false),
                    Bitis_tarihi = table.Column<DateTime>(nullable: false),
                    Vize_tarihi = table.Column<DateTime>(nullable: false),
                    Sigorta_bedeli = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Police", x => x.Police_no);
                });

            migrationBuilder.CreateTable(
                name: "Police_Turu",
                columns: table => new
                {
                    Policetur_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Police_turu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Police_Turu", x => x.Policetur_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arac");

            migrationBuilder.DropTable(
                name: "Konut_Diger");

            migrationBuilder.DropTable(
                name: "Musteri");

            migrationBuilder.DropTable(
                name: "Odemeler");

            migrationBuilder.DropTable(
                name: "Police");

            migrationBuilder.DropTable(
                name: "Police_Turu");
        }
    }
}
