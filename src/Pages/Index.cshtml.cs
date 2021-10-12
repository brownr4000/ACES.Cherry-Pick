using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
/// <summary>
/// I love Seattle Florence trying
/// </summary>
/// /// <summary>
/// I love Seattle spring
/// </summary>
/// /// <summary>
/// I love Seattle
/// </summary>
namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Bakyadevi Ray
    /// </summary>
    ///
    ///<summary>
    /// ZiQi Li
    /// </summary>
    ///
    /// <summary>
    /// Florence Xie
    /// hiii
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }
        public IEnumerable<ProductModel> Products { get; private set; }

        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
    }
}