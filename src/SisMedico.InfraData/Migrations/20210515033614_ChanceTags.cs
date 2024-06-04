using Microsoft.EntityFrameworkCore.Migrations;

namespace SisMedico.InfraData.Migrations;

public partial class ChanceTags : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Paciente_EstadoPaciente_EstadoPacienteId",
            table: "Paciente");

        migrationBuilder.DropForeignKey(
            name: "FK_SocialMedia_Author_AuthorId",
            table: "SocialMedia");

        migrationBuilder.DropForeignKey(
            name: "FK_Tags_Author_AuthorId",
            table: "Tags");

        migrationBuilder.DropForeignKey(
            name: "FK_Telefone_Author_AuthorId",
            table: "Telefone");

        migrationBuilder.AlterColumn<string>(
            name: "Tag",
            table: "Tags",
            type: "varchar(90)",
            maxLength: 90,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Subject",
            table: "Tags",
            type: "varchar(90)",
            maxLength: 90,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "SourceAt",
            table: "Tags",
            type: "varchar(90)",
            maxLength: 1500,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Note",
            table: "Tags",
            type: "nvarchar(1800)",
            maxLength: 1800,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldNullable: true);

        migrationBuilder.AddForeignKey(
            name: "FK_Paciente_EstadoPaciente_EstadoPacienteId",
            table: "Paciente",
            column: "EstadoPacienteId",
            principalTable: "EstadoPaciente",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_SocialMedia_Author_AuthorId",
            table: "SocialMedia",
            column: "AuthorId",
            principalTable: "Author",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Tags_Author_AuthorId",
            table: "Tags",
            column: "AuthorId",
            principalTable: "Author",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Telefone_Author_AuthorId",
            table: "Telefone",
            column: "AuthorId",
            principalTable: "Author",
            principalColumn: "Id");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Paciente_EstadoPaciente_EstadoPacienteId",
            table: "Paciente");

        migrationBuilder.DropForeignKey(
            name: "FK_SocialMedia_Author_AuthorId",
            table: "SocialMedia");

        migrationBuilder.DropForeignKey(
            name: "FK_Tags_Author_AuthorId",
            table: "Tags");

        migrationBuilder.DropForeignKey(
            name: "FK_Telefone_Author_AuthorId",
            table: "Telefone");

        migrationBuilder.AlterColumn<string>(
            name: "Tag",
            table: "Tags",
            type: "varchar(90)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldMaxLength: 90);

        migrationBuilder.AlterColumn<string>(
            name: "Subject",
            table: "Tags",
            type: "varchar(90)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldMaxLength: 90);

        migrationBuilder.AlterColumn<string>(
            name: "SourceAt",
            table: "Tags",
            type: "varchar(90)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldMaxLength: 1500);

        migrationBuilder.AlterColumn<string>(
            name: "Note",
            table: "Tags",
            type: "varchar(90)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(1800)",
            oldMaxLength: 1800,
            oldNullable: true);

        migrationBuilder.AddForeignKey(
            name: "FK_Paciente_EstadoPaciente_EstadoPacienteId",
            table: "Paciente",
            column: "EstadoPacienteId",
            principalTable: "EstadoPaciente",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_SocialMedia_Author_AuthorId",
            table: "SocialMedia",
            column: "AuthorId",
            principalTable: "Author",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_Tags_Author_AuthorId",
            table: "Tags",
            column: "AuthorId",
            principalTable: "Author",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_Telefone_Author_AuthorId",
            table: "Telefone",
            column: "AuthorId",
            principalTable: "Author",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    }
}
