﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Account
{
    public class StudentInfo
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Group { get; set; }
        public string Gender { get; set; }
        public int UserId { get; set; }
    }
}
