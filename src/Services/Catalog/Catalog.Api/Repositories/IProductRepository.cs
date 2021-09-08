using Catalog.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<TblProduct>> GetAll();
        Task<TblProduct> GetById(string id);
        Task<IEnumerable<TblProduct>> GetByCategory(string category);
        Task<TblProduct> GetByName(string name);
        Task Insert(TblProduct product);
        Task<bool> Update(TblProduct product);
        Task<bool> Delete(string id);
    }
}
