using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceLayer
{
    public interface ICustomer 
    {
         // 1 for simple customer
         // 2 for special customer
         string CustomerType { get; set; }
         string CustomerName { get; set; }
         string CustomerCode { get; set; }
         void Validate();
         ICustomer Clone();
    }
  
}
