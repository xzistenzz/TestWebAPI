using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebAPI.Domain.Exepctions
{
    public class NotFriendsException : Exception
    {
        public NotFriendsException(string message) : base(message) { }
    }
}
