using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Exceptions
{
    public class ProductDoesNotExistException : Exception
    {
        // default constructor
        public ProductDoesNotExistException() : base("Product does not exist")
        {
            // empty body
        }
        // constructor for customizing error message
        public ProductDoesNotExistException(string message) : base(message)
        {
            // empty body
        }
    }
}
