using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp2.Shared;
using BlazorApp2.Server.Data;
using MongoDB.Driver;

namespace BlazorApp2.Server.Services
{
    public class CustomerService
    {
        CustomerContext _context = new CustomerContext();

        public async Task<List<Customer>> GetCustomersAsync()
        {
            try
            {
                return await _context.LoadCustomer.Find(_ => true).ToListAsync().ConfigureAwait(false);
            }
            catch
            {
                throw;
            }
        }
       
        public async Task CreateCustomerAsync(Customer customer)
        {
            try
            {
                await _context.LoadCustomer.InsertOneAsync(customer); 
            }
            catch
            {
                throw;
            }
        }

         public async Task<Customer> GetCustomerByIdAsync(string id)
         {
            try
            {
                var filter = Builders<Customer>.Filter.Eq("Id", id);
                return await _context.LoadCustomer.FindSync(filter).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
         }
        
        public async Task<List<Customer>> GetCustomerResultsAsync(string search)
        {
            try
            {
                var filterDef = new FilterDefinitionBuilder<Customer>();
                var filter = filterDef.In(x => x.CompanyName, new[] { search});
                var filter1 = filterDef.In(x => x.ContactName, new[] { search });
                var filter2 = filterDef.In(x => x.Address, new[] { search });
                var filter3 = filterDef.In(x => x.City, new[] { search });
                var filter4 = filterDef.In(x => x.Region, new[] { search });
                var filter5 = filterDef.In(x => x.Country, new[] { search });
                var filter6 = filterDef.In(x => x.PostalCode, new[] { search });            
                var filter7 = filterDef.In(x => x.Phone, new[] { search });
                return await _context.LoadCustomer.FindSync(filter|filter1| filter2 | filter3 | filter4 | filter5 | filter6 | filter7).ToListAsync().ConfigureAwait(false); 
            }
            catch
            {
                throw;
            }
        }
       
        public async Task UpdateCustomerAsync(Customer customer)
        {
            try
            {
                await _context.LoadCustomer.ReplaceOneAsync(filter: g => g.Id == customer.Id, replacement:customer);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteCustomerAsync(string id)
        {
            try
            {
                FilterDefinition<Customer> customer = Builders<Customer>.Filter.Eq("Id", id);
                await _context.LoadCustomer.DeleteOneAsync(customer);
            }
            catch
            {
                throw;
            }
        }
    }
}
