using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IssuesManager.DL.Interfaces;
using IssuesManager.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IssuesManager.APIControllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository UserRepository;

        public UserController(IUserRepository UserRepo)
        {
            UserRepository = UserRepo;
        }

        // GET: api/values
        [HttpPost]
        public async Task<bool> Login([FromBody]LoginViewModel data)
        {
            return await UserRepository.Login(data.UserName, data.Password);
        }
    }
}
