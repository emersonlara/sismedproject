﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SisMedico.Mvc.Migrations;

public partial class AddImgProfilePath : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "ImgProfilePath",
            table: "AspNetUsers",
            maxLength: 255,
            nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "ImgProfilePath",
            table: "AspNetUsers");
    }
}
