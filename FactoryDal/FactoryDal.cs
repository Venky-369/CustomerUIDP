using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceDal;
using AdoNetDataAccessLayer;
using InterfaceLayer;
using EFDataLayer;
namespace FactoryDal
{
    public class Factory 
    {
        public IDal<ICustomer> CreateDal(int type)
        {
            if (type == 0)
            {
                return new CustomerDal();
            }
            else
            {
                return new DalEf();
            }
        }
    }
}
