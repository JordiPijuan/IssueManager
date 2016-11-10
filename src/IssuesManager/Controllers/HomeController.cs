using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IssuesManager.DL.Interfaces;
using Microsoft.AspNetCore.Identity;
using IssuesManager.Models;
using Microsoft.AspNetCore.Authorization;

namespace IssuesManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<IssuesManagerUser> loginManager;

        public HomeController(SignInManager<IssuesManagerUser> loginManager)
        {
            this.loginManager = loginManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {         
            if(HttpContext.User != null && HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Landing");
            }

            return View();
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View("Shared/Error");
        }

        [Authorize]
        public async Task<IActionResult> LogOff()
        {
            await loginManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}