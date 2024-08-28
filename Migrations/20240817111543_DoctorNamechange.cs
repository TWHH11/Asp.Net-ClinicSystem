using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicInfo.Migrations
{
    /// <inheritdoc />
    public partial class DoctorNamechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Doctor");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Doctor",
                newName: "FullName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Doctor",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Doctor",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
