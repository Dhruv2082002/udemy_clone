using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Udemy_clone.Data;
using Udemy_clone.Models;
using Udemy_clone.Utility;

namespace Udemy_clone.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.AdminUser + "," + SD.InstructorUser)]
    public class ContentController : Controller
    {
        // init db in ctor

        private readonly ApplicationDbContext _db;

        public ContentController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            if (User.IsInRole(SD.AdminUser))
            {
                var VideoList = _db.Videos.Include(v => v.ApplicationUser).ToList();
                return View(VideoList);
            }
            else
            {
                // Get the currently logged-in user's ID
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Get the videos that belong to the currently logged-in user
                var VideoList = _db.Videos.Include(v => v.ApplicationUser).Where(v => v.ApplicationUserId == userId).ToList();
                return View(VideoList);
            }
            
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormFile Vidfile, IFormFile Imgfile, Video video)
        {
            // Get the currently logged-in user's ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Assign the instructor's ID to the video
            video.ApplicationUserId = userId;

            if (Vidfile != null)
            {
                //upload video file to wwwroot/lectures
                var vidFileName = Guid.NewGuid().ToString() + Path.GetExtension(Vidfile.FileName);
                var vidFilePath = Path.Combine("wwwroot", "lectures", vidFileName);

                using (var stream = new FileStream(vidFilePath, FileMode.Create))
                {
                    Vidfile.CopyTo(stream);
                }
                video.VideoUrl = "/lectures/" + vidFileName;

            }

            if (Imgfile != null)
            {
                //upload image file to wwwroot/images
                var imgFileName = Guid.NewGuid().ToString() + Path.GetExtension(Imgfile.FileName);
                var imgFilePath = Path.Combine("wwwroot", "images", imgFileName);

                using (var stream = new FileStream(imgFilePath, FileMode.Create))
                {
                    Imgfile.CopyTo(stream);
                }
                video.Thumbnail = "/images/" + imgFileName;

                //update video object
            }
            //upload image file to wwwroot/images


            //update video object

            _db.Videos.Add(video);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            //delete video
            var video = _db.Videos.Find(id);
            _db.Videos.Remove(video);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Edit(int id)
        {
            var video = _db.Videos.Find(id);
            return View(video);
        }

        [HttpPost]
        public IActionResult Edit(IFormFile Vidfile, IFormFile Imgfile, Video video)
        {
            var existingVideo = _db.Videos.FirstOrDefault(v => v.VideoId == video.VideoId);

            if (existingVideo == null)
            {
                return NotFound();
            }

            // Keep the original thumbnail and video URL if files are not provided
            if (Vidfile == null)
            {
                video.VideoUrl = existingVideo.VideoUrl;
            }

            if (Imgfile == null)
            {
                video.Thumbnail = existingVideo.Thumbnail;
            }

            // Update other properties of the video object
            existingVideo.Title = video.Title;
            existingVideo.Description = video.Description;
            existingVideo.Duration = video.Duration;

            // Handle video file upload
            if (Vidfile != null)
            {
                // Upload video file to wwwroot/lectures
                var vidFileName = Guid.NewGuid().ToString() + Path.GetExtension(Vidfile.FileName);
                var vidFilePath = Path.Combine("wwwroot", "lectures", vidFileName);

                using (var stream = new FileStream(vidFilePath, FileMode.Create))
                {
                    Vidfile.CopyTo(stream);
                }

                // Update video URL if changed
                existingVideo.VideoUrl = "/lectures/" + vidFileName;
            }

            // Handle thumbnail file upload
            if (Imgfile != null)
            {
                // Upload image file to wwwroot/images
                var imgFileName = Guid.NewGuid().ToString() + Path.GetExtension(Imgfile.FileName);
                var imgFilePath = Path.Combine("wwwroot", "images", imgFileName);

                using (var stream = new FileStream(imgFilePath, FileMode.Create))
                {
                    Imgfile.CopyTo(stream);
                }

                // Update thumbnail URL if changed
                existingVideo.Thumbnail = "/images/" + imgFileName;
            }

            _db.Videos.Update(existingVideo);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
