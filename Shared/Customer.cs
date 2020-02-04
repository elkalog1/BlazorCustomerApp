using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.Shared
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { set; get; }

        [BsonElement]      
        public string CompanyName { get; set; }

        [BsonElement]     
        public string ContactName { get; set; }

        [BsonRequired]     
        public string Address { get; set; }

        [BsonElement]     
        public string City { get; set; }

        [BsonElement]      
        public string Region { get; set; }

        [BsonElement]     
        public string PostalCode { get; set; }

        [BsonElement]      
        public string Country { get; set; }

        [BsonElement]
        public string Phone { get; set; }
 
    }
}
