using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PFCAssignment1.Models;

namespace PFCAssignment1.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ProjectRole role)
        {
            var roleExist = await roleManager.RoleExistsAsync(role.RoleName);
            if (!roleExist) //If Role name does not exists create a new Role name
            {
                var result = await roleManager.CreateAsync(new IdentityRole(role.RoleName));
                ViewBag.message = "Role Added Successfully";
            }
            else
            {
                ViewBag.message = "Role Already Exists";
            }
            
            return View();
        }
    }
}
