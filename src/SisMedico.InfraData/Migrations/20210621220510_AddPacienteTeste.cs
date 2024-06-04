using Microsoft.EntityFrameworkCore.Migrations;

namespace SisMedico.InfraData.Migrations;

public partial class AddPacienteTeste : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "PacienteTestes",
            columns: table => new
            {
                DT_RowId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ipAddress = table.Column<string>(type: "varchar(90)", nullable: true),
                status = table.Column<string>(type: "varchar(90)", nullable: true),
                port = table.Column<string>(type: "varchar(90)", nullable: true),
                odate = table.Column<string>(type: "varchar(90)", nullable: true),
                user = table.Column<string>(type: "varchar(90)", nullable: true),
                package = table.Column<string>(type: "varchar(90)", nullable: true),
                balance = table.Column<string>(type: "varchar(90)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PacienteTestes", x => x.DT_RowId);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "PacienteTestes");
    }
}
