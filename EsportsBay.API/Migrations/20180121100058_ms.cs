using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EsportsBay.API.Migrations
{
    public partial class ms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Team_Team1Id",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Team_Team2Id",
                table: "Match");

            migrationBuilder.DropIndex(
                name: "IX_Match_Team1Id",
                table: "Match");

            migrationBuilder.DropIndex(
                name: "IX_Match_Team2Id",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "Team1Id",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "Team2Id",
                table: "Match");

            migrationBuilder.AddColumn<string>(
                name: "TeamName1",
                table: "Match",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeamName2",
                table: "Match",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamName1",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "TeamName2",
                table: "Match");

            migrationBuilder.AddColumn<int>(
                name: "Team1Id",
                table: "Match",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Team2Id",
                table: "Match",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Match_Team1Id",
                table: "Match",
                column: "Team1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Match_Team2Id",
                table: "Match",
                column: "Team2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_Team1Id",
                table: "Match",
                column: "Team1Id",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_Team2Id",
                table: "Match",
                column: "Team2Id",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
