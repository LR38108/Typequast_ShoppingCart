using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartProject
{
    public interface ILogger
    {
        void Log(List<CartItem> list, List<IDiscount> discountList);
    }
    public class ConsoleLogger : ILogger
    {
        public void Log(List<CartItem> list, List<IDiscount> discountList)
        {
            Console.Write("\n-----Logging to console-----");
            Console.Write("\n" + DateTime.Now);
            Console.Write("\nThe cart contains:\n");
            foreach (CartItem i in list)
            {
                Console.WriteLine($"{i.Quantity} {i.name} = {i.TotalPrice}" );
            }
            foreach (IDiscount d in discountList)
            {
                if (d.isUsed)
                {
                    Console.WriteLine($"You used our \"{d.name}\" discount" );
                }
                
            }
        }
    }
}
