using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Prescriptions.Migrations
{
    /// <inheritdoc />
    public partial class WalgreensPrescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    PrescriptionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MedicationName = table.Column<string>(type: "TEXT", nullable: false),
                    FillStatus = table.Column<string>(type: "TEXT", nullable: false),
                    Cost = table.Column<double>(type: "REAL", nullable: false),
                    RequestTime = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.PrescriptionId);
                });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "PrescriptionId", "Cost", "FillStatus", "MedicationName", "RequestTime" },
                values: new object[,]
                {
                    { 1, 15.300000000000001, "Pending", "Lisinopril", "2025-10-01" },
                    { 2, 25.0, "Filled", "Atorvastatin", "2025-09-28" },
                    { 3, 18.75, "Denied", "Albuterol", "2025-09-27" },
                    { 4, 12.4, "Pending", "Omeprazole", "2025-10-02" },
                    { 5, 30.5, "Filled", "Levothyroxine", "2025-09-25" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription");
        }
    }
}
