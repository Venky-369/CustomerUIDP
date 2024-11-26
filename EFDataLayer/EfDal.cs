using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using MiddleLayer;
using InterfaceDal;
using InterfaceLayer;
namespace EFDataLayer
{
    public class EFContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().
                        ToTable("tblCustomer");
            modelBuilder.Entity<Customer>().Ignore(x => x.CustomerType);

            modelBuilder.Entity<Customer>()
                       .Map<SimpleCustomer>(m => m.Requires("CustomerType").HasValue("0"));

            modelBuilder.Entity<Customer>()
                        .Map<CustomerSpecial>(m => m.Requires("CustomerType").HasValue("1"));
        }

        public DbSet<Customer> Customers { get; set; }
    }

    public class DalEf : IDal<ICustomer>
    {
        public void Add(ICustomer obj)
        {
            Customer x = new SimpleCustomer();
            x.CustomerCode = obj.CustomerCode;
            x.CustomerName = obj.CustomerName;
            x.CustomerType = obj.CustomerType;
            EFContext dal = new EFContext();
            dal.Customers.Add(x);
            dal.SaveChanges();

        }

        public void Update(ICustomer obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(ICustomer obj)
        {
            throw new NotImplementedException();
        }

        public List<ICustomer> Get()
        {
            EFContext dal = new EFContext();
            return dal.Customers.ToList<ICustomer>();
        }
    }
}
