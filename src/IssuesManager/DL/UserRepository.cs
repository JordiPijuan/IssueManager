using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using IssuesManager.Models;
using IssuesManager.Security;

namespace IssuesManager.DL
{
    using Exceptions;
    using Interfaces;

    public class UserRepository : IUserRepository
    {
        private readonly IssuesContext db;
        private readonly UserManager<IssuesManagerUser> userManager;
        private readonly SignInManager<IssuesManagerUser> loginManager;
        private readonly RoleManager<IssuesManagerRole> roleManager;

        public UserRepository(IssuesContext db, UserManager<IssuesManagerUser> userManager,
               SignInManager<IssuesManagerUser> loginManager, RoleManager<IssuesManagerRole> roleManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.loginManager = loginManager;
            this.roleManager = roleManager;
        }

        public async Task<bool> Login(string UserName, string Password, bool remember)
        {
            var result = await loginManager.PasswordSignInAsync(UserName, Password, remember, false);
            return result.Succeeded;
        }

        public async Task<bool> Add(IssuesManagerUser user, string Password)
        {
            var result = await userManager.CreateAsync(user, Password);
            if(result.Succeeded)
            {
                if(!await roleManager.RoleExistsAsync(RolesDefinition.Contributor))
                {
                    IssuesManagerRole role = new IssuesManagerRole();
                    role.Name = RolesDefinition.Contributor;

                    IdentityResult roleResult = await roleManager.CreateAsync(role);
                    if(!roleResult.Succeeded)
                    {
                        var DeleteResult = await userManager.DeleteAsync(user);

                        if (!DeleteResult.Succeeded)
                            throw new UserCreationException("Database Connection Error");
                        return false;
                    }
                }

                await userManager.AddToRoleAsync(user, RolesDefinition.Contributor);
                return true;
            }
            else
            {
                throw new UserCreationException("User could not be created");
            }
        }
    }
}