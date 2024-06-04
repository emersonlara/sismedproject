using Microsoft.EntityFrameworkCore.Migrations;

namespace SisMedico.InfraData.Migrations;

public partial class AddChamadaMedico : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "ChamadaMedica",
            columns: table => new
            {
                ChamadaMedicoId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Mensagem = table.Column<string>(type: "varchar(90)", maxLength: 150, nullable: false),
                DataChamada = table.Column<DateTime>(nullable: false),
                Medico = table.Column<string>(type: "varchar(90)", maxLength: 80, nullable: false),
                Leito = table.Column<string>(type: "varchar(90)", maxLength: 10, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ChamadaMedico", x => x.ChamadaMedicoId);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "ChamadaMedica");
    }
}
