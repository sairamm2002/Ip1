using Microsoft.EntityFrameworkCore;

namespace Prescriptions.Models
{
    public class PrescriptionDatabaseContext : DbContext
    {
        public PrescriptionDatabaseContext(DbContextOptions<PrescriptionDatabaseContext> options)
        : base(options) { }

        public DbSet<Prescription> Prescription { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prescription>().HasData(
                new Prescription
                {
                    PrescriptionId = 1,
                    MedicationName = "Lisinopril",
                    FillStatus = "Pending",
                    Cost = 15.30,
                    RequestTime = "2025-10-01"
                },
                new Prescription
                {
                    PrescriptionId = 2,
                    MedicationName = "Atorvastatin",
                    FillStatus = "Filled",
                    Cost = 25.00,
                    RequestTime = "2025-09-28"
                },
                new Prescription
                {
                    PrescriptionId = 3,
                    MedicationName = "Albuterol",
                    FillStatus = "Denied",
                    Cost = 18.75,
                    RequestTime = "2025-09-27"
                },
                new Prescription
                {
                    PrescriptionId = 4,
                    MedicationName = "Omeprazole",
                    FillStatus = "Pending",
                    Cost = 12.40,
                    RequestTime = "2025-10-02"
                },
                new Prescription
                {
                    PrescriptionId = 5,
                    MedicationName = "Levothyroxine",
                    FillStatus = "Filled",
                    Cost = 30.50,
                    RequestTime = "2025-09-25"
                }
            );
        }
    }
}
