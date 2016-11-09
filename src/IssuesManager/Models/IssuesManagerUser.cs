using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IssuesManager.Models
{
    public class IssuesManagerUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime RegisterDate {get; set;}
    }
}
