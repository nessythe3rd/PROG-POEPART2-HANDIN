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

       //getting Data from table
        [HttpGet]
        public IActionResult Add()
        {
            var viewModel = new AddStudentViewModel
            {
                TotalAmount = 0
            };
            return View(viewModel);
        }
        //Post from Add Form
        
        public async Task<IActionResult> Add(AddStudentViewModel viewModel, IFormFile supportingDocs)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            viewModel.TotalAmount = viewModel.HoursWorked * viewModel.HourlyRate;

           
            if (supportingDocs != null && supportingDocs.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", supportingDocs.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await supportingDocs.CopyToAsync(stream);
                }
            }

            
            var student = new Student
            {
                Name = viewModel.Name,
                HoursWorked = viewModel.HoursWorked,
                HourlyRate = viewModel.HourlyRate,
                TotalAmount = viewModel.TotalAmount
            };

            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();

           
            ViewData["SuccessMessage"] = "Document uploaded and student added successfully.";

           
            return RedirectToAction("Add");
        }
    }
}
