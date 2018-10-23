using System;
using System.Collections.Generic;
using ShoppingCartProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingCartTest
{
    [TestClass]
    public class BuyTest
    {
        [TestMethod]
        public void BuyTest_NoDiscount()
        {
            ShoppingCart cart = new ShoppingCart(new ConsoleLogger());
            cart.Add(1);
            cart.SetItemQuantity(1, 3);
            cart.Add(2);
            cart.SetItemQuantity(2, 4);
            cart.Add(3);
            cart.SetItemQuantity(3, 1);
            cart.GetSubTotal(cart);
            Assert.AreEqual(cart.subTotal, 8);
        }
        [TestMethod]
        public void BuyTest_Discount()
        {
            ShoppingCart cart = new ShoppingCart(new ConsoleLogger());
            List<IDiscount> discounts = new List<IDiscount>();
            discounts.Add(new DiscountButterBread("Buy 2 butters get half of one bread"));
            discounts.Add(new DiscountMilk("Buy 4 milks get one free"));
            cart.Add(1);
            cart.SetItemQuantity(1, 2);
            cart.Add(2);
            cart.SetItemQuantity(2, 8);
            cart.Add(3);
            cart.SetItemQuantity(3, 1);
            cart.GetSubTotal(cart);
            cart.GetDiscounts(cart, discounts);
            Assert.AreEqual(cart.subTotal-cart.discount, 9);
        }
    }
}
