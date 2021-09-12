using Sparcpoint.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sparcpoint.Abstract
{
    public interface IProductRepository
    {
        Task<List<Products>> GetProductDetails(string[] product);
        Task<int> CreateOrUpdateProducts(Int32 instanceId,Products products);
    }
}
