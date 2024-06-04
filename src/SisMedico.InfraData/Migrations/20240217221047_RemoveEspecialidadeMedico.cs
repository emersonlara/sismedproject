using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisMedico.InfraData.Migrations;

public partial class RemoveEspecialidadeMedico : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "EspecialidadeMedico");

        migrationBuilder.AddColumn<Guid>(
            name: "MedicoId",
            table: "Especialidade",
            type: "uniqueidentifier",
            nullable: true);

        migrationBuilder.CreateIndex(
            name: "IX_Especialidade_MedicoId",
            table: "Especialidade",
            column: "MedicoId");

        migrationBuilder.AddForeignKey(
            name: "FK_Especialidade_Medico_MedicoId",
            table: "Especialidade",
            column: "MedicoId",
            principalTable: "Medico",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Especialidade_Medico_MedicoId",
            table: "Especialidade");

        migrationBuilder.DropIndex(
            name: "IX_Especialidade_MedicoId",
            table: "Especialidade");

        migrationBuilder.DropColumn(
            name: "MedicoId",
            table: "Especialidade");

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
            name: "IX_EspecialidadeMedico_MedicoId",
            table: "EspecialidadeMedico",
            column: "MedicoId");
    }
}
