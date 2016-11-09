using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IssuesManager.Security;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IssuesManager.Controllers
{
    [Authorize]
    public class LandingController : Controller
    {
        [Authorize(Roles = RolesDefinition.Contributor)]
        public IActionResult Index()
        {
            return View();
        }
    }
}