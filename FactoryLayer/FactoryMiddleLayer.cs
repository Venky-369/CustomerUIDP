using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceLayer;
using MiddleLayer;
using InterfaceDal;

namespace FactoryLayer
{
    public class FactoryCustomer
    {
        List<ICustomer> custs = new List<ICustomer>();
        public FactoryCustomer()
        {
            custs.Add(new SimpleCustomer());
            custs.Add(new CustomerSpecial());
        }
        public ICustomer Create(int type)
        {
            return  custs[type].Clone();
            
        }
        
    }
}
