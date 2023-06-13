using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Account
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Class { get; set; }
        public string WhoYouAre { get; set; }
    }
}
