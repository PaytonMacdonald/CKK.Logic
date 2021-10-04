using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Exceptions
{
    public class InventoryItemStockTooLowException : Exception
    {
        // default constructor
        public InventoryItemStockTooLowException() : base("Inventory item stock is too low")
        {
            // empty body
        }
        // constructor for customizing error message
        public InventoryItemStockTooLowException(string message) : base(message)
        {
            // empty body
        }
    }
}
