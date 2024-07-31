using CA_Employee.Models;
using Microsoft.AspNetCore.Mvc;

namespace CA_Employee.Controllers
{
    public class LandingPageController : Controller
    {
        public IActionResult LandingPage()
        {
            List<Employee> employees = Employee.GetAllEmployees();

            return View(employees);
        }
    }
}
