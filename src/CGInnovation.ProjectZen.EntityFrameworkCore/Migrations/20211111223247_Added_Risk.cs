using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CGInnovation.ProjectZen.Migrations
{
    public partial class Added_Risk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRisks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Occures = table.Column<bool>(type: "bit", nullable: false),
                    OccuredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mitigation = table.Column<int>(type: "int", nullable: false),
                    MitigationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Impact = table.Column<int>(type: "int", nullable: false),
                    Likelihood = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRisks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRisks");
        }
    }
}
