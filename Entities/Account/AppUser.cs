using Entities.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Account
{
    public class AppUser : IdentityUser<int>
    {
        public StudentInfo StudentInfo { get; set; }
        public TeacherInfo TeacherInfo { get; set; }
    }
}
