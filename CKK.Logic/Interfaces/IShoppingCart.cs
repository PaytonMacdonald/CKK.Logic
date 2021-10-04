using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;

namespace CKK.Logic.Interfaces
{
    public interface IShoppingCart
    {
        // PROPERTIES
        public Customer Customer { get; set; }

        // METHODS
        int GetCustomerId();
        ShoppingCartItem AddProduct(Product product, int quant);
        ShoppingCartItem RemoveProduct(int id, int quant);
        decimal GetTotal();
        ShoppingCartItem GetProductById(int id);
        List<ShoppingCartItem> GetProducts();






    }
}
