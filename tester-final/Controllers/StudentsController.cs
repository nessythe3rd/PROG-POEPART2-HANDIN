using Microsoft.AspNetCore.Mvc;
using tester_final.Data;
using tester_final.Models;
using tester_final.Models.Entities;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace tester_final.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: Students/Add
        [HttpGet]
        public IActionResult Add()
        {
            var viewModel = new AddStudentViewModel
            {
                TotalAmount = 0
            };
            return View(viewModel);
        }

        // POST: Students/Add
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel, IFormFile supportingDocs)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            viewModel.TotalAmount = viewModel.HoursWorked * viewModel.HourlyRate;

            // Process the uploaded file if provided
            if (supportingDocs != null && supportingDocs.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", supportingDocs.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await supportingDocs.CopyToAsync(stream);
                }
            }

            // Create a new student entity and save it
            var student = new Student
            {
                Name = viewModel.Name,
                HoursWorked = viewModel.HoursWorked,
                HourlyRate = viewModel.HourlyRate,
                TotalAmount = viewModel.TotalAmount
            };

            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();

            // Set a success message
            ViewData["SuccessMessage"] = "Document uploaded and student added successfully.";

            // Redirect back to the Add page to refresh it
            return RedirectToAction("Add");
        }
    }
}
