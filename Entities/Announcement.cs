﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Announcement : BaseEntity
    {
        public string Date { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
