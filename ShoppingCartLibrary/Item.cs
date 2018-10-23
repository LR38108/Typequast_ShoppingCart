using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShoppingCartProject
{
    public class Item 
    {   
 
        public int Id { get; set; }
        public double price { get; set; }
        public string name { get; set; }
        public int stock { get; set; }

        public Item(int id)
        {
            this.Id = id;
            switch (id)
            {
                case 1:
                    this.price = 0.8;
                    this.name = "Butter";
                    this.stock = 10;
                    break;
                case 2:
                    this.price = 1.15;
                    this.name = "Milk";
                    this.stock = 10;
                    break;
                case 3:
                    this.price = 1.00;
                    this.name = "Bread";
                    this.stock = 10;
                    break;
            }
        }

    }
}

