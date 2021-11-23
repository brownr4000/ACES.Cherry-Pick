using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// The ProductModel class creates the variables to serialize to and deserialize from the products.json file
    /// </summary>
    public class ProductModel
    {
        // String ID to store ID property from products.json attribute
        public string Id { get; set; }

        // String Maker to store Maker property from products.json attribute
        [StringLength(maximumLength: 32, MinimumLength = 1, ErrorMessage = "The Title should have a length of more than {2} and less than {1}")]
        public string Maker { get; set; }

        // Customizing JSON property name "img", and using String Image to store the img property from products.json attribute 
        [JsonPropertyName("img")]
        public string Image { get; set; }

        // String Url to store Url property from products.json attribute
        [Url(ErrorMessage = "Not a valid URL")]
        public string Url { get; set; }

        // String Title to store Title property from products.json attribute 
        [StringLength(maximumLength: 32, MinimumLength = 1, ErrorMessage = "The Title should have a length of more than {2} and less than {1}")]
        public string Title { get; set; }

        // String Description to store Description property from products.json attribute 
        [StringLength(maximumLength: 64, MinimumLength = 1, ErrorMessage = "The Description should have a length of more than {2} and less than {1}")]
        public string Description { get; set; }

        // Store the Comments entered by the users on this product
        public List<CommentModel> CommentList { get; set; } = new List<CommentModel>();

        // Integer Array Ratings to store Ratings property from products.json attribute 
        public int[] Ratings { get; set; }

        // Override ToString() method for class
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);

    }
}