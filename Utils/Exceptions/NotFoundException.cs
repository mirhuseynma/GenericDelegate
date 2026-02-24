using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("This entity was not found")
        {
        }
        public NotFoundException(string message) : base(message)
        {
        }
        
    }
}
