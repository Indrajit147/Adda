using Adda.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Adda.Data.Helpers
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(AppDbContext appDbContext)
        {
            // Check if there are any users in the database
            if (!appDbContext.Users.Any() && !appDbContext.Posts.Any())
            {
                // If not, create a sample user
                var newUser = new User()
                {
                    FullName = "Indrajit Gupta",
                    ProfilePictureUrl = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_960_720.png"

                };
                await appDbContext.Users.AddAsync(newUser);
                await appDbContext.SaveChangesAsync();

                var newPostWithoutImage = new Post()
                {
                    Content= "This is going to be our first post which is being loaded from the database and it has been created using our test user.",
                    ImageUrl="",
                    NrOfReports = 0,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow,

                    UserId = newUser.Id
                };

                var newPostWithImage = new Post()
                {
                    Content = "This is going to be our first post which is being loaded from the database and it has been created using our test user. This post has an image.",
                    ImageUrl = "https://unsplash.com/photos/foggy-mountain-summit-1Z2niiBPg5A",
                    NrOfReports = 0,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow,
                    UserId = newUser.Id
                };

                await appDbContext.Posts.AddRangeAsync(newPostWithoutImage, newPostWithImage);
                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
