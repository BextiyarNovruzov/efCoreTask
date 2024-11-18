using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Helpers.Exceptions
{
    internal class UserNotFoundException : Exception
    {

        public UserNotFoundException(string message) : base(message) { }

    }
}
