﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebAPI.Domain.Exepctions
{
    public class NotFoundEntityException : Exception
    {
        public NotFoundEntityException(string message) : base(message) { }
    }
}
