using Company.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers
{
    public class EmployeeController : Controller
    {
        private CompanyContext context;
        public EmployeeController()
        {
            context = new CompanyContext();
        }
        public IActionResult Index()
        {
            List<Employee> employees = context.Employees.ToList();

            return View(employees);
        }
        public IActionResult Details(int id)
        {
            Employee employee = context.Employees.Where(s => s.Id == id).SingleOrDefault();
            if (employee == null)
            {
                return Content("Not Found");
            }
            return View(employee);
        }
        public IActionResult AddForm()
        {
            List<Office> offices = context.Offices.ToList();
            ViewBag.Off = offices;
            return View();
        }

        public IActionResult AddToDB(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Employee employee = context.Employees.SingleOrDefault(e => e.Id == id);
            ViewBag.Off = context.Offices.ToList();
            return View(employee);  
        }

        public IActionResult EditToDB(Employee employee)
        {

            Employee OldEmployee = context.Employees.SingleOrDefault(c => c.Id == employee.Id);

            OldEmployee.Name = employee.Name;
            OldEmployee.Age = employee.Age;
            OldEmployee.Address = employee.Address;
            OldEmployee.Email = employee.Email;
            OldEmployee.Salary = employee.Salary;
            OldEmployee.Password = employee.Password;
            OldEmployee.Office_id = employee.Office_id;

            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            Employee employee = context.Employees.SingleOrDefault(e => e.Id == id);
            context.Employees.Remove(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
