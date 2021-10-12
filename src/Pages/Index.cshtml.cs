using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
/// <summary>
/// I love Seattle Dogs
/// </summary>
/// /// <summary>
/// I love Seattle spring
/// </summary>
namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Bakyadevi Ray
    /// <jj>add</jj>
    /// </summary>
    ///
    ///<summary>
    /// ZiQi Li
    /// </summary>
    ///
    /// <summary>
    /// Florence Xie
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