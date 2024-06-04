using Microsoft.EntityFrameworkCore.Migrations;

namespace SisMedico.InfraData.Migrations;

public partial class AddNotificacaoNovoProntuario : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Triagem",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                CodigoPaciente = table.Column<Guid>(nullable: false),
                NomePaciente = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false),
                DataNotificacao = table.Column<DateTime>(nullable: false),
                Mensagem = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_NotificacaoNovoProntuario", x => x.Id);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Triagem");
    }
}
