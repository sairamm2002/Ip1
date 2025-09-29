using Microsoft.AspNetCore.Mvc;
using Prescriptions.Models;

namespace Prescriptions.Controllers
{
    public class HomeController : Controller
    {
        private PrescriptionDatabaseContext context { get; set; }

        public HomeController(PrescriptionDatabaseContext ctx) => context = ctx;

        public IActionResult Index()
        {
            var prescriptions = context.Prescription
                .OrderBy(m => m.MedicationName).ToList();
            return View(prescriptions);
        }
    }
}
