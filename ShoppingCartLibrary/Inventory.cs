using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartProject
{
    public class Inventory
    {
        public List<Item> inventory = new List<Item>();

        public void LoadInventory(Inventory menu)
        {
            menu.AddToInventory(new Item(1));
            menu.AddToInventory(new Item(2));
            menu.AddToInventory(new Item(3));
        }
        public void AddToInventory(Item i)
        {
            inventory.Add(i);
        }
        public void ShowInventory(Inventory menu)
        {
            Console.WriteLine("our inventory:");
                foreach (Item i in menu.inventory)
                {
                    Console.WriteLine($"{i.Id} {i.name} $ {i.price} {i.stock}");
                }
        }
    }
}
