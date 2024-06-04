using Microsoft.EntityFrameworkCore.Migrations;

namespace SisMedico.InfraData.Migrations;

public partial class AddVORedesSociaisInAuthorColumnOthers : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "Youtube",
            table: "Author",
            type: "varchar(400)",
            maxLength: 400,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Twitter",
            table: "Author",
            type: "varchar(400)",
            maxLength: 400,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Linkedin",
            table: "Author",
            type: "varchar(400)",
            maxLength: 400,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Instagram",
            table: "Author",
            type: "varchar(400)",
            maxLength: 400,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Facebook",
            table: "Author",
            type: "varchar(400)",
            maxLength: 400,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldNullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "Youtube",
            table: "Author",
            type: "varchar(90)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(400)",
            oldMaxLength: 400,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Twitter",
            table: "Author",
            type: "varchar(90)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(400)",
            oldMaxLength: 400,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Linkedin",
            table: "Author",
            type: "varchar(90)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(400)",
            oldMaxLength: 400,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Instagram",
            table: "Author",
            type: "varchar(90)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(400)",
            oldMaxLength: 400,
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Facebook",
            table: "Author",
            type: "varchar(90)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(400)",
            oldMaxLength: 400,
            oldNullable: true);
    }
}
