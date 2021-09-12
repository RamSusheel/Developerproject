using Microsoft.AspNetCore.Mvc;
using Sparcpoint.Abstract;
using Sparcpoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 

namespace Interview.Web.Controllers
{
    [Route("api/v1/products")]
    public class ProductController : Controller
    {
        readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        // NOTE: Sample Action
        [HttpGet]
        public Task<IActionResult> GetAllProducts()
        {
            return Task.FromResult((IActionResult)Ok(new object[] { }));
        }

        #region GET: api/v1/products/GetProductsDetails

        [HttpGet("GetProductsDetails/{product}")]
        public async Task<ActionResult<IEnumerable<Products>>> GetProductsDetails(string products)
        {
            List<Products> result = null;
            try
            {
                string[] ProductList = products.Split(',');
                result = await _productRepository.GetProductDetails(ProductList);
                if (result == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return Ok(result);
        }

        #region POST:api/v1/products/CreateOrUpdateProducts
        [HttpPost("CreateOrUpdateProducts")]
        public async Task<ActionResult<Products>> CreateOrUpdateProducts(Int32 instanceId,Products model)
        {
            var productId = 0;
            if (ModelState.IsValid)
            {
                try
                {
                    productId = await _productRepository.CreateOrUpdateProducts(instanceId,model);

                    return Ok(productId);
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return BadRequest();
        }
        #endregion

        #endregion
    }
}
