using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VideosMission6.Models;

namespace VideosMission6.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext _context;

        public HomeController(ApplicationContext temp) //Constructor
        {
            _context = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Application()
        {
            ViewBag.Majors = _context.Majors.ToList();

            return View(new Application());
        }

        [HttpPost]
        public IActionResult Application(Application response)
        {
            if (ModelState.IsValid)
            {
                _context.Applications.Add(response); // Add record to the database
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Majors = _context.Majors.ToList();

                return View(response);
            }
            
        }

        public IActionResult Waitlist() 
        {
            // Link
            var applications = _context.Applications
                .Where(x => x.CreeperStalker == false)
                .OrderBy(x => x.LastName).ToList();

            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Applications
                .Single(x => x.ApplicationID == id);

            ViewBag.Majors = _context.Majors.ToList();

            return View("Application", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Application updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("Waitlist");
        }

        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    var recordToDelete = _context.Applications
        //        .Single(x => x.ApplicationID == id);

        //    return View(recordToDelete);
        //}

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Applications
                .Single(x => x.ApplicationID == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Application deletedInfo)
        {
            _context.Applications.Remove(deletedInfo);
            _context.SaveChanges();

            return RedirectToAction("Waitlist");
        }
    }
}
