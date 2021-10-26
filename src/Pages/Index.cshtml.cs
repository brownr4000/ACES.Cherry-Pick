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
        //
        private readonly ILogger<IndexModel> _logger;

        //
        public IndexModel(ILogger<IndexModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        //
        public JsonFileProductService ProductService { get; }
        
        //
        public IEnumerable<ProductModel> Products { get; private set; }

        //
        public void OnGet()
        {
            Products = ProductService.GetAllData();
        }
    }
}