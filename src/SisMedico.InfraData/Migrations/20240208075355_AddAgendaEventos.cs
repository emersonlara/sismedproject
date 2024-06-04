using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisMedico.InfraData.Migrations;

public partial class AddAgendaEventos : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "AgendaEventos",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                MedicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Title = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                Description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                End = table.Column<DateTime>(type: "datetime2", nullable: true),
                Color = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                AllDay = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AgendaEventos", x => x.Id);
                table.ForeignKey(
                    name: "FK_AgendaEventos_Medico_MedicoId",
                    column: x => x.MedicoId,
                    principalTable: "Medico",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_AgendaEventos_Paciente_PacienteId",
                    column: x => x.PacienteId,
                    principalTable: "Paciente",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_AgendaEventos_MedicoId",
            table: "AgendaEventos",
            column: "MedicoId");

        migrationBuilder.CreateIndex(
            name: "IX_AgendaEventos_PacienteId",
            table: "AgendaEventos",
            column: "PacienteId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "AgendaEventos");
    }
}
