using System.ComponentModel.DataAnnotations;

namespace Prescriptions.Models
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }

        [Required(ErrorMessage = "Please enter a MedicationName.")]
        public string MedicationName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a FillStatus.")]
        public string FillStatus { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Cost.")]
        public double? Cost { get; set; }

        [Required(ErrorMessage = "Please enter a RequestTime.")]
        public string? RequestTime { get; set; }
    }
}
