using Company.Models;
using Company.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Company.Controllers
{
    public class validationController : Controller
    {

        private CompanyContext context;
        public validationController()
        {
            context = new CompanyContext();
        }
        //Add Employee with validation
        [HttpGet]
        public IActionResult Add()
        {
            EmployeeVM employee = new EmployeeVM()
            {
                Offices = new SelectList(context.Offices, "Id", "Name")
            };
            return View(employee);
           
        }
        [HttpPost]
        public IActionResult Add(EmployeeVM employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = new Employee()
                {
                    Name = employee.Name,
                    Age = employee.Age,
                    Address = employee.Address,
                    Salary = employee.Salary,
                    Email = employee.Email,
                    Office_id = employee.Office_id,
                };
                context.Employees.Add(newEmployee);
                context.SaveChanges();
                return RedirectToAction("Index", "Employee");

            }
            employee.Offices = new SelectList(context.Offices, "Id" , "Name");
            return View(employee);

        }

    }
}
