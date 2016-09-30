using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IssuesManager.DL
{
    using Interfaces;

    public class UserRepository : IUserRepository
    {
        private IssuesContext db { get; set; }
        public UserRepository(IssuesContext db)
        {
            this.db = db;
        }

        public async Task<bool> Login(string UserName, string Password)
        {
            return await db.Users.Where(x => x.UserName == UserName && x.DecPassword == Password).CountAsync() > 0;
        }
    }
}
