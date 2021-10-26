using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// The RestaurantModel class creates the variables to serialize to and deserialize from the products.json file
    /// </summary>
    public class RestaurantModel
    {
        //
        public string Id { get; set; }
        
        //
        public string Maker { get; set; }
        
        //
        [JsonPropertyName("img")]
        public string Image { get; set; }
        
        //
        public string Url { get; set; }
        
        //
        public string Title { get; set; }
        
        //
        public string Description { get; set; }
        
        //
        public int[] Ratings { get; set; }

        //
        public override string ToString() => JsonSerializer.Serialize<RestaurantModel>(this);

    }
}