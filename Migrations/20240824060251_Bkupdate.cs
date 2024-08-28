using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicInfo.Migrations
{
    /// <inheritdoc />
    public partial class Bkupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_DoctorVisit_DoctorVisitID",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "DoctorVisitID",
                table: "Booking",
                newName: "DoctorID");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_DoctorVisitID",
                table: "Booking",
                newName: "IX_Booking_DoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Doctor_DoctorID",
                table: "Booking",
                column: "DoctorID",
                principalTable: "Doctor",
                principalColumn: "DoctorID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Doctor_DoctorID",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "DoctorID",
                table: "Booking",
                newName: "DoctorVisitID");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_DoctorID",
                table: "Booking",
                newName: "IX_Booking_DoctorVisitID");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_DoctorVisit_DoctorVisitID",
                table: "Booking",
                column: "DoctorVisitID",
                principalTable: "DoctorVisit",
                principalColumn: "DoctorVisitID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
