using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productService"></param>
        public ProductsController(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        //
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return ProductService.GetAllData();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            ProductService.AddRating(request.ProductId, request.Rating);
            
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        public class RatingRequest
        {
            public string ProductId { get; set; }
            public int Rating { get; set; }
        }
    }
}