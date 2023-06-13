﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Not Found")
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }
    }
}
