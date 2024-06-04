using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisMedico.InfraData.Migrations;

public partial class AdjustedMedicoAndEspecialidade2 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey(
            name: "PK_MedicoEspecialidade",
            table: "MedicoEspecialidade");

        migrationBuilder.DropIndex(
            name: "IX_MedicoEspecialidade_MedicoId",
            table: "MedicoEspecialidade");

        migrationBuilder.DropColumn(
            name: "Id",
            table: "MedicoEspecialidade");

        migrationBuilder.AddPrimaryKey(
            name: "PK_MedicoEspecialidade",
            table: "MedicoEspecialidade",
            columns: new[] { "MedicoId", "EspecialidadeId" });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey(
            name: "PK_MedicoEspecialidade",
            table: "MedicoEspecialidade");

        migrationBuilder.AddColumn<Guid>(
            name: "Id",
            table: "MedicoEspecialidade",
            type: "uniqueidentifier",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

        migrationBuilder.AddPrimaryKey(
            name: "PK_MedicoEspecialidade",
            table: "MedicoEspecialidade",
            column: "Id");

        migrationBuilder.CreateIndex(
            name: "IX_MedicoEspecialidade_MedicoId",
            table: "MedicoEspecialidade",
            column: "MedicoId");
    }
}
