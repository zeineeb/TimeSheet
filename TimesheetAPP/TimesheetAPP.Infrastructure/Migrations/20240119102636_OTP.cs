using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimesheetAPP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OTP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "Intervenants",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Otp",
                table: "Intervenants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Otp",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "Intervenants");

            migrationBuilder.DropColumn(
                name: "Otp",
                table: "Intervenants");

            migrationBuilder.DropColumn(
                name: "Otp",
                table: "AspNetUsers");
        }
    }
}
