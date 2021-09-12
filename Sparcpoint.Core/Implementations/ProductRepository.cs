#region " Imports "

using Microsoft.EntityFrameworkCore;
using Sparcpoint.Implementations;
using Sparcpoint.Abstract;
using Sparcpoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace Sparcpoint.Implementations
{
    
    public class ProductRepository : IProductRepository
    {
        #region " Variables "

        private readonly APIContext _context;
        private readonly IBaseRepository _baseRepository;
        

        #endregion

        #region " Constructor "

        public ProductRepository(APIContext context, IBaseRepository baseRepository)
        {
            _context = context;
            _baseRepository = baseRepository;
        }

        #endregion

        #region " Methods "


        /// <summary>
        /// Get Product Details single or multiple by passing comma separated values
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<List<Products>> GetProductDetails(string[] product)
        {
            if (_context != null)
            {
                List<Products> productList = null;

                productList = await _context.Products.Where(x => Convert.ToInt32(product)==x.InstanceId).Select(s => new Products
                {
                    InstanceId = s.InstanceId,
                    Description = s.Description,
                    Name = s.Name,
                    ProductImageUris=s.ProductImageUris,
                    ValidSkus=s.ValidSkus,
                    productCategories = _context.ProductCategories.Where(y => y.InstanceId == s.InstanceId).Select(a => new ProductCategories()
                    {
                        InstanceId = a.InstanceId,
                        CategoryInstanceId = a.CategoryInstanceId
                    }).ToList()

                }).ToListAsync();

                return productList;
            }
            return null;

        }
        /// <summary>
        /// ADD or Update Products
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="products"></param>
        /// <returns></returns>
        public async Task<int> CreateOrUpdateProducts(Int32 instanceId,Products products)
        {
            ProductCategories productCategories = null;
            List<ProductCategories> productCategoriesList = new List<ProductCategories>();

            if (_context != null)
            {
                if(instanceId==0)
                {
                    //Insert
                    await _context.Products.AddAsync(products);
                    await _context.SaveChangesAsync();
                    foreach (string obj in products.ValidSkusList)
                    {
                        productCategories = new ProductCategories() { InstanceId = products.InstanceId, CategoryInstanceId = Convert.ToInt32(obj) };
                        productCategoriesList.Add(productCategories);
                    }
                    _context.ProductCategories.AddRange(productCategoriesList);
                    _context.SaveChanges();
                    return 1;
                }
                else
                {
                    //Update
                    var productUpdate = _context.Products.Where(x => x.InstanceId == instanceId).FirstOrDefault();
                    _context.ProductCategories.Where(p => p.InstanceId == instanceId).ToList().ForEach(p => _context.ProductCategories.Remove(p));
                    _context.SaveChanges();
                    _context.Entry(productUpdate).State = EntityState.Detached;

                    productUpdate.Name = products.Name;
                    productUpdate.Description = products.Description;
                    productUpdate.ProductImageUris = products.ProductImageUris;
                    productUpdate.ValidSkus = products.ValidSkus;                   
                    _context.Products.Update(productUpdate);

                    await _context.SaveChangesAsync();

                    foreach (string obj in products.ValidSkusList)
                    {
                        productCategories = new ProductCategories() { InstanceId = products.InstanceId, CategoryInstanceId = Convert.ToInt32(obj) };
                        productCategoriesList.Add(productCategories);
                    }
                    _context.ProductCategories.AddRange(productCategoriesList);
                    _context.SaveChanges();
                }
                return 1;
            }
            return 0;
        }
        #endregion
    }
}
