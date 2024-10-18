using Microsoft.AspNetCore.Mvc;
using tester_final.Models;

namespace tester_final.Controllers
{
    public class EmployeesController : Controller
    {
       
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Name = "John Doe", HoursWorked = 40, HourlyRate = 15 },
            new Employee { Name = "Jane Smith", HoursWorked = 30, HourlyRate = 20 }
        };

        public ActionResult SubmitClaim()
        {
            // Ensure employees is not null
            if (employees == null)
            {
                return HttpNotFound("No employees found.");
            }
            return View(employees); 
        }

        private ActionResult HttpNotFound(string v)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Accept(string name)
        {
          
            TempData["Message"] = $"{name} has been accepted.";
            return RedirectToAction("SubmitClaim"); 
        }

        [HttpPost]
        public ActionResult Reject(string name)
        {
            
            TempData["Message"] = $"{name} has been rejected.";
            return RedirectToAction("SubmitClaim");
        }
    }
}
