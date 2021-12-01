using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Manage the Update of the data for a single record
    /// </summary>
    public class UpdateModel : PageModel
    {
        // Boolean flag to notify if error occurs
        public bool errorCheck = false;

        // Data middletier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public UpdateModel(JsonFileProductService productService)
        {
            // Setting ProductService to productService from JSON file
            ProductService = productService;
        }

        // The data to show, bind to it for the post
        [BindProperty]
        public ProductModel Product { get; set; }

        /// <summary>
        /// REST Get request
        /// Loads the Data
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            // Redirect the webpage to the read page populated with the data so the user can read the page
            Product = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));

            // Checks if Product is Null
            if (Product == null)
            {
                errorCheck = true;
            }
        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer to Update that data
        /// Then return to the index page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            // Checks if ModelState is not valid
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ProductService.UpdateData(Product);

            return RedirectToPage("./Index");
        }
    }
}