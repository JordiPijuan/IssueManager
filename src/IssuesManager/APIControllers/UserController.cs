using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IssuesManager.DL.Interfaces;
using IssuesManager.ViewModels;
using Microsoft.AspNetCore.Identity;
using IssuesManager.Models;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IssuesManager.APIControllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {

        private readonly IUserRepository UserRepository;

        public UserController(IUserRepository UserRepo)
        {
            this.UserRepository = UserRepo;

        }

        [HttpPost]
        public async Task<bool> Login([FromBody]LoginViewModel data)
        {
            return await UserRepository.Login(data.UserName, data.Password, data.Remember);
        }

        [HttpPost]
        public async Task<bool> Register([FromBody] RegisterViewModel data)
        {
            if (data.Password != data.RePassword)
                return false;

            if( await UserRepository.Add(new IssuesManagerUser()
                    {
                        UserName = data.UserName,
                        Email = data.Email,
                        FullName = data.Name,
                        RegisterDate = DateTime.Today,
                    }, data.Password))
            {
                return await UserRepository.Login(data.UserName, data.Password, true);
            }
            else
            {
                return false;
            }
        }
    }
}
