using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions
{
    public class AlreadyExsistsException : Exception
    {
        public AlreadyExsistsException() : base("This entity already exsists")
        {
        }
        public AlreadyExsistsException(string message) : base(message)
        {
        }
        
    }
}
