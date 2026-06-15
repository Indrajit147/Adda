using Adda.Data;
using Adda.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Adda.ViewModels.Home;

namespace Adda.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allPosts = await _context.Posts
                .OrderByDescending(p => p.DateCreated)
                .Include(n => n.User)
                .ToListAsync();


            return View(allPosts);
        }

        [HttpPost]
        public async Task<IActionResult>CreatePost (PostVM post)

        {
            //Get the loggedin user
            int loggedInUser = 1;

            //Create a new post object
            var newPost = new Post
            {
                Content = post.Content,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow,
                ImageUrl="",
                NrOfReports = 0,
                UserId = loggedInUser
            };

            //Add the post to the database
            await _context.Posts.AddAsync(newPost);
            await _context.SaveChangesAsync();

            //Redirect to the index page
            return RedirectToAction("Index");
        }
    }
}
