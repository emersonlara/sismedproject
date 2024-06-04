using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisMedico.InfraData.Migrations;

public partial class UpdAgendaEventos : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<Guid>(
            name: "ConvenioId",
            table: "AgendaEventos",
            type: "uniqueidentifier",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

        migrationBuilder.AddColumn<int>(
            name: "LocalExame",
            table: "AgendaEventos",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<int>(
            name: "TipoExame",
            table: "AgendaEventos",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<DateTime>(
            name: "ValidadeConvenio",
            table: "AgendaEventos",
            type: "datetime2",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.CreateIndex(
            name: "IX_AgendaEventos_ConvenioId",
            table: "AgendaEventos",
            column: "ConvenioId");

        migrationBuilder.AddForeignKey(
            name: "FK_AgendaEventos_Convenio_ConvenioId",
            table: "AgendaEventos",
            column: "ConvenioId",
            principalTable: "Convenio",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_AgendaEventos_Convenio_ConvenioId",
            table: "AgendaEventos");

        migrationBuilder.DropIndex(
            name: "IX_AgendaEventos_ConvenioId",
            table: "AgendaEventos");

        migrationBuilder.DropColumn(
            name: "ConvenioId",
            table: "AgendaEventos");

        migrationBuilder.DropColumn(
            name: "LocalExame",
            table: "AgendaEventos");

        migrationBuilder.DropColumn(
            name: "TipoExame",
            table: "AgendaEventos");

        migrationBuilder.DropColumn(
            name: "ValidadeConvenio",
            table: "AgendaEventos");
    }
}
