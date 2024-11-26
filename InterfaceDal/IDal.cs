using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceLayer;
namespace InterfaceDal
{
    public interface IDal<AnyType>
    {
        void Add(AnyType obj);
        void Update(AnyType obj);
        void Delete(AnyType obj);
        List<AnyType> Get();

    }
}
