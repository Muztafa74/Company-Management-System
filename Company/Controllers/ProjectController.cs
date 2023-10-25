using Company.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Controllers
{
    public class ProjectController : Controller
    {
        private CompanyContext context;
        public ProjectController()
        {
            context = new CompanyContext();
        }
        public IActionResult Index()
        {
            List<Project> projects = context.Projects.ToList();

            return View(projects);
        }

        public IActionResult Details(int id)
        {
            Project project = context.Projects.Include(i => i.emp_Projects).SingleOrDefault(i => i.Id == id);
            if (project == null)
            {
                return Content("Not Found");
            }
            return View(project);
        }


        [HttpGet]
        public IActionResult Add()
        {
            List<Project> projects = context.Projects.ToList();
            ViewBag.Off = projects;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Project project)
        {
            context.Projects.Add(project);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Project project = context.Projects.SingleOrDefault(e => e.Id == id);
            ViewBag.proj = context.Projects.ToList();
            return View(project);
        }
        [HttpPost]
        public IActionResult Edit(Project project)
        {

            Project OldProject = context.Projects.SingleOrDefault(c => c.Id == project.Id);

            OldProject.Name = project.Name;
            OldProject.Description = project.Description;
      

            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            Project project = context.Projects.SingleOrDefault(e => e.Id == id);
            context.Projects.Remove(project);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
