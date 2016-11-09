using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using IssuesManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IssuesManager.DL
{
    public class IssuesContext : IdentityDbContext<IssuesManagerUser, IssuesManagerRole, string>
    {
        public IssuesContext(DbContextOptions<IssuesContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
