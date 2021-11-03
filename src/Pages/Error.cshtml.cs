using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// The ErrorModel class is a derived class from the RazorPages PageModel
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        // RequestId holds the id value of the request that cause the ErrorModel to be generated
        public string RequestId { get; set; }

        // ShowRequestId returns true/false is the RequestId string is not null or empty
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // A variable to hold logging for the ErrorModel
        private readonly ILogger<ErrorModel> _logger;

        /// <summary>
        /// The ErrorModel constructor creates a new object with the passed in logger
        /// </summary>
        /// <param name="logger"></param>
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// The OnGet method returns the Id of the current activity
        /// </summary>
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}