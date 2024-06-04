using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisMedico.InfraData.Migrations;

public partial class AddLawyerEvent2 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "PhoneNumber",
            table: "Lawyers",
            type: "varchar(50)",
            maxLength: 50,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "LastName",
            table: "Lawyers",
            type: "varchar(150)",
            maxLength: 150,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(90)");

        migrationBuilder.AlterColumn<decimal>(
            name: "Hourly_rate",
            table: "Lawyers",
            type: "decimal(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            oldClrType: typeof(decimal),
            oldType: "decimal(18,2)");

        migrationBuilder.AlterColumn<string>(
            name: "FirstName",
            table: "Lawyers",
            type: "varchar(150)",
            maxLength: 150,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(90)");

        migrationBuilder.AlterColumn<string>(
            name: "EmailAddres",
            table: "Lawyers",
            type: "varchar(250)",
            maxLength: 250,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(90)");

        migrationBuilder.AlterColumn<string>(
            name: "Title",
            table: "LawyerEvent",
            type: "varchar(150)",
            maxLength: 150,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Description",
            table: "LawyerEvent",
            type: "varchar(300)",
            maxLength: 300,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Color",
            table: "LawyerEvent",
            type: "varchar(100)",
            maxLength: 100,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "varchar(90)",
            oldNullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "PhoneNumber",
            table: "Lawyers",
            type: "varchar(90)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(50)",
            oldMaxLength: 50);

        migrationBuilder.AlterColumn<string>(
            name: "LastName",
            table: "Lawyers",
            type: "varchar(90)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(150)",
            oldMaxLength: 150);

        migrationBuilder.AlterColumn<decimal>(
            name: "Hourly_rate",
            table: "Lawyers",
            type: "decimal(18,2)",
            nullable: false,
            oldClrType: typeof(decimal),
            oldType: "decimal(18,6)",
            oldPrecision: 18,
            oldScale: 6);

        migrationBuilder.AlterColumn<string>(
            name: "FirstName",
            table: "Lawyers",
            type: "varchar(90)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(150)",
            oldMaxLength: 150);

        migrationBuilder.AlterColumn<string>(
            name: "EmailAddres",
            table: "Lawyers",
            type: "varchar(90)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(250)",
            oldMaxLength: 250);

        migrationBuilder.AlterColumn<string>(
            name: "Title",
            table: "LawyerEvent",
            type: "varchar(90)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(150)",
            oldMaxLength: 150);

        migrationBuilder.AlterColumn<string>(
            name: "Description",
            table: "LawyerEvent",
            type: "varchar(90)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(300)",
            oldMaxLength: 300);

        migrationBuilder.AlterColumn<string>(
            name: "Color",
            table: "LawyerEvent",
            type: "varchar(90)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "varchar(100)",
            oldMaxLength: 100);
    }
}
