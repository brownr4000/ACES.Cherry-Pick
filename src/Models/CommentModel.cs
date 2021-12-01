using System.ComponentModel.DataAnnotations;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// The CommentModel class creates the variables to add comments entered by the user about the Product
    /// </summary>
    public class CommentModel
    {
        // String ID for this comment, use a Guid so it is always unique
        public string Id { get; set; } = System.Guid.NewGuid().ToString();

        // String Comment to store the comment from the user
        [StringLength(maximumLength: 256, MinimumLength = 8, ErrorMessage = "The Comment should have a length of more than {2} and less than {1}")]
        public string Comment { get; set; }
    }
}