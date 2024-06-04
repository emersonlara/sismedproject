using Microsoft.EntityFrameworkCore.Migrations;

namespace SisMedico.InfraData.Migrations;

public partial class ChangeFieldNoteToNvarcharMax : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "Note",
            table: "Tags",
            type: "nvarchar(MAX)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(1800)",
            oldMaxLength: 1800,
            oldNullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "Note",
            table: "Tags",
            type: "nvarchar(1800)",
            maxLength: 1800,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(MAX)",
            oldNullable: true);
    }
}
