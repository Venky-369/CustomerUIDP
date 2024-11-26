using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceDal;
using InterfaceLayer;
using FactoryDal;
using FactoryLayer;
using MiddleLayer;
namespace ServiceUI
{
    
    public class ServiceCustomer 
    {
        int _type = 0;
       
        FactoryDal.Factory fact = new FactoryDal.Factory();
        private List<ICustomer> custs = new List<ICustomer>();
        IDal<ICustomer> custdal = null;
        private ICustomer temp = null;
        ICustomer icust = new SimpleCustomer();
        public ServiceCustomer(int Type)
        {
            
            _type = Type;
            custdal = fact.CreateDal(_type);
            custs = custdal.Get();
        }
        public void Add(ICustomer obj)
        {
            custdal.Add(obj);
        }
        public ICustomer Create(int type)
        {
            FactoryCustomer obj = new FactoryCustomer();
            icust =  obj.Create(type);
            return icust;
        }
        public ICustomer Select(int i)
        {
            icust.CustomerCode = custs[i].CustomerCode;
            icust.CustomerName = custs[i].CustomerName;
            icust.CustomerType = custs[i].CustomerType;
            temp = (ICustomer) icust.Clone();
            return icust;
        }
        public ICustomer Revert()
        {
            icust.CustomerCode = temp.CustomerCode;
            icust.CustomerName = temp.CustomerName;
            icust.CustomerType = temp.CustomerType;
            return icust;
        }
        public List<ICustomer> Get()
        {
            
            IDal<ICustomer> custdal = fact.CreateDal(_type);
            custs = custdal.Get();
            return custs;
        }

    }
}
