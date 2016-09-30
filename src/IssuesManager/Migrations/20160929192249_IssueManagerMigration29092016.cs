using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IssuesManager.Migrations
{
    public partial class IssueManagerMigration29092016 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DecPassword",
                table: "Users",
                nullable: true);
        }
    }
}
