using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnUserNinject
{
    class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart shoppingCart = new ShoppingCart( new LinqValueCalculator());
            Console.WriteLine(shoppingCart.CalculateStockValue());
        }
    }
}
