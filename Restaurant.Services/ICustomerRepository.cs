using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    public interface ICustomerRepository
    {


        List<Customer> GetAllCustomer();

        Customer GetCustomer(int Id);

        Customer AddCustomer(Customer customer);


        void DeleteCustomer(int Id);

        Task<Customer> EditCustomer(int id,Customer customer);

    }
}

