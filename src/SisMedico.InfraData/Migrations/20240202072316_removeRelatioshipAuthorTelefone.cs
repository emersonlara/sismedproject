using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisMedico.InfraData.Migrations;

public partial class removeRelatioshipAuthorTelefone : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Telefone_Author_AuthorId",
            table: "Telefone");


        migrationBuilder.DropColumn(
            name: "AuthorId",
            table: "Telefone");

        migrationBuilder.RenameColumn(
            name: "Ddd",
            table: "Telefone",
            newName: "DDD");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "DDD",
            table: "Telefone",
            newName: "Ddd");

        migrationBuilder.AddColumn<Guid>(
            name: "AuthorId",
            table: "Telefone",
            type: "uniqueidentifier",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));


        migrationBuilder.AddForeignKey(
            name: "FK_Telefone_Author_AuthorId",
            table: "Telefone",
            column: "AuthorId",
            principalTable: "Author",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    }
}
