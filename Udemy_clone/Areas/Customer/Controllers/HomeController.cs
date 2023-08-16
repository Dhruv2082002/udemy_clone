using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Udemy_clone.Data;
using Udemy_clone.Models;

namespace Udemy_clone.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
			var VideoList = _db.Videos.Include(v => v.ApplicationUser).ToList();

			return View(VideoList);
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

        public IActionResult Details(int videoid)
        {
            //get video from db
            var video = _db.Videos.Include(v => v.ApplicationUser).FirstOrDefault(v => v.VideoId == videoid);
            return View(video);
        }

        [HttpPost]
        public IActionResult Details(Video video)
        {
			//get video from db
			return View();
		}
    }
}