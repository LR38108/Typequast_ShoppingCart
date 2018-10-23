using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartProject
{
    public interface IDiscount
    {
        string name { get; set; }
        bool isUsed { get; set; }
        double calculateDiscount(ShoppingCart cart);
    }
    public class DiscountMilk : IDiscount
    {
        private string _name;
        private bool _isUsed;
        public bool isUsed
        {
            get { return _isUsed; }

            set
            {
                _isUsed = value;
            }
        }
        public string name
        {
            get { return _name; }

            set
            {
                _name = value;
            }
        }

        public DiscountMilk(string name)
        {
            _name = name;
        }
        public double calculateDiscount(ShoppingCart cart)
        {
            double totalDiscount = 0;
            bool hasMilk = cart.ItemList.Any(x => x.name == "Milk"); 

            if(hasMilk)
            {
                int milk = cart.ItemList.Find(x => x.name == "Milk").Quantity;
                double freeMilks = milk / 4;
                totalDiscount =  freeMilks * cart.ItemList.Find(x => x.name == "Milk").price;
                if (totalDiscount > 0)
                {
                    isUsed = true;
                }
            }
            return totalDiscount;
        }
    }

    public class DiscountButterBread : IDiscount
    {
        private string _name;
        private bool _isUsed;
        public bool isUsed
        {
            get { return _isUsed; }

            set
            {
                _isUsed = value;
            }
        }
        public string name
        {
            get { return _name; }

            set
            {
                _name = value;
            }
        }

        public DiscountButterBread(string name)
        {
            _name = name;                
        }
        public double calculateDiscount(ShoppingCart cart)
        {
            double totalDiscount = 0;
            bool hasButter = cart.ItemList.Any(x => x.name == "Butter");

            if (hasButter)
            {
                if(cart.ItemList.Any(x => x.name == "Bread"))
                {
                    totalDiscount = cart.ItemList.Find(x => x.name == "Bread").price / 2;
                    if (totalDiscount > 0)
                    {
                        isUsed = true;
                    }
                }
                    
            }
            return totalDiscount;
        }
    }
}
