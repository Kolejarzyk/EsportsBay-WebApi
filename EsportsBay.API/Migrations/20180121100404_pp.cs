using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EsportsBay.API.Migrations
{
    public partial class pp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeamName2",
                table: "Match",
                newName: "Team2");

            migrationBuilder.RenameColumn(
                name: "TeamName1",
                table: "Match",
                newName: "Team1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Team2",
                table: "Match",
                newName: "TeamName2");

            migrationBuilder.RenameColumn(
                name: "Team1",
                table: "Match",
                newName: "TeamName1");
        }
    }
}
