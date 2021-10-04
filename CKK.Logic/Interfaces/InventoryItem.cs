using System;
using CKK.Logic.Models;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Interfaces
{
    public abstract class  InventoryItem
    {
        // PROPERTIES
        private int _quantity;
        public Product Product { get; set; }
        public int Quantity 
        { 

            get
            {
                return _quantity;
            }
            set
            {
                if (value < 0)
                    throw new InventoryItemStockTooLowException();
                _quantity = value;
            }
        }

        // CONSTRUCTOR
        public InventoryItem(Product prod, int quantity)
        {
            Product = prod;
            Quantity = quantity;
        }
    }
}
