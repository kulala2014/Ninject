using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Autofac;

namespace UserNinject
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> tempDic = new Dictionary<string, string>();
            tempDic.Add("key1", "value1");
            tempDic.Add("key2", "value2");
            tempDic.Add("key3", "value3");
            string values = "";

            bool result = tempDic.TryGetValue("key1", out values);
            //IKernel ninjectKernel = new StandardKernel(); 
            ////绑定接口到实现类里
            //ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>(); 
            //IValueCalculator calcImpl = ninjectKernel.Get<IValueCalculator>(); 
            // ShoppingCart cart = new  ShoppingCart(calcImpl); 
            // Console.WriteLine("Total: {0:c} calculated by Ninject", cart.CalculateStockValue());


            //ContainerBuilder builder = new ContainerBuilder();
            //builder.RegisterType<LinqValueCalculator>().As<IValueCalculator>();
            //IContainer container = builder.Build();
            //IValueCalculator calcImpl02 = (LinqValueCalculator)container.Resolve<IValueCalculator>();
            //ShoppingCart cart02 = new ShoppingCart(calcImpl02);
            //Console.WriteLine("Total: {0:c} calculated by AutoFac", cart.CalculateStockValue());

        }
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

    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { set; get; }
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
