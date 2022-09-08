using FoodStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FoodStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        SouqcomContext db = new SouqcomContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(db);
        }
        [HttpPost]
        public IActionResult SubmitReview(Review model)
        {
            db.Reviews.Add(model);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Menu()
        {
            return View(db);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}