using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// The AboutModel class is a derived class from the RazorPages PageModel
    /// </summary>
    public class AboutModel : PageModel
    {
        // A variable to hold logging for the AboutModel
        private readonly ILogger<AboutModel> _logger;

        /// <summary>
        /// The AboutModel constructor creates a AboutModel object with the passed in log
        /// </summary>
        /// <param name="logger"></param>
        public AboutModel(ILogger<AboutModel> logger)
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
