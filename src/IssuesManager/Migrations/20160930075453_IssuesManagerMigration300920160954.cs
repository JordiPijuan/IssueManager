using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IssuesManager.Migrations
{
    public partial class IssuesManagerMigration300920160954 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Users",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                maxLength: 100,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                maxLength: 150,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "DecPassword",
                table: "Users",
                maxLength: 25,
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Users",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "DecPassword",
                table: "Users",
                nullable: false);
        }
    }
}
