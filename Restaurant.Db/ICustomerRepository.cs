using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Db
{
    public interface ICustomerRepository
    {
        
        
            List<Customer> GetAllCustomer();

            Customer GetCustomer(int Id);

            Customer AddCustomer(Customer customer);


            void DeleteCustomer(int Id);

            Customer EditCustomer(Customer customer);

        }
}
