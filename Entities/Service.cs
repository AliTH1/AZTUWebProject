﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Service : BaseEntity
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public bool IsDeleted { get; set; }
    }
}
