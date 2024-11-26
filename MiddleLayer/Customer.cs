using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceLayer;
using System.ComponentModel.DataAnnotations;
namespace MiddleLayer
{
    public abstract class Customer : ICustomer 
    {
        private Customer _oldValue;

        private string _CustomerCode="";

        private string _CustomerName="";

      
        public abstract void Validate();
        
        public string CustomerName
        {
            get
            {
                return _CustomerName;
            }
            set
            {
                _CustomerName = value;
            }
        }

        [Key]
        public string CustomerCode
        {
            get
            {
                return _CustomerCode;
            }
            set
            {
                _CustomerCode = value;
            }
        }


        private string _Type;

        
        public string CustomerType
        {
            get { return _Type; }
            set { _Type = value; }
        }

       

        public ICustomer Clone()
        {
            return (Customer)this.MemberwiseClone();
        }

    }

    

    public class SimpleCustomer : Customer
    {
        public SimpleCustomer()
        {
            CustomerType = "0";
        }
        public override void Validate()
        {
            if (CustomerCode.Length == 0)
            {
                throw new Exception("Customer code not allowed");

            }
            if (CustomerName.Length == 0)
            {
                throw new Exception("Customer name not allowed");

            }
        }
    }

    public class CustomerSpecial : SimpleCustomer
    {
        public CustomerSpecial()
        {
            CustomerType = "1";
        }
        public override void Validate()
        {
            this.Validate();
            if (CustomerName.Length > 8)
            {
                throw new Exception("Customer name not allowed");

            }
        }
    }
    
}
