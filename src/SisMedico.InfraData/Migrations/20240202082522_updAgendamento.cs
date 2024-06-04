using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisMedico.InfraData.Migrations;

public partial class updAgendamento : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Convenio",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Nome = table.Column<string>(type: "varchar(90)", nullable: true),
                PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Validade = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Convenio", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Especialidade",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Descricao = table.Column<string>(type: "varchar(90)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Especialidade", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Medico",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Nome = table.Column<string>(type: "varchar(90)", nullable: true),
                Crm = table.Column<string>(type: "varchar(90)", nullable: true),
                DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Medico", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Agendamento",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                MedicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                ConvenioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                NomePaciente = table.Column<string>(type: "varchar(90)", nullable: true),
                NomeMedico = table.Column<string>(type: "varchar(90)", nullable: true),
                NomeConvenio = table.Column<string>(type: "varchar(90)", nullable: true),
                DataAgendamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                TipoExame = table.Column<int>(type: "int", nullable: false),
                LocalExame = table.Column<int>(type: "int", nullable: false),
                Comentario = table.Column<string>(type: "varchar(90)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Agendamento", x => x.Id);
                table.ForeignKey(
                    name: "FK_Agendamento_Medico_MedicoId",
                    column: x => x.MedicoId,
                    principalTable: "Medico",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Agendamento_Paciente_PacienteId",
                    column: x => x.PacienteId,
                    principalTable: "Paciente",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "EspecialidadeMedico",
            columns: table => new
            {
                EspecialidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                MedicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EspecialidadeMedico", x => new { x.EspecialidadeId, x.MedicoId });
                table.ForeignKey(
                    name: "FK_EspecialidadeMedico_Especialidade_EspecialidadeId",
                    column: x => x.EspecialidadeId,
                    principalTable: "Especialidade",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_EspecialidadeMedico_Medico_MedicoId",
                    column: x => x.MedicoId,
                    principalTable: "Medico",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Agendamento_MedicoId",
            table: "Agendamento",
            column: "MedicoId");

        migrationBuilder.CreateIndex(
            name: "IX_Agendamento_PacienteId",
            table: "Agendamento",
            column: "PacienteId");

        migrationBuilder.CreateIndex(
            name: "IX_EspecialidadeMedico_MedicoId",
            table: "EspecialidadeMedico",
            column: "MedicoId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Agendamento");

        migrationBuilder.DropTable(
            name: "Convenio");

        migrationBuilder.DropTable(
            name: "EspecialidadeMedico");

        migrationBuilder.DropTable(
            name: "Especialidade");

        migrationBuilder.DropTable(
            name: "Medico");
    }
}
