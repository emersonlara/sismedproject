using Microsoft.EntityFrameworkCore.Migrations;

namespace SisMedico.InfraData.Migrations;

public partial class AddPacienteTeste3 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        //migrationBuilder.DropColumn(
        //    name: "DT_RowId",
        //    table: "PacienteTestes");

        migrationBuilder.AlterColumn<int>(
            name: "port",
            table: "PacienteTestes",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "odate",
            table: "PacienteTestes",
            type: "datetime2",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldNullable: true);

        migrationBuilder.AlterColumn<decimal>(
            name: "balance",
            table: "PacienteTestes",
            type: "decimal(18,2)",
            nullable: false,
            defaultValue: 0m,
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldNullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "port",
            table: "PacienteTestes",
            type: "varchar(90)",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<string>(
            name: "odate",
            table: "PacienteTestes",
            type: "varchar(90)",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime2");

        migrationBuilder.AlterColumn<string>(
            name: "balance",
            table: "PacienteTestes",
            type: "varchar(90)",
            nullable: true,
            oldClrType: typeof(decimal),
            oldType: "decimal(18,2)");

        //migrationBuilder.AddColumn<int>(
        //    name: "DT_RowId",
        //    table: "PacienteTestes",
        //    type: "int",
        //    nullable: false,
        //    defaultValue: 0);
    }
}
