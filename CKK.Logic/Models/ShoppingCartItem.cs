using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
    public class ShoppingCartItem : InventoryItem
    {

        // CONSTRUCTOR
        public ShoppingCartItem(Product product, int quantity) : base (product, quantity)
        {

        }

        // METHODS
        public decimal GetTotal()
        {
            return Quantity * Product.Price;
        }
    }
}
