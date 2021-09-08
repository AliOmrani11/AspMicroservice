using Catalog.Api.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Data
{
    public class CatalogContext : ICatalogContext
    {
        private readonly IConfiguration _configure;

        public CatalogContext(IConfiguration configure)
        {
            _configure = configure;
            var client = new MongoClient(configure.GetValue<string>("DatabaseSetting:ConnectionString"));
            var database = client.GetDatabase(configure.GetValue<string>("DatabaseSetting:DatabaseName"));

            Products = database.GetCollection<TblProduct>(configure.GetValue<string>("DatabaseSetting:CollectionName"));
            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<TblProduct> Products { get; }
    }
}
