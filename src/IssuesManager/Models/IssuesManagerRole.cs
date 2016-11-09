using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssuesManager.Models
{
    public class IssuesManagerRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
