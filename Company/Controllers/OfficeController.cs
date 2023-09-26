using Company.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Company.Controllers
{
    public class OfficeController : Controller
    {
        private CompanyContext context;
        public OfficeController()
        {
            context = new CompanyContext();
        }
        public IActionResult Index()
        {
            List<Office> offices = context.Offices.ToList();
            return View(offices);
        }

            public IActionResult Details(int id)
            {
            Office office = context.Offices.Where(s => s.Id == id).SingleOrDefault();
            if (office == null)
            {
                return Content("Not Found");
            }
            return View(office);
        }
        public IActionResult Add()
        {
            List<Office> offices = context.Offices.ToList();
            ViewBag.Off = offices;
            return View();
        }

        public IActionResult AddToDB(Office office)
        {
            context.Offices.Add(office);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Office office = context.Offices.SingleOrDefault(e => e.Id == id);
            ViewBag.Off = context.Offices.ToList();
            return View(office);
        }

        public IActionResult EditToDB(Office office)
        {

            Office OldOffice = context.Offices.SingleOrDefault(c => c.Id == office.Id);

            OldOffice.Name = office.Name;
            OldOffice.Location = office.Location;
         
            context.SaveChanges();
            return RedirectToAction("Index");

        }


        public IActionResult Delete(int id)
        {
            Office office = context.Offices.SingleOrDefault(e => e.Id == id);
            context.Offices.Remove(office);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
