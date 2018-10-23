using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartProject
{

    public interface IShoppingCart
    {
        void Add(int id);
        void SetItemQuantity(int productId, int quantity);
        void RemoveItem(int productId);
        void GetDiscounts(ShoppingCart sc, List<IDiscount> discounts);
        void GetSubTotal(ShoppingCart sc);
        void Log(List<IDiscount> discountList);

    } 
    public class ShoppingCart : IShoppingCart
    {
        public List<CartItem> ItemList = new List<CartItem>();
        public double subTotal { get; set; }
        public double discount { get; set; }
        ILogger _logger;
        
        public ShoppingCart(ILogger logger)
        {
            _logger = logger;
        }
        public static ShoppingCart Buy(ShoppingCart sc, Inventory menu)
        {            
            string input;
            string quantity;
            int qty;            

            do
            {
                menu.ShowInventory(menu);
                Console.WriteLine("What product do you need? Select number (Type \"exit\" to end shopping) ");
                input = Console.ReadLine().ToLower().Replace(" ", "");
                if (input != "exit" && Int32.TryParse(input, out qty))
                {
                    if (menu.inventory.Any(x => x.Id == Convert.ToInt32(input)))
                    {
                        Console.WriteLine("How many " + menu.inventory.Find(x => x.Id == Convert.ToInt32(input)).name + " do you need?");
                        quantity = Console.ReadLine();
                        if(Int32.TryParse(quantity, out qty))
                        {
                            if(menu.inventory.Find(x => x.Id == Convert.ToInt32(input)).stock >= qty)
                            {
                                sc.Add(Convert.ToInt32(input));
                                menu.inventory.Find(x => x.Id == Convert.ToInt32(input)).stock = menu.inventory.Find(x => x.Id == Convert.ToInt32(input)).stock - qty; // Nisam smislio alternativu?
                                sc.SetItemQuantity(Convert.ToInt32(input), qty);
                            }
                            else
                            {
                                Console.WriteLine("Sorry, that quantity is not avaliable");
                            }
                     }else
                     {
                         Console.WriteLine("invalid input");
                         
                     }
                        
                        
                    }
                    else
                    {
                        Console.WriteLine("invalid selection");
                        input = Console.ReadLine().ToLower().Replace(" ", "");
                    }
                }

            } while (input != "exit");

            return sc;

        }
        public void Add(int productId)
        {
            CartItem newItem = new CartItem(productId);

            if (ItemList.Contains(newItem))
            {
                foreach (CartItem item in ItemList)
                {
                    if (item.Equals(newItem))
                    {
                        item.Quantity++;
                        return;
                    }
                }
            }
            else
            {
                newItem.Quantity = 1;
                ItemList.Add(newItem);
            }
        }
        public void SetItemQuantity(int productId, int quantity)
        {
            if (quantity == 0)
            {
                RemoveItem(productId);
                return;
            }

            CartItem updatedItem = new CartItem(productId);

            foreach (CartItem item in ItemList)
            {
                if (item.Equals(updatedItem))
                {
                    item.Quantity = quantity;
                    return;
                }
            }
        }
        public void RemoveItem(int productId)
        {
            CartItem removedItem = new CartItem(productId);
            ItemList.Remove(removedItem);
        }
        public void GetDiscounts(ShoppingCart sc, List<IDiscount> discounts)
        {
            foreach (IDiscount disc in discounts)
            {
                sc.discount += disc.calculateDiscount(sc);
            }
                       
        }
        public void GetSubTotal(ShoppingCart sc)
        {           
            foreach (CartItem item in ItemList)
            {
                sc.subTotal += item.TotalPrice;
            }            
        }
        public void Log(List<IDiscount> discountList)
        {
            _logger.Log(ItemList, discountList);
        }
        



    }
}


