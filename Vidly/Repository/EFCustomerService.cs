using System;
using System.Collections.Generic;
using System.Linq;
using Vidly.Models;
using System.Data.Entity;
using Vidly.Infrastracture;

namespace Vidly.Repository
{
    public class EFCustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _dbContext;
        public EFCustomerService(ApplicationDbContext context)
        {
            _dbContext = context;   
        }

        public bool AddCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateCustomer(Customer customer)
        {
            Customer dbCust = GetCustomer(customer.Id);
            if (dbCust == null)
                throw new ArgumentException("Not Found");

            dbCust.BirthDate = customer.BirthDate;
            dbCust.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            dbCust.MembershipTypeId = customer.MembershipTypeId;
            dbCust.Name  = customer.Name;
            //Mapper.Map(customer, dbMovie);

            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteCustomer(int id)
        {
            Customer customer = GetCustomer(id);
            if (customer == null)
                return false;

            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<MembershipType> GetMembershipTypes()
        {
            return _dbContext.MembershipTypes.ToList();
        }

        public Customer GetCustomer(int id)
        {
            return _dbContext.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _dbContext.Customers.Include(c => c.MembershipType).ToList();
        }
    }
}