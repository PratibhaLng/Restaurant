using Restaurant.Db;
using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public Customer EditCustomer(Customer customer)
        {

            //var existingEmployee = _employeeContext.Categories.Find(category.Id);
            // if (existingEmployee != null)
            //{

            _Context.Customers.Update(customer);
            _Context.SaveChanges();
            return null;
            //    }
            //return category;
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
