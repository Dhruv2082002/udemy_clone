using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Udemy_clone.Models;

namespace Udemy_clone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<Video> Videos { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        //seed video data with 3 entries

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Video>().HasData(
                new Video
                               {
                    VideoId = 1,
                    Title = "Video 1",
                    Thumbnail = "https://via.placeholder.com/150",
                    Description = "Video 1 Description",
                    VideoUrl = "https://www.youtube.com/embed/1",
                    Duration = 100,
                    Price = 120,
                    ApplicationUserId = "993cdd02-003f-4cbd-93e2-b13d6baeaa57"
                },
                new Video
                {
                    VideoId = 2,
                    Title = "Video 2",
                    Thumbnail = "https://via.placeholder.com/150",
                    Description = "Video 2 Description",
                    VideoUrl = "https://www.youtube.com/embed/2",
                    Price = 250,
                    Duration = 200,
                    ApplicationUserId = "993cdd02-003f-4cbd-93e2-b13d6baeaa57"

                },
                new Video
                {
                    VideoId = 3,
                    Title = "Video 3",
                    Thumbnail = "https://via.placeholder.com/150",
                    Description = "Video 3 Description",
                    VideoUrl = "https://www.youtube.com/embed/3",
                    Price = 310,
                    Duration = 300,
                    ApplicationUserId = "993cdd02-003f-4cbd-93e2-b13d6baeaa57"
                }
                                                                        );
        }   


    }
}
