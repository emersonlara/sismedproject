using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisMedico.InfraData.Migrations;

public partial class AddEspecialidadeMedico : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
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

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_EspecialidadeMedico_Especialidade_EspecialidadeId",
            table: "EspecialidadeMedico");

        migrationBuilder.DropForeignKey(
            name: "FK_EspecialidadeMedico_Medico_MedicoId",
            table: "EspecialidadeMedico");

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
}
