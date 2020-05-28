using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Doctors",
                table => new
                {
                    Id = table.Column<string>("nvarchar(450)", nullable: false),
                    Name = table.Column<string>("nvarchar(max)", nullable: true),
                    Surname = table.Column<string>("nvarchar(max)", nullable: true),
                    Age = table.Column<int>("int", nullable: false),
                    Gender = table.Column<string>("nvarchar(max)", nullable: true),
                    Experience = table.Column<int>("int", nullable: false),
                    Degree = table.Column<string>("nvarchar(max)", nullable: true),
                    Workday = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Doctors", x => x.Id); });

            migrationBuilder.CreateTable(
                "Patients",
                table => new
                {
                    Id = table.Column<string>("nvarchar(450)", nullable: false),
                    Name = table.Column<string>("nvarchar(max)", nullable: true),
                    Surname = table.Column<string>("nvarchar(max)", nullable: true),
                    Age = table.Column<int>("int", nullable: false),
                    Gender = table.Column<string>("nvarchar(max)", nullable: true),
                    EPS = table.Column<string>("nvarchar(max)", nullable: true),
                    Stratum = table.Column<int>("int", nullable: false),
                    Discount = table.Column<double>("float", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Patients", x => x.Id); });

            migrationBuilder.CreateTable(
                "Prescriptions",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>("datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>("datetime2", nullable: false),
                    State = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Prescriptions", x => x.Id); });

            migrationBuilder.CreateTable(
                "StratumConfigurations",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StratumOne = table.Column<double>("float", nullable: false),
                    StratumTwo = table.Column<double>("float", nullable: false),
                    StratumThree = table.Column<double>("float", nullable: false),
                    StratumFour = table.Column<double>("float", nullable: false),
                    StratumFive = table.Column<double>("float", nullable: false),
                    StratumSix = table.Column<double>("float", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_StratumConfigurations", x => x.Id); });

            migrationBuilder.CreateTable(
                "WorkdayConfigurations",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorWorkday = table.Column<string>("nvarchar(max)", nullable: true),
                    PediatricianWorkday = table.Column<string>("nvarchar(max)", nullable: true),
                    OphthalmologistWorkday = table.Column<string>("nvarchar(max)", nullable: true),
                    DentistWorkday = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_WorkdayConfigurations", x => x.Id); });

            migrationBuilder.CreateTable(
                "MedicalExams",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>("nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>("datetime2", nullable: false),
                    Hour = table.Column<DateTime>("datetime2", nullable: false),
                    PatientId = table.Column<string>("nvarchar(450)", nullable: true),
                    State = table.Column<string>("nvarchar(max)", nullable: true),
                    Cost = table.Column<double>("float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalExams", x => x.Id);
                    table.ForeignKey(
                        "FK_MedicalExams_Patients_PatientId",
                        x => x.PatientId,
                        "Patients",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "MedicalAppointments",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<string>("nvarchar(450)", nullable: true),
                    PatientId = table.Column<string>("nvarchar(450)", nullable: true),
                    Hour = table.Column<DateTime>("datetime2", nullable: false),
                    Date = table.Column<DateTime>("datetime2", nullable: false),
                    PrescriptionId = table.Column<int>("int", nullable: true),
                    State = table.Column<string>("nvarchar(max)", nullable: true),
                    Cost = table.Column<double>("float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAppointments", x => x.Id);
                    table.ForeignKey(
                        "FK_MedicalAppointments_Doctors_DoctorId",
                        x => x.DoctorId,
                        "Doctors",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_MedicalAppointments_Patients_PatientId",
                        x => x.PatientId,
                        "Patients",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_MedicalAppointments_Prescriptions_PrescriptionId",
                        x => x.PrescriptionId,
                        "Prescriptions",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Medicine",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>("nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>("int", nullable: false),
                    Periodicity = table.Column<double>("float", nullable: false),
                    PrescriptionId = table.Column<int>("int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.Id);
                    table.ForeignKey(
                        "FK_Medicine_Prescriptions_PrescriptionId",
                        x => x.PrescriptionId,
                        "Prescriptions",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_MedicalAppointments_DoctorId",
                "MedicalAppointments",
                "DoctorId");

            migrationBuilder.CreateIndex(
                "IX_MedicalAppointments_PatientId",
                "MedicalAppointments",
                "PatientId");

            migrationBuilder.CreateIndex(
                "IX_MedicalAppointments_PrescriptionId",
                "MedicalAppointments",
                "PrescriptionId");

            migrationBuilder.CreateIndex(
                "IX_MedicalExams_PatientId",
                "MedicalExams",
                "PatientId");

            migrationBuilder.CreateIndex(
                "IX_Medicine_PrescriptionId",
                "Medicine",
                "PrescriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "MedicalAppointments");

            migrationBuilder.DropTable(
                "MedicalExams");

            migrationBuilder.DropTable(
                "Medicine");

            migrationBuilder.DropTable(
                "StratumConfigurations");

            migrationBuilder.DropTable(
                "WorkdayConfigurations");

            migrationBuilder.DropTable(
                "Doctors");

            migrationBuilder.DropTable(
                "Patients");

            migrationBuilder.DropTable(
                "Prescriptions");
        }
    }
}