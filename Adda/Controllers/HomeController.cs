using Adda.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Adda.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
