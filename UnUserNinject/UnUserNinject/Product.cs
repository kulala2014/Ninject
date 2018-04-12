using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnUserNinject
{
   public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { set; get; }
    }

   public interface IValueCalculator
   {
       decimal ValueProducts(params Product[] products);
   }
   //实现价格计算接口
   public class LinqValueCalculator : IValueCalculator
   {
       public decimal ValueProducts(params Product[] products)
       {
           return products.Sum(p => p.Price);
       }
   }

   public class ShoppingCart
   {
       private IValueCalculator calculator;

       public ShoppingCart(IValueCalculator calcParam)
       {
           calculator = calcParam;
       }

       public decimal CalculateStockValue()
       {
           // 定义和设置产品信息
           Product[] products = 
            { 
                        new Product() {  Name = "Kayak", Price  = 275M}, 
                        new Product() {  Name = "Lifejacket",  Price = 48.95M},  
                        new Product() {  Name = "Soccer ball",  Price = 19.50M}, 
                        new Product() {  Name = "Stadium", Price  = 79500M} 
            };
           // 计算总价格  
           decimal totalValue = calculator.ValueProducts(products);

           // 返回计算结果  
           return totalValue;
       }
   }
}
