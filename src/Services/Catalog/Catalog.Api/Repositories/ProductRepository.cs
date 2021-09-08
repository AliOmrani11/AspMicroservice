using Catalog.Api.Data;
using Catalog.Api.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Repositories
{
    class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _catalog;

        public ProductRepository(ICatalogContext catalog) 
        {
            _catalog = catalog;
        }




        public async Task<IEnumerable<TblProduct>> GetAll()
        {
            return await _catalog.Products.Find(s=>true).ToListAsync();
        }

        public async Task<IEnumerable<TblProduct>> GetByCategory(string category)
        {
            return await _catalog.Products.Find(s => s.Category == category).ToListAsync();
        }

        public async Task<TblProduct> GetById(string id)
        {
            return await _catalog.Products.Find(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<TblProduct> GetByName(string name)
        {
            return await _catalog.Products.Find(s => s.Name == name).FirstOrDefaultAsync();
        }

        public async Task Insert(TblProduct product)
        {
            await _catalog.Products.InsertOneAsync(product);
        }

        public async Task<bool> Update(TblProduct product)
        {
            var update = await _catalog.Products.ReplaceOneAsync(s => s.Id == product.Id, product);
            return update.IsAcknowledged && update.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            var delete = await _catalog.Products.DeleteOneAsync(s => s.Id == id);
            return delete.IsAcknowledged && delete.DeletedCount > 0;
        }
    }
}
