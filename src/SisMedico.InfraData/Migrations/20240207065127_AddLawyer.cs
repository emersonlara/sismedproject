using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisMedico.InfraData.Migrations;

public partial class AddLawyer : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "NomeConvenio",
            table: "Agendamento");

        migrationBuilder.DropColumn(
            name: "NomeMedico",
            table: "Agendamento");

        migrationBuilder.DropColumn(
            name: "NomePaciente",
            table: "Agendamento");

        migrationBuilder.CreateTable(
            name: "Lawyers",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                FirstName = table.Column<string>(type: "varchar(90)", nullable: false),
                LastName = table.Column<string>(type: "varchar(90)", nullable: false),
                DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                Hourly_rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                Qualications = table.Column<int>(type: "int", nullable: false),
                Speciality = table.Column<int>(type: "int", nullable: false),
                EmailAddres = table.Column<string>(type: "varchar(90)", nullable: false),
                PhoneNumber = table.Column<string>(type: "varchar(90)", nullable: true),
                DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Lawyers", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "LawyerEvent",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                LawyerId = table.Column<int>(type: "int", nullable: false),
                Title = table.Column<string>(type: "varchar(90)", nullable: true),
                Description = table.Column<string>(type: "varchar(90)", nullable: true),
                Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                End = table.Column<DateTime>(type: "datetime2", nullable: true),
                Color = table.Column<string>(type: "varchar(90)", nullable: true),
                AllDay = table.Column<bool>(type: "bit", nullable: false),
                DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_LawyerEvent", x => x.Id);
                table.ForeignKey(
                    name: "FK_LawyerEvent_Lawyers_LawyerId",
                    column: x => x.LawyerId,
                    principalTable: "Lawyers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_LawyerEvent_LawyerId",
            table: "LawyerEvent",
            column: "LawyerId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "LawyerEvent");

        migrationBuilder.DropTable(
            name: "Lawyers");

        migrationBuilder.AddColumn<string>(
            name: "NomeConvenio",
            table: "Agendamento",
            type: "varchar(90)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "NomeMedico",
            table: "Agendamento",
            type: "varchar(90)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "NomePaciente",
            table: "Agendamento",
            type: "varchar(90)",
            nullable: true);
    }
}
