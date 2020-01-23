using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mentoring.OfficeBuilder.DAL.Migrations
{
    public partial class MentoringOfficeBuilderDAL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbAreas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Html = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbTransition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SvgId = table.Column<Guid>(nullable: true),
                    ElementId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbTransition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbTransition_DbAreas_SvgId",
                        column: x => x.SvgId,
                        principalTable: "DbAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbTransition_SvgId",
                table: "DbTransition",
                column: "SvgId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbTransition");

            migrationBuilder.DropTable(
                name: "DbAreas");
        }
    }
}
