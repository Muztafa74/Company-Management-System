using Company.Models;
using Company.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers
{
    public class TransferDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SetViewData(string name, int age) 
        {
            ViewData["name"] = name;
            ViewData["age"] = age;
            return View();
        }

        public IActionResult SetViewBag(string name, int age) 
        {
            ViewBag.Name = name;
            ViewBag.Age = age;


            ViewData["testData"] = "Welcome";
            ViewBag.testBag = "Mustafa";

            return View();
        }

        public IActionResult SetModel(Employee emp) 
        { 
            return View(emp);
        }

        public IActionResult SetViewModel (employeeDataVM employeeData)
        {
            return View(employeeData);
        }
    }
}
