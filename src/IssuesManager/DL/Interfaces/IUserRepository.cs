using IssuesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssuesManager.DL.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> Login(string UserName, string Password, bool remember);
        Task<bool> Add(IssuesManagerUser user, string Password);
    }
}
