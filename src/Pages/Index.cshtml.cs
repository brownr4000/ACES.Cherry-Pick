using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

/// /// <summary>
/// ACES team loves Seattle restaurants!
/// </summary>
namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Bakyadevi Ray
    /// ZiQi Li
    /// Florence Xie
    /// Bob Brown
    /// 
    /// The IndexModel class
    /// </summary>
    public class IndexModel : PageModel
    {
        // Creates a private logger interface for the IndexModel class
        private readonly ILogger<IndexModel> _logger;

        // Creates a IndexModel object
        public IndexModel(ILogger<IndexModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        // Creates the ProductService to read data from the JSON file
        public JsonFileProductService ProductService { get; }
        
        // Creates an enermerable object based on the ProductModel
        public IEnumerable<ProductModel> Products { get; private set; }

        // The OnGet method returns all the data from the ProductService
        public void OnGet()
        {
            Products = ProductService.GetAllData();
        }
    }
}