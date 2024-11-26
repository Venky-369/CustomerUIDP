using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceDal;
using InterfaceLayer;
using System.Data;
using System.Data.SqlClient;
using FactoryLayer;
namespace AdoNetDataAccessLayer
{
    public class CustomerDal : IDal<ICustomer>
    {
        string strConn = @"Data Source=localhost\SQL2008;Initial Catalog=DbCustomer;Integrated Security=True";
        public void Add(ICustomer obj)
        {
            SqlConnection oconn = new SqlConnection(strConn);
            oconn.Open();

            SqlCommand cmd = new SqlCommand("insert into tblCustomer(CustomerType,CustomerCode,CustomerName) values("
                                    + obj.CustomerType + ","
                                    + "'" + obj.CustomerCode + "','" 
                                    + obj.CustomerName + "')",oconn);
            cmd.ExecuteNonQuery();
            oconn.Close();
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
            FactoryCustomer fact = new FactoryCustomer();
            SqlConnection oconn = new SqlConnection(strConn);
            oconn.Open();

            SqlCommand cmd = new SqlCommand("select * from tblCustomer", oconn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<ICustomer> customers = new List<ICustomer>();
            while (dr.Read())
            {
                ICustomer temp = fact.Create(0);
                temp.CustomerCode = dr["CustomerCode"].ToString();
                temp.CustomerName = dr["CustomerName"].ToString();
                temp.CustomerType = dr["CustomerType"].ToString();
                customers.Add(temp);
            }
            oconn.Close();
            return customers;
        }
    }
}
