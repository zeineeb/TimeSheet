using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimesheetAPP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Intit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConsomationId",
                table: "Consomations",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Consomations",
                newName: "ConsomationId");
        }
    }
}
