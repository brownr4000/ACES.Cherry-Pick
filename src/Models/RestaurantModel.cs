using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// The RestaurantModel class creates the variables to serialize to and deserialize from the products.json file
    /// </summary>
    public class RestaurantModel
    {
        // String ID to store ID property from products.json attribute
        public string Id { get; set; }

        // String Maker to store Maker property from products.json attribute 
        public string Maker { get; set; }

        // Customizing JSON property name "img", and using String Image to store the img property from products.json attribute
        [JsonPropertyName("img")]
        public string Image { get; set; }

        // String Url to store Url property from products.json attribute 
        public string Url { get; set; }

        // String Title to store Title property from products.json attribute 
        public string Title { get; set; }

        // String Description to store Description property from products.json attribute 
        public string Description { get; set; }

        // Integer Array Ratings to store Ratings property from products.json attribute
        public int[] Ratings { get; set; }

        // Override ToString() method for class
        public override string ToString() => JsonSerializer.Serialize<RestaurantModel>(this);

    }
}