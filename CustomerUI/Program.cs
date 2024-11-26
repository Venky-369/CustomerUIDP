using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiddleLayer;
using InterfaceLayer;
using FactoryLayer;
namespace CustomerUI
{
    class Program
    {
        static void Main(string[] args)
        {
            int type = Convert.ToInt16(Console.ReadLine());
            
            FactoryCustomer fact = new FactoryCustomer();
            ICustomer icust = fact.Create(type);
            icust.CustomerCode = Console.ReadLine();
            icust.CustomerName = Console.ReadLine();
            icust.Validate();
        }
    }
}
