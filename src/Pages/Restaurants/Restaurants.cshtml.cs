using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// The ReadModel class allows a user to read a entry for the site
    /// </summary>
    public class RestaurantModel : PageModel
    {
        // Data middletier
        public JsonFileRestaurantService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public RestaurantModel(JsonFileRestaurantService productService)
        {
            // Setting ProductService to productService from JSON file
            ProductService = productService;
        }

        // The data to show
        public ProductModel Product;

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public IActionResult OnGet(string id)
        {
            // Redirect the webpage to the read page populated with the data so the user can read the page
            Product = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
            if (Product == null)
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}