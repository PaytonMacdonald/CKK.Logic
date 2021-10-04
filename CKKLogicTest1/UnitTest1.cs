using Microsoft.VisualStudio.TestTools.UnitTesting;
using CKK.Logic.Models;

namespace CKKLogicTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddProduct_toShoppingkart()
        {
            // Create a Customer
            Customer testCustomer = new Customer();
            testCustomer.SetId(1);
            testCustomer.SetName("Bob");
            testCustomer.SetAddress("1234 Fake Street");
 
            // Create a Product
            Product testProduct = new Product();
            testProduct.SetId(1);
            testProduct.SetName("Taco");
            testProduct.SetPrice(2.99m);
            int testQuantity = 1;

            // Create a Shopping Cart Item
            ShoppingCartItem testShoppingCartItem = new ShoppingCartItem( testProduct, testQuantity);

            // Create a Shopping Cart
            ShoppingCart testShoppingCart = new ShoppingCart(testCustomer);

            // add item to Cart
            testShoppingCart.AddProduct(testShoppingCartItem);

            ShoppingCartItem expected = testShoppingCartItem;
            ShoppingCartItem actual = testShoppingCart.GetProductById(1);
            // check if object is build correctly
            Assert.AreEqual(expected, actual, "testProduct is the same as Product1");

        }        
        [TestMethod]
        public void RemoveProduct_fromShoppingkart()
        {
            // Create a Customer
            Customer testCustomer = new Customer();
            testCustomer.SetId(1);
            testCustomer.SetName("Bob");
            testCustomer.SetAddress("1234 Fake Street");
 
            // Create a Product
            Product testProduct = new Product();
            testProduct.SetId(1);
            testProduct.SetName("Taco");
            testProduct.SetPrice(2.99m);
            int testQuantity = 1;

            // Create a Shopping Cart Item
            ShoppingCartItem testShoppingCartItem = new ShoppingCartItem( testProduct, testQuantity);

            // Create a Shopping Cart
            ShoppingCart testShoppingCart = new ShoppingCart(testCustomer);

            // add item to Cart
            testShoppingCart.AddProduct(testShoppingCartItem);
            testShoppingCart.RemoveProduct(1, 1);

            ShoppingCartItem expected = null;
            ShoppingCartItem actual = testShoppingCart.GetProductById(1);
            // check if object is build correctly
            Assert.AreEqual(expected, actual, "Product 1 was removed");

        }

        [TestMethod]
        public void GetTotal_ofShoppingCart()
        {
            // Create a Customer
            Customer testCustomer = new Customer();
            testCustomer.SetId(1);
            testCustomer.SetName("Bob");
            testCustomer.SetAddress("1234 Fake Street");

            // Create a Product
            Product testProduct1 = new Product();
            testProduct1.SetId(1);
            testProduct1.SetName("Taco");
            testProduct1.SetPrice(5.00m);
            int testQuantity1 = 3;

            Product testProduct2 = new Product();
            testProduct2.SetId(2);
            testProduct2.SetName("Hamburger");
            testProduct2.SetPrice(10.00m);
            int testQuantity2 = 2;

            // Create a Shopping Cart Item
            ShoppingCartItem testShoppingCartItem1 = new ShoppingCartItem(testProduct1, testQuantity1);
            ShoppingCartItem testShoppingCartItem2 = new ShoppingCartItem(testProduct2, testQuantity2);

            // Create a Shopping Cart
            ShoppingCart testShoppingCart = new ShoppingCart(testCustomer);

            // add item to Cart
            testShoppingCart.AddProduct(testShoppingCartItem1);
            testShoppingCart.AddProduct(testShoppingCartItem2);

            decimal expected = 35.00m;
            decimal actual = testShoppingCart.GetTotal();
            // check if object is build correctly
            Assert.AreEqual(expected, actual, "expected total is correct");

        }
    }
}
