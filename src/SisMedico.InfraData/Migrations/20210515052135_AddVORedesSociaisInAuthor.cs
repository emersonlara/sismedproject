using Microsoft.EntityFrameworkCore.Migrations;

namespace SisMedico.InfraData.Migrations;

public partial class AddVORedesSociaisInAuthor : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "SocialMedia");

        migrationBuilder.AddColumn<string>(
            name: "RedesSociais_Facebook",
            table: "Author",
            type: "varchar(90)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "RedesSociais_Instagram",
            table: "Author",
            type: "varchar(90)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "RedesSociais_Linkedin",
            table: "Author",
            type: "varchar(90)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "RedesSociais_Medium",
            table: "Author",
            type: "varchar(90)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "RedesSociais_Twitter",
            table: "Author",
            type: "varchar(90)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "RedesSociais_Youtube",
            table: "Author",
            type: "varchar(90)",
            nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "RedesSociais_Facebook",
            table: "Author");

        migrationBuilder.DropColumn(
            name: "RedesSociais_Instagram",
            table: "Author");

        migrationBuilder.DropColumn(
            name: "RedesSociais_Linkedin",
            table: "Author");

        migrationBuilder.DropColumn(
            name: "RedesSociais_Medium",
            table: "Author");

        migrationBuilder.DropColumn(
            name: "RedesSociais_Twitter",
            table: "Author");

        migrationBuilder.DropColumn(
            name: "RedesSociais_Youtube",
            table: "Author");

        migrationBuilder.CreateTable(
            name: "SocialMedia",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                EnumSocialMediaType = table.Column<int>(type: "int", nullable: false),
                LinkAddress = table.Column<string>(type: "varchar(90)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_SocialMedia", x => x.Id);
                table.ForeignKey(
                    name: "FK_SocialMedia_Author_AuthorId",
                    column: x => x.AuthorId,
                    principalTable: "Author",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_SocialMedia_AuthorId",
            table: "SocialMedia",
            column: "AuthorId");
    }
}
