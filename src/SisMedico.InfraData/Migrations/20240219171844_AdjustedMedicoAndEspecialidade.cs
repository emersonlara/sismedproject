using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisMedico.InfraData.Migrations;

public partial class AdjustedMedicoAndEspecialidade : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
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
            name: "MedicoEspecialidade",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                MedicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                EspecialidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MedicoEspecialidade", x => x.Id);
                table.ForeignKey(
                    name: "FK_MedicoEspecialidade_Especialidade_EspecialidadeId",
                    column: x => x.EspecialidadeId,
                    principalTable: "Especialidade",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_MedicoEspecialidade_Medico_MedicoId",
                    column: x => x.MedicoId,
                    principalTable: "Medico",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_MedicoEspecialidade_EspecialidadeId",
            table: "MedicoEspecialidade",
            column: "EspecialidadeId");

        migrationBuilder.CreateIndex(
            name: "IX_MedicoEspecialidade_MedicoId",
            table: "MedicoEspecialidade",
            column: "MedicoId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "MedicoEspecialidade");

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
}
