using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using System;

namespace ContosoCrafts.WebSite.Controllers
{
    /// <summary>
    /// The ProductsController class provides a class for a controller of the products being displayed by the site
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// The ProductsController constructor creates an object with the passed in productService
        /// </summary>
        /// <param name="productService"></param>
        public ProductsController(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The ProductService stores the data from the JsonFileProductService
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// The Get method returns all the data from the product service
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return ProductService.GetAllData();
        }

        /// <summary>
        /// The Patch method adds ratings from the user to the JSON database
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
        /// The RatingRequest method returns the ratings for the product to display
        /// </summary>
        public class RatingRequest
        {
            // The ProductId string gets and sets the identifier for the product being rated
            public string ProductId { get; set; }

            // The Rating integer gets and sets the rating selected by the user
            public int Rating { get; set; }
        }
    }
}