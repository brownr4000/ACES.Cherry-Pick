using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductModel
    {
        // String ID
        public string Id { get; set; }
        
        // String Maker
        public string Maker { get; set; }
        
        // Taking JSON property img and setting it to Image
        [JsonPropertyName("img")]
        public string Image { get; set; }

        // String URL
        public string Url { get; set; }

        // String Title
        public string Title { get; set; }

        // String Description
        public string Description { get; set; }

        // Int array Ratings
        public int[] Ratings { get; set; }

        // Override ToString() method
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);

 
    }
}