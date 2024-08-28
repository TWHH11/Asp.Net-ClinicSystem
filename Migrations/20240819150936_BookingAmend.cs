using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicInfo.Migrations
{
    /// <inheritdoc />
    public partial class BookingAmend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_DoctorVisit_DoctorVisitID",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Patient_PatientID",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorVisit_Doctor_DoctorID",
                table: "DoctorVisit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patient",
                table: "Patient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorVisit",
                table: "DoctorVisit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctor",
                table: "Doctor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_PatientID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "BookingID",
                table: "Booking");

            migrationBuilder.RenameTable(
                name: "Patient",
                newName: "Course");

            migrationBuilder.RenameTable(
                name: "DoctorVisit",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "Doctor",
                newName: "Enrollment");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Department");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorVisit_DoctorID",
                table: "Student",
                newName: "IX_Student_DoctorID");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_DoctorVisitID",
                table: "Department",
                newName: "IX_Department_DoctorVisitID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "PatientID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "DoctorVisitID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment",
                column: "DoctorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                columns: new[] { "PatientID", "DoctorVisitID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Course_PatientID",
                table: "Department",
                column: "PatientID",
                principalTable: "Course",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Student_DoctorVisitID",
                table: "Department",
                column: "DoctorVisitID",
                principalTable: "Student",
                principalColumn: "DoctorVisitID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Enrollment_DoctorID",
                table: "Student",
                column: "DoctorID",
                principalTable: "Enrollment",
                principalColumn: "DoctorID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Course_PatientID",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Student_DoctorVisitID",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Enrollment_DoctorID",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "DoctorVisit");

            migrationBuilder.RenameTable(
                name: "Enrollment",
                newName: "Doctor");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Booking");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Patient");

            migrationBuilder.RenameIndex(
                name: "IX_Student_DoctorID",
                table: "DoctorVisit",
                newName: "IX_DoctorVisit_DoctorID");

            migrationBuilder.RenameIndex(
                name: "IX_Department_DoctorVisitID",
                table: "Booking",
                newName: "IX_Booking_DoctorVisitID");

            migrationBuilder.AddColumn<int>(
                name: "BookingID",
                table: "Booking",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorVisit",
                table: "DoctorVisit",
                column: "DoctorVisitID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctor",
                table: "Doctor",
                column: "DoctorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "BookingID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patient",
                table: "Patient",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PatientID",
                table: "Booking",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_DoctorVisit_DoctorVisitID",
                table: "Booking",
                column: "DoctorVisitID",
                principalTable: "DoctorVisit",
                principalColumn: "DoctorVisitID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Patient_PatientID",
                table: "Booking",
                column: "PatientID",
                principalTable: "Patient",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorVisit_Doctor_DoctorID",
                table: "DoctorVisit",
                column: "DoctorID",
                principalTable: "Doctor",
                principalColumn: "DoctorID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
