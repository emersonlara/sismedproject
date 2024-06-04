using Microsoft.EntityFrameworkCore.Migrations;

namespace SisMedico.InfraData.Migrations;

public partial class AddPacienteTeste2 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        //migrationBuilder.DropPrimaryKey(
        //    name: "PK_PacienteTestes",
        //    table: "PacienteTestes");

        //migrationBuilder.AlterColumn<int>(
        //    name: "DT_RowId",
        //    table: "PacienteTestes",
        //    type: "int",
        //    nullable: false,
        //    oldClrType: typeof(int),
        //    oldType: "int")
        //    .OldAnnotation("SqlServer:Identity", "1, 1");

        migrationBuilder.AddColumn<Guid>(
            name: "Id",
            table: "PacienteTestes",
            type: "uniqueidentifier",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

        //migrationBuilder.AddPrimaryKey(
        //    name: "PK_PacienteTestes",
        //    table: "PacienteTestes",
        //    column: "Id");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        //migrationBuilder.DropPrimaryKey(
        //    name: "PK_PacienteTestes",
        //    table: "PacienteTestes");

        migrationBuilder.DropColumn(
            name: "Id",
            table: "PacienteTestes");

        //migrationBuilder.AlterColumn<int>(
        //    name: "DT_RowId",
        //    table: "PacienteTestes",
        //    type: "int",
        //    nullable: false,
        //    oldClrType: typeof(int),
        //    oldType: "int")
        //    .Annotation("SqlServer:Identity", "1, 1");

        //migrationBuilder.AddPrimaryKey(
        //    name: "PK_PacienteTestes",
        //    table: "PacienteTestes",
        //    column: "DT_RowId");
    }
}
