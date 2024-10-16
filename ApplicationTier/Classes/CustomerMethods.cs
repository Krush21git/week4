using IndustryConnect_Week_Microservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationTier.Dtos;
using Microsoft.EntityFrameworkCore;
using ApplicationTier.Interfaces;

namespace ApplicationTier.Classes
{
    public class CustomerMethods : ICustomerMethods
    {

        public CustomerMethods() { }

        public async Task<CustomerDto> AddCustomer(string firstName, string lastName, DateTime? dateOfBirth)
        {
            var context = new IndustryConnectWeek2Context();

            var customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth
            };

            context.Add(customer);

            await context.SaveChangesAsync();
        
            return Mapper(customer);
       
        }


        public async Task<CustomerDto> GetCustomer(int CustomerId)
        {
            var context = new IndustryConnectWeek2Context();

            var customer = await context.Customers.FirstOrDefaultAsync(c => c.Id == CustomerId);

            return Mapper(customer);
        }

        public async Task<bool> RemoveCustomer(int cId)
        {
            var context = new IndustryConnectWeek2Context();

            // Retrieve the customer by Id
            //var customerToDelete = await context.Customers.FindAsync(cId);
            var customerToDelete = await context.Customers
                                     .Include(c => c.Sales) // Include related sales
                                     .FirstOrDefaultAsync(c => c.Id == cId);

            if (customerToDelete == null)
            {
                Console.WriteLine("false");
                return false; // Customer not found
            }
            else
            {
                Console.WriteLine("Customer found, removing...");
            }

            context.Sales.RemoveRange(customerToDelete.Sales);

            // Remove the customer
            context.Customers.Remove(customerToDelete);

            // Save the changes to the database
            await context.SaveChangesAsync();

            Console.WriteLine("Customer successfully removed.");

            return true; // Customer successfully removed
        }

        private static CustomerDto Mapper(Customer? customer)
        {
            if (customer != null)
            {
                var customerDto = new CustomerDto
                {
                    FirstName = customer?.FirstName,
                    LastName = customer?.LastName,
                    DateOfBirth = customer?.DateOfBirth,
                    Id = customer.Id
                };

                return customerDto;
            }
            else
            {
                return null;
            }
           
        }

    }
}
