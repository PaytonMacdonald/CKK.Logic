using System;
using System.Collections.Generic;
using System.Linq;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Models
{
    public class Store : Entity, IStore
    {
        // PROPERTIES
        private List<StoreItem> _items = new List<StoreItem>();
        public List<StoreItem> Items 
        {  
            get 
            { 
                return _items; 
            } 
        }
        // METHODS
        public StoreItem AddStoreItem(Product prod, int quant)
        {
            if (quant < 0)
            {
                throw new InventoryItemStockTooLowException();
            }
            var item1 = FindStoreItemById(prod.Id);
            // check if item already exists in store
            if (item1 == null)
            {
                Items.Add(new StoreItem(prod, quant));
                item1 = Items.Last();
                return item1;
            }
            else if (item1 != null)
            {
                item1.Quantity += quant;
                return item1;
            }
            else
            {
                return null;
            }
        }
        public StoreItem RemoveStoreItem(int id, int quant)
        {
            if (quant < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var item1 = FindStoreItemById(id);
            if (item1 == null)
                throw new ProductDoesNotExistException();
            if (item1.Quantity - quant <= 0)
            {
                item1.Quantity = 0;
            }
            else
            {
                item1.Quantity -= quant;
            }
            return item1;
        }
        public StoreItem FindStoreItemById(int id)
        {
            if (id < 0)
                throw new InvalidIdException();
            var query = from Item in Items
                        where Item.Product.Id == id
                        select Item;
            var itemOutput = query.FirstOrDefault();
            if (itemOutput == null)
                return null;
            else
                return itemOutput;

        }
        public List<StoreItem> GetStoreItems()
        {
            return Items;
        }
    }
}
