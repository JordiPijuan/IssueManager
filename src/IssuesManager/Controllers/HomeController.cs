using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IssuesManager.DL.Interfaces;

namespace IssuesManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository UserRepository;

        public HomeController (IUserRepository UserRepo)
        {
           UserRepository = UserRepo;
        }

        public IActionResult Index()
        {         
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
