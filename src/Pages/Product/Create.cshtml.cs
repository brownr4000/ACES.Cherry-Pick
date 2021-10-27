using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// The CreateModel class allows a user to create a new entry for the site
    /// </summary>
    public class CreateModel : PageModel
    {
        // Data middle tier to access JSON file
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public CreateModel(JsonFileProductService productService)
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
        public IActionResult OnGet()
        {
            Product = ProductService.CreateData();

            // Redirect the webpage to the Update page populated with the data so the user can fill in the fields
            return RedirectToPage("./Update", new { Id = Product.Id });
        }
    }
}