﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Exceptions
{
    public class AlreadyIsExistsException : Exception
    {
        public AlreadyIsExistsException() : base("Already Is Exists")
        {
        }

        public AlreadyIsExistsException(string? message) : base(message)
        {
        }
    }
}
