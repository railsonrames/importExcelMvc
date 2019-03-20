using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace importExcelMvc.Migrations
{
    public partial class migracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Endereco = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    Condominio = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "Condominio", "Endereco", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, "RESIDENCIAL JK", "ST. SAGOCAN LT. 2 RES. JK BL. C APTO. 701", "Fulano de Tal da Silva Sauro", "6197745120" },
                    { 2, "RESIDENCIAL ESPLANADA", "ST. SAGOCAN LT. 3 RES. ESPLANADA BL. A APTO. 1101", "Rosicleide Morais Oliveira Costa e Silva", "61983325471" },
                    { 3, "ESTÂNCIA QUINTAS DA ALVORADA", "SHJB COND. ESTÂNCIA QUINTAS DA ALVORADA RUA 5 CASA 23", "Basília Rodrigues de Sá", "6132050411" },
                    { 4, "ESTÂNCIA QUINTAS DA ALVORADA", "SHJB COND. ESTÂNCIA QUINTAS DA ALVORADA RUA 12 CASA 6", "Virgolina Inácia Pereira dos Montes", "61982475151" },
                    { 5, "CONDOMÍNIO POR DO SOL", "AOS 7 BL. A APTO. 16, ÁREA OCTOGONAL, CRUZEIRO", "Balbino Diniz de Oliveira Conde", "61984217140" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
