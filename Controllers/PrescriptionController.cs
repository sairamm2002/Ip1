using Microsoft.AspNetCore.Mvc;
using Prescriptions.Models;

namespace Prescriptions.Controllers
{
    public class PrescriptionController : Controller
    {
        private PrescriptionDatabaseContext context { get; set; }

        public PrescriptionController(PrescriptionDatabaseContext ctx) => context = ctx;

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Prescription());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var prescription = context.Prescription.Find(id);
            return View(prescription);
        }

        [HttpPost]
        public IActionResult Edit(Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                if (prescription.PrescriptionId == 0)
                    context.Prescription.Add(prescription);
                else
                    context.Prescription.Update(prescription);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (prescription.PrescriptionId == 0) ? "Add" : "Edit";
                return View(prescription);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var prescription = context.Prescription.Find(id);
            return View(prescription);
        }

        [HttpPost]
        public IActionResult Delete(Prescription prescription)
        {
            context.Prescription.Remove(prescription);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
