using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// The PrivacyModel class is a derived class from the RazorPages PageModel
    /// </summary>
    public class PrivacyModel : PageModel
    {
        // A variable to hold logging for the PrivacyModel
        private readonly ILogger<PrivacyModel> _logger;

        /// <summary>
        /// The PrivacyModel constructor creates a PrivacyModel object with the passed in log
        /// </summary>
        /// <param name="logger"></param>
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// The OnGet method is empty
        /// </summary>
        public void OnGet()
        {

        }
    }
}