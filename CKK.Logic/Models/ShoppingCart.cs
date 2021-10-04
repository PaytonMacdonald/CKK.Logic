using System;
using System.Collections.Generic;
using System.Linq;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;


namespace CKK.Logic.Models
{
    public class ShoppingCart : IShoppingCart
    {
        // PROPERTIES
        public Customer Customer { get; set; }

        private List<ShoppingCartItem> _products = new List<ShoppingCartItem>();
        public List<ShoppingCartItem> Products 
        { 
            get 
            { 
                return _products; 
            } 
        }

        // CONSTRUCTOR
        public ShoppingCart(Customer customer)
            {
                Customer = customer;
            }

        // METHODS
        public int GetCustomerId()
        {
            return Customer.Id;
        }
        public ShoppingCartItem AddProduct(Product product, int quant)
        {
            if (quant <= 0)
            {
                throw new InventoryItemStockTooLowException();
            }
            var item = GetProductById(product.Id);
            // check if item already exists in cart
            if (item == null)
            {
                Products.Add(new ShoppingCartItem(product, quant));
                item = Products.Last();
                return item;
            }
            else if (item != null && item.Quantity >= 0)
            {
                item.Quantity = item.Quantity + quant;
                return item;
            }
            else
            {
                return null;
            }
        }










        // //////////////////////////////////////////////////////////////
        public ShoppingCartItem RemoveProduct(int id, int quant)
        {
            if (quant < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var item1 = GetProductById(id);
            if (item1 == null)
                throw new ProductDoesNotExistException();
            item1.Quantity -= quant;
            if (item1.Quantity <= 0)
            {
                var itemRemoved = item1;
                itemRemoved.Quantity = 0;
                Products.Remove(item1); // is this done correctly?????
                return itemRemoved;
            }
            else
            {
                return item1;
            }
        }
        // //////////////////////////////////////////////////////////////










        public decimal GetTotal()
        {
            var queryPrices = from Item in Products
                              let Total = Item.Product.Price * Item.Quantity
                              select Total;
            return queryPrices.Sum();
        }









        // //////////////////////////////////////////////////////////////
        public ShoppingCartItem GetProductById(int id)
        {
            if (id < 0)
                throw new InvalidIdException();


            var query = from Item in Products 
                        where Item.Product.Id == id
                        select Item;
            var itemOutput = query.FirstOrDefault();
            if (query != null)
                return itemOutput;
            else
                return null;
        }
        // //////////////////////////////////////////////////////////////










        public List<ShoppingCartItem> GetProducts()
        {
            return Products;
        }
    }
}
