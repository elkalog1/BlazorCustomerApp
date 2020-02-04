using BlazorApp2.Shared;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace BlazorApp2.Server.Data
{
    public class CustomerContext 
    {
       private readonly IMongoDatabase _db;

        //connect with database
        public CustomerContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _db = client.GetDatabase("InfoDB");
        }

        //get the collections
        public IMongoCollection<Customer> LoadCustomer
        {
            get
            {
                return _db.GetCollection<Customer>("Customers");
            }
        }
    }
}
