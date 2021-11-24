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

        // The data to show the ProductModel
        [BindProperty]
        public ProductModel Product { get; set; }

        /// <summary>
        /// The CreateData methoid allows for the creation of a new item in the JSON filestore
        /// </summary>
        /// <returns></returns>
        public ProductModel CreateData()
        {
            return new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Title = "Enter Title",
                Description = "Enter Description",
                Url = "Enter URL",
                Image = "",
            };
        }

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public void OnGet()
        {
            Product = CreateData();

            // Redirect the webpage to the Update page populated with the data so the user can fill in the fields
            // return RedirectToPage("./Index");
        }

        /// <summary>
        /// The OnPost method determines if the new data is valid. It creates a new entry if it is, and returns to the index page.
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            ProductService.CreateData(Product);
            // Redirect the webpage to the Index page populated with the data so the user can fill in the fields
            return RedirectToPage("./Index");

        }
    }
}