using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IssuesManager.DL.Interfaces;
using IssuesManager.ViewModels;
using Microsoft.AspNetCore.Identity;
using IssuesManager.Models;
using IssuesManager.Tools;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IssuesManager.APIControllers
{
    [Route("/[controller]/[action]")]
    public class UserController : Controller
    {

        private readonly IUserRepository UserRepository;
        private readonly IEmailService EmailService;

        public UserController(IUserRepository UserRepo, IEmailService emailSender)
        {
            this.UserRepository = UserRepo;
            this.EmailService = emailSender;
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

            IssuesManagerUser user = new IssuesManagerUser()
            {
                UserName = data.UserName,
                Email = data.Email,
                FullName = data.Name,
                RegisterDate = DateTime.Today,
                EmailConfirmed = false
            };

            if ( await UserRepository.Add(user, data.Password))
            {

                string confirmationToken = await UserRepository.GenerateEmailConfirmation(user);

                string confirmationLink = Url.Action("ConfirmEmail",
                  "User", new
                  {
                      userid = user.Id,
                      token = confirmationToken
                  },
                   protocol: HttpContext.Request.Scheme);

                await EmailService.SendAsync(user.Email, "Confirm your IssuesManager Account", $"Follow this link to confirm your account, {confirmationLink} ");

                return true;
            }
            else
            {
                return false;
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userid, string token)
        {
            var Result =  await UserRepository.ConfirmEmail(userid, token);

            if(Result)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Home", "Error");
            }
        }
    }
}