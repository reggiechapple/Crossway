using System.Linq;
using System.Threading.Tasks;
// using Crossways.Areas.Members.Models;
using Crossways.Data;
using Crossways.Data.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Crossways.Areas.Publishers.Controllers
{
    [Authorize(Roles = "Publisher")]
    [Area("Members")]
    [Route("[area]/{id}/[action]")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, 
            SignInManager<ApplicationUser> signInManager, 
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet("/[area]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}