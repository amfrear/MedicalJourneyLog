using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalJourneyLog.Migrations
{
    /// <inheritdoc />
    public partial class AddNameToSymptom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Symptoms",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Symptoms");
        }
    }
}
