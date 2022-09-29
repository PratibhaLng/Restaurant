using Microsoft.EntityFrameworkCore;
using Restaurant.Db;
using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    public class CustomerRepository : ICustomerRepository

    {
        private RestaurantDbContext _Context;
        public CustomerRepository(RestaurantDbContext Context)
        {
            _Context = Context;
        }
        public Customer AddCustomer(Customer customer)
        {


            _Context.Customers.Add(customer);
            _Context.SaveChanges();
            return customer;
        }

        public void DeleteCustomer(int Id)
        {

            var result = _Context.Customers.Where(a => a.Id == Id).FirstOrDefault();
            if (result != null)
            {

                _Context.Customers.Remove(result);
                _Context.SaveChanges();


            }
        }

        public async Task<Customer> EditCustomer(int id, Customer customer)
        {


            var _temp = GetCustomer(id);
            if (_temp != null)
            {
                _temp.ContactName = customer.ContactName;
                _temp.Address = customer.Address;
                _temp.PhoneNo = customer.PhoneNo;
                await _Context.SaveChangesAsync();
                return _temp;

            }
            return null;

        }
    
        

    
                
        public List<Customer> GetAllCustomer()
        {
            return _Context.Customers.ToList();
        }

        public Customer GetCustomer(int Id)
        {
            return _Context.Customers.FirstOrDefault(x => x.Id == Id);

        }


    }
}
