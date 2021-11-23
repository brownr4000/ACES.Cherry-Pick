using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Comments entered by the user about the Product
    /// </summary>
    public class CommentModel
    {
        // The ID for this comment, use a Guid so it is always unique
        public string Id { get; set; } = System.Guid.NewGuid().ToString();

        // The Comment
        [StringLength(maximumLength: 256, MinimumLength = 8, ErrorMessage = "The Comment should have a length of more than {2} and less than {1}")]
        public string Comment { get; set; }
    }
}