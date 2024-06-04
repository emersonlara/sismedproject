using Microsoft.EntityFrameworkCore.Migrations;

namespace SisMedico.InfraData.Migrations;

public partial class AddNewTablesOfTheTempCooperchip : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Author",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                Name = table.Column<string>(type: "varchar(90)", nullable: true),
                LastName = table.Column<string>(type: "varchar(90)", nullable: true),
                EmailAddress = table.Column<string>(type: "varchar(90)", nullable: true),
                WebSite = table.Column<string>(type: "varchar(90)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Author", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "SocialMedia",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                EnumSocialMediaType = table.Column<int>(nullable: false),
                AuthorId = table.Column<Guid>(nullable: false),
                LinkAddress = table.Column<string>(type: "varchar(90)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_SocialMedia", x => x.Id);
                table.ForeignKey(
                    name: "FK_SocialMedia_Author_AuthorId",
                    column: x => x.AuthorId,
                    principalTable: "Author",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Tags",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                Tag = table.Column<string>(type: "varchar(90)", nullable: true),
                Subject = table.Column<string>(type: "varchar(90)", nullable: true),
                Note = table.Column<string>(type: "varchar(90)", nullable: true),
                SourceAt = table.Column<string>(type: "varchar(90)", nullable: true),
                AuthorId = table.Column<Guid>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Tags", x => x.Id);
                table.ForeignKey(
                    name: "FK_Tags_Author_AuthorId",
                    column: x => x.AuthorId,
                    principalTable: "Author",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Telefone",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                AuthorId = table.Column<Guid>(nullable: false),
                Ddd = table.Column<string>(type: "varchar(90)", nullable: true),
                Numero = table.Column<string>(type: "varchar(90)", nullable: true),
                TipoTelefone = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Telefone", x => x.Id);
                table.ForeignKey(
                    name: "FK_Telefone_Author_AuthorId",
                    column: x => x.AuthorId,
                    principalTable: "Author",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_SocialMedia_AuthorId",
            table: "SocialMedia",
            column: "AuthorId");

        migrationBuilder.CreateIndex(
            name: "IX_Tags_AuthorId",
            table: "Tags",
            column: "AuthorId");

        migrationBuilder.CreateIndex(
            name: "IX_Telefone_AuthorId",
            table: "Telefone",
            column: "AuthorId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "SocialMedia");

        migrationBuilder.DropTable(
            name: "Tags");

        migrationBuilder.DropTable(
            name: "Telefone");

        migrationBuilder.DropTable(
            name: "Author");
    }
}
