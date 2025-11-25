using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalJourneyLog.Migrations
{
    /// <inheritdoc />
    public partial class RenameFirstNameToName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Children",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Children",
                newName: "FirstName");
        }
    }
}
