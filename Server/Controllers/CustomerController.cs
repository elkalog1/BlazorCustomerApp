using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp2.Server.Data;
using BlazorApp2.Shared;
using MongoDB.Driver;
using System.IO;
using BlazorApp2.Server.Services;

namespace BlazorApp2.Server.Controllers
{

    public class CustomerController : Controller
    {
      CustomerService custService = new CustomerService();

        [HttpGet("Action")]
        [Route("api/Customer/Get")]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await custService.GetCustomersAsync();    
        }

        [HttpGet]
        [Route("api/Customer/Details/{id}")]
        public async Task<Customer> Details(string id)
        {
            return await custService.GetCustomerByIdAsync(id);
        }

        [HttpPost]
        [Route("/api/Customer/Add")]
        public async Task Add([FromBody]Customer customer)         
        {
            await custService.CreateCustomerAsync(customer);           
        }

        [HttpPut]
        [Route("api/Customer/Edit")]
        public async Task Edit([FromBody]Customer customer)
        {
            await custService.UpdateCustomerAsync(customer);
        }

        [HttpDelete]
        public async Task Delete(string id)
        {
            await custService.DeleteCustomerAsync(id);
        }

   
        [HttpGet]
        [Route("api/Customer/SearchResults/{search}")]
        public async Task<List<Customer>> SearchResults(string search)
        {
            return await custService.GetCustomerResultsAsync(search);
        }
      
    }
}
