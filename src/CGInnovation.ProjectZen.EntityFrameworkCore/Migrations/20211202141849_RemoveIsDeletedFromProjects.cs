using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CGInnovation.ProjectZen.Migrations
{
    public partial class RemoveIsDeletedFromProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppProjects");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppProjects");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppProjects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppProjects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppProjects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppProjects",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
