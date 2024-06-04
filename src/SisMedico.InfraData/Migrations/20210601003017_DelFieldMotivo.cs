using Microsoft.EntityFrameworkCore.Migrations;

namespace SisMedico.InfraData.Migrations;

public partial class DelFieldMotivo : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Motivo",
            table: "Triagem");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "Motivo",
            table: "Triagem",
            type: "varchar(90)",
            maxLength: 30,
            nullable: true);
    }
}
