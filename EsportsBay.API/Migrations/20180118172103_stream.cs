using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EsportsBay.API.Migrations
{
    public partial class stream : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Stream",
                newName: "Language");

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Stream",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Game",
                table: "Stream",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Stream",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Stream");

            migrationBuilder.DropColumn(
                name: "Game",
                table: "Stream");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Stream");

            migrationBuilder.RenameColumn(
                name: "Language",
                table: "Stream",
                newName: "Name");
        }
    }
}
