using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crossways.Areas.Administrators.Models;
using Crossways.Data;
using Crossways.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crossways.Areas.Administrators.Controllers
{
    
    // [Authorize(Roles = "admin")]
    [Area("Administrators")]
    [Route("[area]/[controller]/[action]")]
    public class UsersController : Controller
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet("/[area]/[controller]")]
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToListAsync();
            return View(users);
        }

        public IActionResult Create()
        {
            var user = new ApplicationUser();
            user.UserRoles = new List<ApplicationUserRole>();
            PopulateAssignedRoleData(user);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Email,Password")] UserInputModel model, string[] selectedRoles)
        {
            
            var user = new ApplicationUser
            {
                FullName = model.FullName,
                UserName = model.Email,
                Email = model.Email
            };

            if (selectedRoles != null)
            {
                user.UserRoles = new List<ApplicationUserRole>();
                foreach (var role in selectedRoles)
                {
                    var roleToAdd = new ApplicationUserRole { UserId = user.Id, RoleId = role };
                    user.UserRoles.Add(roleToAdd);
                }
            }

            if (ModelState.IsValid)
            {
                await _userManager.CreateAsync(user, model.Password);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateAssignedRoleData(user);
            return View(model);
        }

        private void PopulateAssignedRoleData(ApplicationUser user)
        {
            var allRoles = _roleManager.Roles.ToList();
            var userRoles = new HashSet<string>(user.UserRoles.Select(t => t.RoleId));
            var viewModel = new List<AssignedRole>();

            foreach(var role in allRoles)
            {
                viewModel.Add(new AssignedRole
                {
                    RoleId = role.Id,
                    Name = role.Name,
                    Assigned = userRoles.Contains(role.Id)
                });
            }
            ViewData["Roles"] = viewModel;
        }
    }
}