using Microsoft.EntityFrameworkCore.Migrations;

namespace SisMedico.InfraData.Migrations;

public partial class ChanceAuthor : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "WebSite",
            table: "Author",
            type: "varchar(500)",
            maxLength: 255,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Author",
            type: "varchar(50)",
            maxLength: 50,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "LastName",
            table: "Author",
            type: "varchar(70)",
            maxLength: 70,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "EmailAddress",
            table: "Author",
            type: "varchar(255)",
            maxLength: 255,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldNullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "WebSite",
            table: "Author",
            type: "varchar(90)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(500)",
            oldMaxLength: 255,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Author",
            type: "varchar(90)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(50)",
            oldMaxLength: 50);

        migrationBuilder.AlterColumn<string>(
            name: "LastName",
            table: "Author",
            type: "varchar(90)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(70)",
            oldMaxLength: 70,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "EmailAddress",
            table: "Author",
            type: "varchar(90)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(255)",
            oldMaxLength: 255,
            oldNullable: true);
    }
}
