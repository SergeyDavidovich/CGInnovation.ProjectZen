using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CGInnovation.ProjectZen.Migrations
{
    public partial class RemoveIsDeletedFromStrategies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppStrategies");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppStrategies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppStrategies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppStrategies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppStrategies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppStrategies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
