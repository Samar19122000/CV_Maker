using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SamarApp.Migrations
{
    public partial class UpdateIdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbAbouteme");

            migrationBuilder.DropTable(
                name: "TbEducation");

            migrationBuilder.DropTable(
                name: "TbLanguage");

            migrationBuilder.DropTable(
                name: "TbProjects");

            migrationBuilder.DropTable(
                name: "TbSlider");

            migrationBuilder.DropTable(
                name: "TbWorks");
        }
    }
}
