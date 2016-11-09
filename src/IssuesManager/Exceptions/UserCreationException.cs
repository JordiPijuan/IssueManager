using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssuesManager.Exceptions
{
    public class UserCreationException : Exception
    {
        public UserCreationException(string message) : base(message)
        { }
    }
}
