using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Exceptions
{
    public class InvalidIdException : Exception
    {
        // default constructor
        public InvalidIdException() : base("Invalid id")
        {
            // empty body
        }
        // constructor for customizing error message
        public InvalidIdException(string message) : base(message)
        {
            // empty body
        }
    }
}
