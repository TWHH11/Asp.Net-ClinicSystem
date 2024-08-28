using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicInfo.Migrations
{
    /// <inheritdoc />
    public partial class PhoneUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "Patient",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "Doctor",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Doctor");
        }
    }
}
