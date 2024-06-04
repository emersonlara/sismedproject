using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisMedico.InfraData.Migrations;

public partial class AdjustedMedicoEspecialidadeAndAgendamento : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_EspecialidadeMedico_Especialidade_EspecialidadeId",
            table: "EspecialidadeMedico");

        migrationBuilder.DropForeignKey(
            name: "FK_EspecialidadeMedico_Medico_MedicoId",
            table: "EspecialidadeMedico");

        migrationBuilder.DropTable(
            name: "Agendamento");

        migrationBuilder.DropTable(
            name: "LawyerEvent");

        migrationBuilder.DropTable(
            name: "Lawyers");

        migrationBuilder.RenameColumn(
            name: "MedicoId",
            table: "EspecialidadeMedico",
            newName: "MedicosId");

        migrationBuilder.RenameColumn(
            name: "EspecialidadeId",
            table: "EspecialidadeMedico",
            newName: "EspecialidadesId");

        migrationBuilder.RenameIndex(
            name: "IX_EspecialidadeMedico_MedicoId",
            table: "EspecialidadeMedico",
            newName: "IX_EspecialidadeMedico_MedicosId");

        migrationBuilder.AlterColumn<string>(
            name: "Nome",
            table: "Medico",
            type: "varchar(80)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Crm",
            table: "Medico",
            type: "varchar(35)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Descricao",
            table: "Especialidade",
            type: "varchar(80)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldNullable: true);

        migrationBuilder.AddForeignKey(
            name: "FK_EspecialidadeMedico_Especialidade_EspecialidadesId",
            table: "EspecialidadeMedico",
            column: "EspecialidadesId",
            principalTable: "Especialidade",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_EspecialidadeMedico_Medico_MedicosId",
            table: "EspecialidadeMedico",
            column: "MedicosId",
            principalTable: "Medico",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_EspecialidadeMedico_Especialidade_EspecialidadesId",
            table: "EspecialidadeMedico");

        migrationBuilder.DropForeignKey(
            name: "FK_EspecialidadeMedico_Medico_MedicosId",
            table: "EspecialidadeMedico");

        migrationBuilder.RenameColumn(
            name: "MedicosId",
            table: "EspecialidadeMedico",
            newName: "MedicoId");

        migrationBuilder.RenameColumn(
            name: "EspecialidadesId",
            table: "EspecialidadeMedico",
            newName: "EspecialidadeId");

        migrationBuilder.RenameIndex(
            name: "IX_EspecialidadeMedico_MedicosId",
            table: "EspecialidadeMedico",
            newName: "IX_EspecialidadeMedico_MedicoId");

        migrationBuilder.AlterColumn<string>(
            name: "Nome",
            table: "Medico",
            type: "varchar(90)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(80)");

        migrationBuilder.AlterColumn<string>(
            name: "Crm",
            table: "Medico",
            type: "varchar(90)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(35)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Descricao",
            table: "Especialidade",
            type: "varchar(90)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(80)");

        migrationBuilder.CreateTable(
            name: "Agendamento",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                MedicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Comentario = table.Column<string>(type: "varchar(90)", nullable: true),
                ConvenioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                DataAgendamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                LocalExame = table.Column<int>(type: "int", nullable: false),
                TipoExame = table.Column<int>(type: "int", nullable: false)
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
            name: "Lawyers",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                EmailAddres = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                FirstName = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                Hourly_rate = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                LastName = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                PhoneNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                Qualications = table.Column<int>(type: "int", nullable: false),
                Speciality = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Lawyers", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "LawyerEvent",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                LawyerId = table.Column<int>(type: "int", nullable: false),
                AllDay = table.Column<bool>(type: "bit", nullable: false),
                Color = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                Description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                End = table.Column<DateTime>(type: "datetime2", nullable: true),
                Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                Title = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_LawyerEvent", x => x.Id);
                table.ForeignKey(
                    name: "FK_LawyerEvent_Lawyers_LawyerId",
                    column: x => x.LawyerId,
                    principalTable: "Lawyers",
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
            name: "IX_LawyerEvent_LawyerId",
            table: "LawyerEvent",
            column: "LawyerId");

        migrationBuilder.AddForeignKey(
            name: "FK_EspecialidadeMedico_Especialidade_EspecialidadeId",
            table: "EspecialidadeMedico",
            column: "EspecialidadeId",
            principalTable: "Especialidade",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_EspecialidadeMedico_Medico_MedicoId",
            table: "EspecialidadeMedico",
            column: "MedicoId",
            principalTable: "Medico",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    }
}
