using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartProject
{
    class Program
    {
       static void Main(string[] args)
        {
            
            ShoppingCart cart = new ShoppingCart(new ConsoleLogger());
            List<IDiscount> discounts = new List<IDiscount>();
            discounts.Add(new DiscountButterBread("Buy 2 butters get half of one bread"));
            discounts.Add(new DiscountMilk("Buy 4 milks get one free"));
            Inventory menu = new Inventory();
            menu.LoadInventory(menu);
            begining:
            string userInput;

            if (cart.ItemList.Count == 0)
            {
                Console.Write("Your cart is empty. Would you like to buy something? (y/n) (Type \"end\" to end shopping)");
                userInput = Console.ReadLine().ToLower().Replace(" ", "");
            }
            else
            {
                Console.Write("\nYour cart:\n");
                foreach (CartItem i in cart.ItemList)
                {
                    Console.Write("|" +i.Quantity + " " + i.name + "|\n");
                }
                Console.Write("\nWould you like to buy something? (y/n) (Type \"end\" to cancel shopping)");
                userInput = Console.ReadLine().ToLower().Replace(" ", "");
            }

            do
            {
                if (userInput == "y")
                {
                    cart = ShoppingCart.Buy(cart, menu);
                    goto begining;

                }
                else if (userInput == "n")
                {
                    Console.Write("Your cart contains: ");
                    foreach (CartItem i in cart.ItemList)
                    {
                        Console.Write(i.name + " ");
                    }
                    cart.GetSubTotal(cart);
                    Console.Write("\nAnd your subtotal is " + cart.subTotal);
                    cart.GetDiscounts(cart, discounts);
                    Console.Write("\nAnd your discount is " + cart.discount);
                    Console.Write("\nSo your total is " + (cart.subTotal - cart.discount));
                    cart.Log(discounts);
                    foreach (IDiscount disc in discounts)
                    {
                        disc.isUsed = false;

                    }
                    Console.ReadLine();
                    return;
                }else if(userInput == "end")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.Write("Sorry i did not understand that. Would you like to buy something? (y/n) ");
                    userInput = Console.ReadLine().ToLower().Replace(" ", "");
                }
            } while (userInput != "y" || userInput != "n");
               
        }

    }
}
