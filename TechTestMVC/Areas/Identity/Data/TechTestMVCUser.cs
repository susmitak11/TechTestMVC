using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TechTestMVC.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the TechTestMVCUser class
    public class TechTestMVCUser : IdentityUser
    {
        public string Role { get; set; }
    }
}
